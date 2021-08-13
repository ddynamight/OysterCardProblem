using Microsoft.VisualStudio.TestTools.UnitTesting;
using OysterCardProblem.Data.Entities;
using OysterCardProblem.Data.Enums;
using OysterCardProblem.Data.Exceptions;

namespace OysterCardProblem.Test.UnitTests
{
     [TestClass]
     public class FareTests
     {
          [TestMethod]
          [ExpectedException(typeof(FareException), "You don't have enough balance!")]
          public void ShouldThrowValidateBusFareException()
          {
               Card card = new Card(Fare.BUS_FARE - 1f);
               Fare fare = new Fare();
               fare.Validate(Transport.BUS, card);
          }

          [TestMethod]
          [ExpectedException(typeof(FareException), "You don't have enough balance!")]
          public void ShouldValidateTrainFareException()
          {

               Card card = new Card(Fare.BASIC_TRAIN_FARE - 1f);
               Fare fare = new Fare();
               fare.Validate(Transport.TRAIN, card);
          }

          [TestMethod]
          public void TestChargeMaxTrain()
          {
               Card card = new Card(Fare.BASIC_TRAIN_FARE);
               Fare fare = new Fare();
               fare.ChargeMax(Transport.TRAIN, card);
               Assert.AreEqual(0f, card.GetBalance());
          }

          [TestMethod]
          public void ShouldChargeMaxBus()
          {
               Card card = new Card(Fare.BUS_FARE);
               Fare fare = new Fare();
               fare.ChargeMax(Transport.BUS, card);
               Assert.AreEqual(0f, card.GetBalance());
          }

          [TestMethod]
          public void ShouldChargeBus()
          {
               Card card = new Card(Fare.BUS_FARE);
               Fare fare = new Fare();
               Trip tripBusEarlToChelsea = new Trip(fare);
               tripBusEarlToChelsea.SetStartPoint(Transport.BUS, null, card);
               tripBusEarlToChelsea.SetEndPoint(null);
               fare.Charge(Transport.BUS, tripBusEarlToChelsea, card);
               Assert.AreEqual(0f, card.GetBalance());
          }

          [TestMethod]
          public void ShouldChargeTrainZoneOne()
          {
               Card card = new Card(Fare.BASIC_TRAIN_FARE);
               Fare fare = new Fare();
               Trip tripBusEarlToChelsea = new Trip(fare);
               tripBusEarlToChelsea.SetStartPoint(Transport.TRAIN, new StationZone(Station.Holborn), card);
               tripBusEarlToChelsea.SetEndPoint(new StationZone(Station.EarlsCourt));
               Assert.AreEqual(Fare.BASIC_TRAIN_FARE - Fare.ZONE_ONE_FARE, card.GetBalance());
          }

          [TestMethod]
          public void ShouldChargeTrainAnyZoneOutSideZoneOne()
          {
               Card card = new Card(Fare.BASIC_TRAIN_FARE);
               Fare fare = new Fare();
               Trip tripBusEarlToChelsea = new Trip(fare);
               tripBusEarlToChelsea.SetStartPoint(Transport.TRAIN, new StationZone(Station.Hammersmith), card);
               tripBusEarlToChelsea.SetEndPoint(new StationZone(Station.EarlsCourt));
               Assert.AreEqual(Fare.BASIC_TRAIN_FARE - Fare.ANY_ZONE_OUTSIDE_ZONE_ONE_FARE, card.GetBalance());
          }

          [TestMethod]
          public void ShouldChargeTrainTwoInZoneOne()
          {
               Card card = new Card(Fare.BASIC_TRAIN_FARE);
               Fare fare = new Fare();
               Trip tripBusEarlToChelsea = new Trip(fare);
               tripBusEarlToChelsea.SetStartPoint(Transport.TRAIN, new StationZone(Station.Hammersmith), card);
               tripBusEarlToChelsea.SetEndPoint(new StationZone(Station.Holborn));
               Assert.AreEqual(Fare.BASIC_TRAIN_FARE - Fare.TWO_ZONES_INC_ZONE_ONE_FARE, card.GetBalance());
          }

          [TestMethod]
          public void ShouldChargeTrainTwoExcludingZoneOne()
          {
               Card card = new Card(Fare.BASIC_TRAIN_FARE);
               Fare fare = new Fare();
               Trip tripBusEarlToChelsea = new Trip(fare);
               tripBusEarlToChelsea.SetStartPoint(Transport.TRAIN, new StationZone(Station.Hammersmith), card);
               tripBusEarlToChelsea.SetEndPoint(new StationZone(Station.Wimbledon));
               Assert.AreEqual(Fare.BASIC_TRAIN_FARE - Fare.TWO_ZONES_EXC_ZONE_ONE_FARE, card.GetBalance());
          }

          [TestMethod]
          public void ShouldChargeTrainThreeZones()
          {
               Card card = new Card(Fare.BASIC_TRAIN_FARE);
               Fare fare = new Fare();
               Trip tripBusEarlToChelsea = new Trip(fare);
               tripBusEarlToChelsea.SetStartPoint(Transport.TRAIN, new StationZone(Station.Holborn), card);
               tripBusEarlToChelsea.SetEndPoint(new StationZone(Station.Wimbledon));
               Assert.AreEqual(Fare.BASIC_TRAIN_FARE - Fare.THREE_ZONES_FAIR, card.GetBalance());
          }

          [TestMethod]
          public void ShouldCheckBalanceAfterTrip()
          {
               Card card = new Card(Fare.BASIC_TRAIN_FARE);
               Fare fare = new Fare();
               Trip tripBusEarlToChelsea = new Trip(fare);
               tripBusEarlToChelsea.SetStartPoint(Transport.TRAIN, new StationZone(Station.Holborn), card);
               tripBusEarlToChelsea.SetEndPoint(new StationZone(Station.Wimbledon));
               Assert.AreEqual(Fare.BASIC_TRAIN_FARE - Fare.THREE_ZONES_FAIR, card.GetBalance());
          }
     }
}
