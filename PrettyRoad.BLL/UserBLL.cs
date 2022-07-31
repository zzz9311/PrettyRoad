using System.Security.Cryptography;
using PrettyRoad.BLL.Interface;
using PrettyRoad.BLL.Interface.Users;
using PrettyRoad.Core.DI;
using PrettyRoad.DAL.Entities;
using PrettyRoad.DAL.Interface;

namespace PrettyRoad.BLL;

public class UserBLL : IUserBLL, ISelfRegistered<IUserBLL>
{
    private readonly IFinder<User> _userFinder;
    private readonly IRepository<User> _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IReadOnlyRepository<User> _userROR;

    public UserBLL(IFinder<User> userFinder, 
                   IRepository<User> userRepository, 
                   IUnitOfWork unitOfWork,
                   IReadOnlyRepository<User> userRor)
    {
        _userFinder = userFinder;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _userROR = userRor;
    }

    public async Task<UserAuthenticateDetails> SignInAsync(string login, string password, CancellationToken cancellationToken = default)
    {
        var user = await _userROR.FindAsync(x => x.Login == login, cancellationToken);

        if (user == null)
        {
            return null;
        }

        var isOk = ValidatePassword(password, user.Password);

        if (!isOk)
        {
            return null;
        }

        return new UserAuthenticateDetails() //TODO automapper
        {
            Login = user.Login,
            ID = user.ID
        };
    }

    public async Task RegisterAsync(string login, string password, CancellationToken cancellationToken = default)
    {
        var user = new User
        {
            Email = "asdasd",
            Login = login,
            Name = "textName",
            Password = HashPassword(password)
        };

        await _userRepository.InsertAsync(user, cancellationToken);
        await _unitOfWork.SaveAsync(cancellationToken);
    }


    private string HashPassword(string password)
    {
        byte[] salt;
        byte[] buffer2;
        
        if (password == null)
        {
            throw new ArgumentNullException(nameof(password));
        }
        
        using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, 0x10, 0x3e8))
        {
            salt = bytes.Salt;
            buffer2 = bytes.GetBytes(0x20);
        }
        
        byte[] dst = new byte[0x31];
        Buffer.BlockCopy(salt, 0, dst, 1, 0x10);
        Buffer.BlockCopy(buffer2, 0, dst, 0x11, 0x20);
        return Convert.ToBase64String(dst);
    }
    
    private bool ValidatePassword(string password, string hashedPassword)
    {
        byte[] buffer4;
        if (hashedPassword == null)
        {
            throw new ArgumentNullException(nameof(hashedPassword));
        }
        
        if (password == null)
        {
            throw new ArgumentNullException(nameof(password));
        }
        
        byte[] src = Convert.FromBase64String(hashedPassword);
        if ((src.Length != 0x31) || (src[0] != 0))
        {
            return false;
        }
        
        byte[] dst = new byte[0x10];
        Buffer.BlockCopy(src, 1, dst, 0, 0x10);
        byte[] buffer3 = new byte[0x20];
        Buffer.BlockCopy(src, 0x11, buffer3, 0, 0x20);
        using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, dst, 0x3e8))
        {
            buffer4 = bytes.GetBytes(0x20);
        }

        return buffer3.SequenceEqual(buffer4);
    }
}