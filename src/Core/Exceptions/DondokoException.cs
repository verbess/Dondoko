using System;
using System.Runtime.Serialization;

namespace Dondoko
{
    [Serializable]
    public class DondokoException : Exception
    {
        public DondokoException() : base(SR.Dondoko_FrameworkException) { }

        public DondokoException(string? message) : base(message) { }

        public DondokoException(string? message, Exception? innerException) : base(message, innerException) { }

        protected DondokoException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}