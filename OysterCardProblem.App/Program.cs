using OysterCardProblem.Data.Entities;
using OysterCardProblem.Data.Enums;
using System;

namespace OysterCardProblem.App
{
     class Program
     {
          static void Main(string[] args)
          {
               Card card = new Card();
               card.Name = "Duran Ismail";
               Console.WriteLine("Recharging a card with £30 \n");
               card.AddMoney(30);

               Console.WriteLine($"Hello {card.Name}, Your Balance for Card with ID {card.Id} now is {card.GetBalance()} \n");

               Trip tripHolbornToCourt = new Trip(new Fare());
               tripHolbornToCourt.SetStartPoint(Transport.TRAIN, new StationZone(Station.Holborn), card);
               tripHolbornToCourt.SetEndPoint(new StationZone(Station.EarlsCourt));

               Console.WriteLine($"Hi {card.Name}, Your card balance after first trip (Train Holborn to Earl’s Court)  is £{card.GetBalance()} \n");

               Trip tripBusEarlToChelsea = new Trip(new Fare());
               tripBusEarlToChelsea.SetStartPoint(Transport.BUS, null, card);
               tripBusEarlToChelsea.SetEndPoint(null);

               Console.WriteLine($"Hi {card.Name}, Your card balance after second trip (328 bus from Earl’s Court to Chelsea) is £{card.GetBalance()} \n");

               Trip tripEarlsToHammersmith = new Trip(new Fare());
               tripEarlsToHammersmith.SetStartPoint(Transport.TRAIN, new StationZone(Station.EarlsCourt), card);
               tripEarlsToHammersmith.SetEndPoint(new StationZone(Station.Hammersmith));

               Console.WriteLine($"Hi {card.Name}, Your card balance after third trip (Train Earl’s court to Hammersmith) is £{card.GetBalance()} \n");
               Console.ReadLine();
          }
     }
}
