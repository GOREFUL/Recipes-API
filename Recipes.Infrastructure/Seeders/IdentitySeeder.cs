using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Recipes.Domain.Entities.UserContext;

namespace Recipes.Infrastructure.Seeders;
public static class IdentitySeeder
{
    public static async Task SeedRolesAsync(this IServiceProvider sp)
    {
        using var scope = sp.CreateScope();
        var roles = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

        const string admin = "Admin";
        if (!await roles.RoleExistsAsync(admin))
        {
            var role = new IdentityRole<Guid>(admin) { NormalizedName = admin.ToUpperInvariant() };
            var res = await roles.CreateAsync(role);
            if (!res.Succeeded) throw new Exception($"Failed to create role {admin}: " + string.Join("; ", res.Errors.Select(e => e.Description)));
        }
    }

    public static async Task SeedAdminUserAsync(this IServiceProvider sp, string email, string password)
    {
        using var scope = sp.CreateScope();
        var users = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        var roles = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

        var user = await users.FindByEmailAsync(email);
        if (user is null)
        {
            user = new ApplicationUser { UserName = email, Email = email, EmailConfirmed = true, DisplayName = "admin" };
            var create = await users.CreateAsync(user, password);
            if (!create.Succeeded) throw new Exception("Failed to create admin user: " + string.Join("; ", create.Errors.Select(e => e.Description)));
        }

        if (!await users.IsInRoleAsync(user, "Admin"))
        {
            var add = await users.AddToRoleAsync(user, "Admin");
            if (!add.Succeeded) throw new Exception("Failed to add Admin role: " + string.Join("; ", add.Errors.Select(e => e.Description)));
        }
    }
}