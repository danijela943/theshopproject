using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheShop.Core.Enums;

namespace TheShop.Core.Models.Results
{
    public class OperationResult<T>
    {
        public bool Success { get; set; }
        public ErrorType ErrorType { get; set; }
        public string ErrorMessage { get; set; }
        public T Result { get; set; }

        public static OperationResult<T> Error(ErrorType type, string message)
        {
            return new OperationResult<T>() { Success = false, ErrorType = type, ErrorMessage = message };
        }

        public static OperationResult<T> OK(T result)
        {
            return new OperationResult<T>() { Success = true, Result = result };
        }
    }
}
