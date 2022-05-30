using BBQ.Services.Identity.Models;
using Duende.IdentityServer.Services;
using Microsoft.AspNetCore.Identity;
using Moq;
using NUnit.Framework;

namespace BBQ.Services.Identity;

[TestFixture]
public class ProfileServiceTests
{
    private Mock<IProfileService> _profileServiceMock;
    private Mock<ApplicationUser> _userMgr;
    private Mock<IdentityRole> _roleMgr;
    private Mock<IUserClaimsPrincipalFactory<ApplicationUser>> userClaimsPrincipalFactory;
    private bool x;

    [SetUp]
    public void Setup()
    {
        _profileServiceMock = new Mock<IProfileService>();

        x = true;
    }

    [Test]
    public void TestOne()
    {
        Assert.That(x == true);
    }
}