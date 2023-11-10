using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Utilities.Security.Encryption
{
  public class SigningCredentialsHelper
  {
  //Token yaratirkenki credentialsi yaratiyor
  //hangi anahtar ve hangi algoritma calisicak.
  public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
  {
      return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
  }
  }
}
