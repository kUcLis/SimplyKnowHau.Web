using MediatR;
using SimplyKnowHau.Application.AuthenticateModels;

namespace SimplyKnowHau.Application.Queries.AuthenticateUserQuery
{
    public class AuthenticateUserQuery : AuthenticateRequest, IRequest<AuthenticateResponse>
    {
    }
}
