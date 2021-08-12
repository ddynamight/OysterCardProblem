namespace OysterCardProblem.Data.Entities
{
     public class StationZone
     {
          private readonly string _zone;

          public StationZone(string zone)
          {
               _zone = zone;
          }

          public string GetZone()
          {
               return _zone;
          }
     }
}