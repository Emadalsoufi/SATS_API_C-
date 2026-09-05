using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.IRepository;
using System;
using System.Collections.Generic;

namespace SATS.Application.ServiceImpl
{
    public class UserServiceImpl : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserServiceImpl(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public void CreateUser(UserDto userDto)
        {
            if (userDto is null) throw new ArgumentNullException(nameof(userDto));
            var entity = _mapper.Map<User>(userDto);
            _userRepository.Add(entity);
        }

        public void UpdateUser(UserDto userDto)
        {
            if (userDto is null) throw new ArgumentNullException(nameof(userDto));
            var existingUser = _userRepository.GetById(userDto.UserId);
            if (existingUser is null) throw new ArgumentException("User was not found.", nameof(userDto));
            _mapper.Map(userDto, existingUser);
            _userRepository.Update(existingUser);
        }

        public UserDto? GetUserById(int id)
        {
            var entity = _userRepository.GetById(id);
            return entity is null ? null : _mapper.Map<UserDto>(entity);
        }

        public IEnumerable<UserDto> GetAllUsers()
        {
            var entities = _userRepository.GetAll();
            return _mapper.Map<IEnumerable<UserDto>>(entities);
        }
    }
}
