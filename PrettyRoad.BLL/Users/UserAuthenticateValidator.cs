using FluentValidation;
using PrettyRoad.BLL.FluentValidator;
using PrettyRoad.BLL.Interface.FluentValidator;
using PrettyRoad.Core.DI;
using PrettyRoad.DAL.Entities;

namespace PrettyRoad.BLL.Users;

public class UserAuthenticateValidator : FluentValidator<User>, ISelfRegistered<IFluentValidator<User>>
{
    protected override void InitializeValidateArguments()
    {
        RuleFor(x => x.Email).NotNull().WithMessage("Test");
    }
}