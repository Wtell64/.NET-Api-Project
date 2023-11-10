using App.Core.Entities.Concrete;
using App.Core.Utilities.Results;
using App.Core.Utilities.Security.JWT;
using App.Entities.DTOs;

namespace App.Business.Abstract
{
  public interface IAuthService
  {
    IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);
    IDataResult<User> Login(UserForLoginDto userForLoginDto);
    IResult UserExists(string email);
    IDataResult<AccessToken> CreateAccessToken(User user);
  }
}
