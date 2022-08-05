using FluentValidation;
using FluentValidation.Results;
using PrettyRoad.BLL.Interface.FluentValidator;
using PrettyRoad.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrettyRoad.BLL.FluentValidator
{
    public abstract class FluentValidator<T> : AbstractValidator<T>, IFluentValidator<T> where T : class
    {

        protected bool IsInit { get; private set; }
        public abstract void InitializeValidateArguments();

        private void InitIfNeed()
        {
            if (!IsInit)
            {
                InitializeValidateArguments();
                IsInit = true;
            }
        }

        public ValidateErrorsInfo[] Validate(T validateObject)
        {
            InitIfNeed();
            var errors = base.Validate(validateObject).Errors;

            return MapErrors(errors);
        }

        public async Task<ValidateErrorsInfo[]> ValidateAsync(T validateObject, CancellationToken cancellationToken)
        {
            InitIfNeed();
            var errors = (await base.ValidateAsync(validateObject, cancellationToken)).Errors;
            return MapErrors(errors);
        }

        private ValidateErrorsInfo[] MapErrors(List<ValidationFailure> errors)
        {
            return errors.Select(x => new ValidateErrorsInfo 
            { 
                ErrorMessage = x.ErrorMessage, 
                Property = x.PropertyName 
            }).ToArray();
        }

        public void ValidateAndThrowException(T validateObject)
        {
            var errors = Validate(validateObject);

            if(errors.Any())
            {
                throw new InvalidObjectException(string.Join("\n", errors.Select(x => x.ErrorMessage)));
            }
        }
    }
}
