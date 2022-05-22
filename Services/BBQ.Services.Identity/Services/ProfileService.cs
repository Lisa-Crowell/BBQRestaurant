﻿using System.Security.Claims;
using BBQ.Services.Identity.Models;
using Duende.IdentityServer.Extensions;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;
using IdentityModel;
using Microsoft.AspNetCore.Identity;

namespace BBQ.Services.Identity.Services;

public class ProfileService : IProfileService
{
    private readonly RoleManager<IdentityRole> _roleMgr;

    private readonly IUserClaimsPrincipalFactory<ApplicationUser> _userClaimsPrincipalFactory;
    private readonly UserManager<ApplicationUser> _userMgr;

    public ProfileService(
        UserManager<ApplicationUser> userMgr,
        RoleManager<IdentityRole> roleMgr,
        IUserClaimsPrincipalFactory<ApplicationUser> userClaimsPrincipalFactory)
    {
        _userMgr = userMgr;
        _roleMgr = roleMgr;
        _userClaimsPrincipalFactory = userClaimsPrincipalFactory;
    }

    public async Task GetProfileDataAsync(ProfileDataRequestContext context)
    {
        var sub = context.Subject.GetSubjectId();
        var user = await _userMgr.FindByIdAsync(sub);
        var userClaims = await _userClaimsPrincipalFactory.CreateAsync(user);


        var claims = userClaims.Claims.ToList();
        claims = claims.Where(claim => context.RequestedClaimTypes.Contains(claim.Type)).ToList();
        claims.Add(new Claim(JwtClaimTypes.FamilyName, user.LastName));
        claims.Add(new Claim(JwtClaimTypes.GivenName, user.FirstName));
        if (_userMgr.SupportsUserRole)
        {
            IList<string> roles = await _userMgr.GetRolesAsync(user);
            foreach (var rolename in roles)
            {
                claims.Add(new Claim(JwtClaimTypes.Role, rolename));
                if (_roleMgr.SupportsRoleClaims)
                {
                    var role = await _roleMgr.FindByNameAsync(rolename);
                    if (role != null) claims.AddRange(await _roleMgr.GetClaimsAsync(role));
                }
            }
        }

        context.IssuedClaims = claims;
    }

    public async Task IsActiveAsync(IsActiveContext context)
    {
        var sub = context.Subject.GetSubjectId();
        var user = await _userMgr.FindByIdAsync(sub);
        context.IsActive = user != null;
    }
}