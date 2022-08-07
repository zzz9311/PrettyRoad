using PrettyRoad.BLL.Interface.Users;
using PrettyRoad.Core.DI;

namespace PrettyRoad.BLL.Interface;

public interface IUserBLL
{
    Task<UserAuthenticateDetails> SignInAsync(string login, string password, CancellationToken cancellationToken = default);
    Task RegisterAsync(string login, string password, CancellationToken cancellationToken = default);
    Task<UserInfoDetails> FindUserAsync(Guid userID, CancellationToken cancellationToken = default);
}