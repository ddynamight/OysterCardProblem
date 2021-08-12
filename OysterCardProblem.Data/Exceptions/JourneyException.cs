using System;
using System.Runtime.Serialization;

namespace OysterCardProblem.Data.Exceptions
{
     public class JourneyException : Exception
     {
          public JourneyException()
          {
          }

          public JourneyException(string message) : base(message)
          {
          }

          public JourneyException(string message, Exception innerException) : base(message, innerException)
          {
          }

          protected JourneyException(SerializationInfo info, StreamingContext context)
               : base(info, context)
          {
          }
     }
}
