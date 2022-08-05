using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrettyRoad.BLL.Interface.FluentValidator
{
    public interface IFluentValidator<T> where T:class
    {
        ValidateErrorsInfo[] Validate(T validateObject);
        Task<ValidateErrorsInfo[]> ValidateAsync(T validateObject, CancellationToken cancellationToken = default);
    }
}
