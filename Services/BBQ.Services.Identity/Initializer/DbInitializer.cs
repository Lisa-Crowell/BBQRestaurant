using System.Security.Claims;
using BBQ.Services.Identity.DbContexts;
using BBQ.Services.Identity.Models;
using IdentityModel;
using Microsoft.AspNetCore.Identity;

namespace BBQ.Services.Identity.Initializer;

public class DbInitializer : IDbInitializer
{
    private readonly ApplicationDbContext _db;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly UserManager<ApplicationUser> _userManager;

    public DbInitializer(ApplicationDbContext db, UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole> roleManager)
    {
        _db = db;
        _roleManager = roleManager;
        _userManager = userManager;
    }

    public void Initialize()
    {
        if (_roleManager.FindByNameAsync(SD.Admin).Result == null)
        {
            _roleManager.CreateAsync(new IdentityRole(SD.Admin)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(SD.Customer)).GetAwaiter().GetResult();
        }
        else
        {
            return;
        }

        var adminUser = new ApplicationUser
        {
            UserName = Environment.GetEnvironmentVariable("ADMIN_USERNAME"),
            Email = Environment.GetEnvironmentVariable("ADMIN_EMAIL"),
            EmailConfirmed = true,
            PhoneNumber = Environment.GetEnvironmentVariable("ADMIN_PHONE"),
            FirstName = Environment.GetEnvironmentVariable("ADMIN_FIRSTNAME"),
            LastName = Environment.GetEnvironmentVariable("ADMIN_LASTNAME")
        };

        _userManager.CreateAsync(adminUser, "Admin123*").GetAwaiter().GetResult();
        _userManager.AddToRoleAsync(adminUser, SD.Admin).GetAwaiter().GetResult();

        var temp1 = _userManager.AddClaimsAsync(adminUser, new[]
        {
            new(JwtClaimTypes.Name, adminUser.FirstName + " " + adminUser.LastName),
            new Claim(JwtClaimTypes.GivenName, adminUser.FirstName),
            new Claim(JwtClaimTypes.FamilyName, adminUser.LastName),
            new Claim(JwtClaimTypes.Role, SD.Admin)
        }).Result;

        var customerUser = new ApplicationUser
        {
            UserName = Environment.GetEnvironmentVariable("CUST_USERNAME"),
            Email = Environment.GetEnvironmentVariable("CUST_EMAIL"),
            EmailConfirmed = true,
            PhoneNumber = Environment.GetEnvironmentVariable("CUST_PHONE"),
            FirstName = Environment.GetEnvironmentVariable("CUST_FIRSTNAME"),
            LastName = Environment.GetEnvironmentVariable("CUST_LASTNAME")
        };

        _userManager.CreateAsync(customerUser, "Admin123*").GetAwaiter().GetResult();
        _userManager.AddToRoleAsync(customerUser, SD.Customer).GetAwaiter().GetResult();

        var temp2 = _userManager.AddClaimsAsync(customerUser, new[]
        {
            new(JwtClaimTypes.Name, customerUser.FirstName + " " + customerUser.LastName),
            new Claim(JwtClaimTypes.GivenName, customerUser.FirstName),
            new Claim(JwtClaimTypes.FamilyName, customerUser.LastName),
            new Claim(JwtClaimTypes.Role, SD.Customer)
        }).Result;
    }
}