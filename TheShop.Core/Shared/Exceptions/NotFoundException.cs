using System;

namespace TheShop.Core.Shared.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base($"Element not found: ${message}.")
        {

        }

        protected NotFoundException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context)
        {

        }

        public NotFoundException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
