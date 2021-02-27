using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeAreWuunder.Api.Validators
{
    /// <summary>
    /// //Because Wuunder one returns one error at a time, this is a quicker validation check during development
    /// </summary>
    public class CreateShipmentRequestValidator : FluentValidation.AbstractValidator<Requests.CreateShipmentRequest>
    {
        public CreateShipmentRequestValidator()
        {
       
            RuleFor(s => s).Must((rootObject, list, context) => {
                var results = new List<ValidationResult>();
                var isValid = Validator.TryValidateObject(rootObject, new ValidationContext(rootObject), results, true);
                var errorLines = results.Select(dl => $"{string.Join(",", dl.MemberNames)} - {dl.ErrorMessage}").ToList();
                context.MessageFormatter.AppendArgument("ErrorMessage", string.Join("\n", errorLines));
                return isValid;
            })
            .WithMessage("Prevalidation failed : {ErrorMessage}");
            
            RuleFor(s => s.PreferredServiceLevel)
              .Must(x => Models.Constants.ShippingServiceLevels.Contains(x) )
              .WithMessage("{PropertyName} not available");

            RuleFor(s => s.Kind)
                .Must(x => Models.Constants.Kinds.Contains(x))
                .WithMessage("{PropertyName} must be one of the following : " + string.Join(",", Models.Constants.Kinds));

            RuleFor(s => s.NumberOfItems).GreaterThan(0);
            RuleFor(s => s.Length).GreaterThan(0);
            RuleFor(s => s.Width).GreaterThan(0);
            RuleFor(s => s.Height).GreaterThan(0);
            RuleFor(s => s.Weight).GreaterThan(0);  

        }

        public bool ValidateModel(Requests.CreateShipmentRequest request)
        {
            var results = new List<ValidationResult>();
           var isValid =  Validator.TryValidateObject(request , new ValidationContext(request) , results, true);
            return isValid;
        }

        static bool Validate<T>(T obj, out ICollection<ValidationResult> results)
        {
            results = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, new ValidationContext(obj), results, true);
        }
    }
}
