using MediatR;
using Recipes.Application.Users.Dtos.Auth;

namespace Recipes.Application.Users.Queries.GetMyAuthProfile;
public class GetMyAuthProfileQuery : IRequest<AuthProfileDto>
{

}
