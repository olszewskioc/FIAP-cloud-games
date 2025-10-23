using FCG.Shared.Dtos;
using FCG.Tests._Common.Builders.Auth;
using FCG.Tests._Common.Fixtures;
using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FCG.Tests.Features.Auth;

public class UserRegisterTests : IClassFixture<EfInMemoryMultiContextFixture>
{
    private readonly UserManager<IdentityUser> _userManager;

    public UserRegisterTests(EfInMemoryMultiContextFixture db)
    {
        // Simulate UserManager with InMemory Identity store
        var options = new DbContextOptionsBuilder<IdentityDbContext>()
            .UseInMemoryDatabase("identity-tests")
            .Options;

        var context = new IdentityDbContext(options);

        var store = new UserStore<IdentityUser>(context);
        var passwordHasher = new PasswordHasher<IdentityUser>();

        _userManager = new UserManager<IdentityUser>(
            store,
            null,
            passwordHasher,
            [],
            [new PasswordValidator<IdentityUser>()],
            new UpperInvariantLookupNormalizer(),
            new IdentityErrorDescriber(),
            null,
            null
        );
    }

    [Fact(DisplayName = "Should register user successfully with valid data")]
    public async Task Should_Register_User_Successfully()
    {
        // Arrange
        var dto = new UserRegisterBuilder().Build();
        var user = new IdentityUser { UserName = dto.Email, Email = dto.Email };

        // Act
        var result = await _userManager.CreateAsync(user, dto.Senha);

        // Assert
        result.Succeeded.Should().BeTrue("a valid user should be registered");
        (await _userManager.FindByEmailAsync(dto.Email)).Should().NotBeNull();
    }

    [Fact(DisplayName = "Should fail when registering user with weak password")]
    public async Task Should_Fail_Weak_Password()
    {
        var dto = new UserRegisterBuilder().Invalid_ShortPassword().Build();
        var user = new IdentityUser { UserName = dto.Email, Email = dto.Email };

        var result = await _userManager.CreateAsync(user, dto.Senha);

        result.Succeeded.Should().BeFalse();
        result.Errors.Should().Contain(e => e.Description.Contains("Passwords must be at least"));
    }

    [Fact(DisplayName = "Should fail when registering user with invalid email")]
    public async Task Should_Fail_Invalid_Email()
    {
        var dto = new UserRegisterBuilder().Invalid_EmailFormat().Build();
        var user = new IdentityUser { UserName = dto.Email, Email = dto.Email };

        var result = await _userManager.CreateAsync(user, dto.Senha);

        result.Succeeded.Should().BeFalse();
        result.Errors.Should().NotBeNull();
    }

    [Fact(DisplayName = "Should fail when email already exists")]
    public async Task Should_Fail_When_Email_Already_Exists()
    {
        // Arrange
        var dto = new UserRegisterBuilder().Build();
        var user = new IdentityUser { UserName = dto.Email, Email = dto.Email };
        await _userManager.CreateAsync(user, dto.Senha);

        // Act
        var duplicate = new IdentityUser { UserName = dto.Email, Email = dto.Email };
        var result = await _userManager.CreateAsync(duplicate, dto.Senha);

        // Assert
        result.Succeeded.Should().BeFalse();
        result.Errors.Should().Contain(e => e.Description.Contains("is already taken"));
    }
}
