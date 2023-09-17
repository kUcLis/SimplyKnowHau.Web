using AutoMapper;
using MediatR;
using SimplyKnowHau.Application.DTOs;
using SimplyKnowHau.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyKnowHau.Application.Queries.GetAllUsersQuery
{
    public class GetAllUsersQueryQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<UserDTO>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetAllUsersQueryQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDTO>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var usersDTOs = new List<UserDTO>();

            foreach(var user in _userRepository.GetAll())
            {
                var userDTO = _mapper.Map<UserDTO>(user);
                usersDTOs.Add(userDTO);
            }

            return usersDTOs;
        }
    }
}
