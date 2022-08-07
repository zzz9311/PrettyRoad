using FluentValidation;
using PrettyRoad.BLL.FluentValidator;
using PrettyRoad.BLL.Interface.FluentValidator;
using PrettyRoad.Core.Exceptions;
using System;
using Xunit;


namespace PrettyRoad.BLL.Test;

public class UnitTest1
{
    private readonly IFluentValidator<UserEntityTest> _fluentValidator;

    public UnitTest1()
    {
        _fluentValidator = new UserValidatorTest();
    }

    [Fact]
    public void TestNameAndPasswordWithException()
    {
        var user = new UserEntityTest()
        {
            Name = null,
            Password = "123456789101112"
        };

        Assert.Throws<InvalidObjectException>(() => _fluentValidator.ValidateAndThrowException(user));
    }

    [Theory]
    [InlineData(0, "Kolya","1")]
    [InlineData(1, null, "1")]
    [InlineData(2, null, "2123123123123123123")]
    public void TestNameAndPasswordTheory(int expected, string name, string password)
    {
        var user = new UserEntityTest()
        {
            Name = name,
            Password = password
        };

        var a = _fluentValidator.Validate(user);

        Assert.Equal(expected, a.Length);
    }
}
class UserValidatorTest : FluentValidator<UserEntityTest>
{
    protected override void InitializeValidateArguments()
    {
        RuleFor(x => x.Name).NotNull().WithMessage("Name shouldnt be null");
        RuleFor(x => x.Password).Length(0, 10);
    }
}

public class UserEntityTest
{
    public Guid ID { get; set; }
    public string Name { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
}