using Microsoft.AspNetCore.Authorization;

namespace Recipes.API.Auth;

public class SelfOrAdminRequirement : IAuthorizationRequirement
{
}
