
using AutoMapper;
using MediatR;
using SimplyKnowHau.Application.DTOs;
using SimplyKnowHau.Domain.Interfaces;

namespace SimplyKnowHau.Application.Queries.GetRoleByIdQuery
{
    public class GetRoleByIdQueryHandler : IRequestHandler<GetRoleByIdQuery, RoleDTO>
    {
        private readonly IMapper _mapper;
        private readonly IRoleRepository _roleRepository;

        public GetRoleByIdQueryHandler(IMapper mapper, IRoleRepository roleRepository)
        {
            _mapper = mapper;
            _roleRepository = roleRepository;
        }
        public async Task<RoleDTO> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<RoleDTO>(await _roleRepository.GetById(request.RoleId));
        }
    }
}
