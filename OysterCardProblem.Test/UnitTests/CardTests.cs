using Microsoft.VisualStudio.TestTools.UnitTesting;
using OysterCardProblem.Data.Entities;
using OysterCardProblem.Data.Exceptions;

namespace OysterCardProblem.Test.UnitTests
{
     [TestClass]
     public class CardTests
     {
          [TestMethod]
          [ExpectedException(typeof(FareException), "You don't have enough balance!")]
          public void ShouldThrowValidateException()
          {
               Card card = new Card(30f);
               card.Validate(31);
          }

          [TestMethod]
          [ExpectedException(typeof(FareException), "You don't have enough balance!")]
          public void ShouldThrowOutException()
          {
               Card card = new Card(30f);
               card.Out(31);
          }
     }
}
