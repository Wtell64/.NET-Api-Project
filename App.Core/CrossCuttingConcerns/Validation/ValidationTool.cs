using FluentValidation;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.CrossCuttingConcerns.Validation
{
  public static class ValidationTool
  {
  public static void Validate(IValidator validator, object entity)
  {
      var context = new ValidationContext<object>(entity);
      var validationResult = validator.Validate(context);

      if (!validationResult.IsValid)
      {
        throw new FluentValidation.ValidationException(validationResult.Errors);
      }

    }
  }
}
