using AutoMapper;
using Nettium_Test.Application.DTOs.Users;
using Nettium_Test.Application.Interfaces.Caching;
using Nettium_Test.Application.Interfaces.Messaging;
using Nettium_Test.Application.Interfaces.Repositories;
using Nettium_Test.Application.Interfaces.Services;
using Nettium_Test.Domain.Entities;
using System.Text.Json;

namespace Nettium_Test.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IRedisCacheService _redisCache;
        private readonly IRabbitMqPublisher _publisher;


        public UserService(IUserRepository userRepository,
            IMapper mapper,
            IRedisCacheService cache,
            IRabbitMqPublisher publisher)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _redisCache = cache;
            _publisher = publisher;
        }

        public async Task<UserDto> GetUserByIdAsync(Guid id)
        {
            var cacheKey = $"user:{id}";
            var user = await _redisCache.GetAsync<User>(cacheKey);

            if (user is null)
            {
                user = await _userRepository.GetByIdAsync(id);
                CacheUserAsync(id, user);
            }

            return _mapper.Map<UserDto>(user);
        }

        public async Task<IEnumerable<UserDto>> GetAllUserAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task<UserDto> CreateUserAsync(UserCreateDto dto)
        {
            var user = _mapper.Map<User>(dto);
            await _userRepository.InsertAsync(user);
            CacheUserAsync(user.Id, user);

            var json = JsonSerializer.Serialize(user);
            await _publisher.PublishAsync("user.created", json);

            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> UpdateUserAsync(Guid id, UserUpdateDto dto)
        {
            var user = await _userRepository.GetByIdAsync(id);

            user.EmailAddress = dto.EmailAddress;
            user.IsActive = dto.IsActive;

            await _userRepository.UpdateAsync(user);
            CacheUserAsync(id, user);

            return _mapper.Map<UserDto>(user);
        }

        public async Task<bool> DeleteUserAsync(Guid id)
        {
            var result = await _userRepository.Deletesync(id);
            _redisCache.RemoveAsync($"user:{id}");
            return result;
        }

        private async Task CacheUserAsync(Guid id, User? user)
        {
            if (user is not null)
            {
                var cacheKey = $"user:{id}";
                await _redisCache.SetAsync(cacheKey, user, TimeSpan.FromMinutes(10));
            }
        }
    }
}
