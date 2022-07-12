using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace OnlineBooks.Data
{
    public class ModelCreating : IdentityDbContext<IdentityUser>

    {
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
        {
            Id = "44546e06-8719-4ad8-b88a-f271ae9d6eab",
            Name = "admin",
            NormalizedName = "ADMIN"
        });

        modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
        {
            Id = "3b62472e-4f66-49fa-a20f-e7685b9565d8",
            UserName = "admin",
            NormalizedUserName = "ADMIN",
            Email = "my@email.com",
            NormalizedEmail = "MY@EMAIL.COM",
            EmailConfirmed = true,
            PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "superpassword"),
            SecurityStamp = string.Empty
        });

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            RoleId = "44546e06-8719-4ad8-b88a-f271ae9d6eab",
            UserId = "3b62472e-4f66-49fa-a20f-e7685b9565d8"
        });
    }

    }
}
