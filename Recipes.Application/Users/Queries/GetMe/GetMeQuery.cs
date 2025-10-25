using MediatR;
using Recipes.Application.Users.Dtos;

namespace Recipes.Application.Users.Queries.GetMe;
public class GetMeQuery : IRequest<UserDto>
{

}
