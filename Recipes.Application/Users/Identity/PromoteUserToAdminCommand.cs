using MediatR;

namespace Recipes.Application.Users.Identity;
public record PromoteUserToAdminCommand(Guid UserId) : IRequest;
