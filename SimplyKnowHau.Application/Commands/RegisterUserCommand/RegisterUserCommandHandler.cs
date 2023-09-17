using AutoMapper;
using MediatR;
using Microsoft.Extensions.Options;
using SimplyKnowHau.Application.DTOs;
using SimplyKnowHau.Application.Interfaces;
using SimplyKnowHau.Domain.Entities;
using SimplyKnowHau.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyKnowHau.Application.Commands.RegisterUserCommand
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, UserDTO>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IMapper _mapper;

        public RegisterUserCommandHandler(IUserRepository userRepository, IPasswordHasher passwordHasher, IMapper mapper)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _mapper = mapper;
        }
        public async Task<UserDTO> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var userToRegister = _mapper.Map<User>(request.UserDTO);

            userToRegister.PasswordHash = _passwordHasher.Hash(request.UserDTO.Email, request.UserDTO.Password);
            userToRegister.RoleId = 4;

            userToRegister = await _userRepository.Register(userToRegister);
            var userDTOResponse = _mapper.Map<UserDTO>(userToRegister);

            return userDTOResponse;
        }
    }
}
