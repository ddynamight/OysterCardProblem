using System;
using System.Runtime.Serialization;

namespace OysterCardProblem.Data.Exceptions
{
     public class TripException : Exception
     {
          public TripException()
          {
          }

          public TripException(string message) : base(message)
          {
          }

          public TripException(string message, Exception innerException) : base(message, innerException)
          {
          }

          protected TripException(SerializationInfo info, StreamingContext context)
               : base(info, context)
          {
          }
     }
}
