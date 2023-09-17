using AutoMapper;
using MediatR;
using SimplyKnowHau.Application.DTOs;
using SimplyKnowHau.Application.Interfaces;
using SimplyKnowHau.Domain.Entities;
using SimplyKnowHau.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyKnowHau.Application.Commands.UpdateUserCommand
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UserDTO>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(IUserRepository userRepository, IPasswordHasher passwordHasher, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDTO> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var userToUpdate = _mapper.Map<User>(request.UserDTO);

            userToUpdate = await _userRepository.Update(userToUpdate);
            var userDTOResponse = _mapper.Map<UserDTO>(userToUpdate);

            return userDTOResponse;
        }
    }
}
