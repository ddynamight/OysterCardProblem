using System;
using System.Runtime.Serialization;

namespace OysterCardProblem.Data.Exceptions
{
     public class FareException : Exception
     {
          public FareException()
          {
          }

          public FareException(string message) : base(message)
          {
          }

          public FareException(string message, Exception innerException) : base(message, innerException)
          {
          }

          protected FareException(SerializationInfo info, StreamingContext context)
               : base(info, context)
          {
          }
     }
}
