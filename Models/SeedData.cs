using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Bookstore.Areas.Identity.Data;
using Bookstore.Data;

public class SeedData
{
    public static async Task CreateUserRoles(IServiceProvider serviceProvider)
    {
        var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var UserManager = serviceProvider.GetRequiredService<UserManager<BookstoreUser>>();
        string[] roleNames = { "Admin", "User" };
        IdentityResult roleResult;
        //Add Admin Role
        var roleCheck = await RoleManager.RoleExistsAsync("Admin");
        if (!roleCheck) { roleResult = await RoleManager.CreateAsync(new IdentityRole("Admin")); }
        BookstoreUser user = await UserManager.FindByEmailAsync("admin@bookstore.com");
        if (user == null)
        {
            var User = new BookstoreUser();
            User.Email = "admin@bookstore.com";
            User.UserName = "admin@bookstore.com";
            string userPWD = "Admin123";
            IdentityResult chkUser = await UserManager.CreateAsync(User, userPWD);
            //Add default User to Role Admin
            if (chkUser.Succeeded) { await UserManager.AddToRoleAsync(User, "Admin"); }

        }

        var roleCheck1 = await RoleManager.RoleExistsAsync("User");
        if (!roleCheck1) { roleResult = await RoleManager.CreateAsync(new IdentityRole("User")); }
        BookstoreUser user1 = await UserManager.FindByEmailAsync("user@bookstore.com");
        if (user1 == null)
        {
            var User = new BookstoreUser();
            User.Email = "user@bookstore.com";
            User.UserName = "user@bookstore.com";
            string userPWD = "Userr123";
            IdentityResult chkUser = await UserManager.CreateAsync(User, userPWD);
            //Add default User to Role Admin
            if (chkUser.Succeeded) { await UserManager.AddToRoleAsync(User, "User"); }

        }


    }
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new BookstoreContext(
        serviceProvider.GetRequiredService<
        DbContextOptions<BookstoreContext>>()))
        {
            CreateUserRoles(serviceProvider).Wait();

        }
    }
}