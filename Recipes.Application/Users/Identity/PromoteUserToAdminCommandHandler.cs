using MediatR;
using Microsoft.AspNetCore.Identity;
using Recipes.Domain.Entities.UserContext;
using Recipes.Domain.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace Recipes.Application.Users.Identity;
public class PromoteUserToAdminCommandHandler(UserManager<ApplicationUser> users) 
    : IRequestHandler<PromoteUserToAdminCommand>
{
    public async Task Handle(PromoteUserToAdminCommand r, CancellationToken ct)
    {
        var user = await users.FindByIdAsync(r.UserId.ToString());
        if (user is null)
            throw new ValidationException($"User with ID {r.UserId} not found.");

        if (!await users.IsInRoleAsync(user, "Admin"))
        {
            var res = await users.AddToRoleAsync(user, "Admin");
            if (!res.Succeeded) throw new ValidationException(string.Join("; ", res.Errors.Select(e => e.Description)));
        }
    }
}