using OysterCardProblem.Data.Enums;
using System;

namespace OysterCardProblem.Data.Entities
{
     public class Fare
     {
          public const float ZONE_ONE_FARE = 2.50f;
          public const float ANY_ZONE_OUTSIDE_ZONE_ONE_FARE = 2.00f;
          public const float TWO_ZONES_INC_ZONE_ONE_FARE = 3.00f;
          public const float TWO_ZONES_EXC_ZONE_ONE_FARE = 2.25f;
          public const float THREE_ZONES_FAIR = 3.20f;
          public const float BUS_FARE = 1.80f;
          public const float BASIC_TRAIN_FARE = 3.20f;

          public void Validate(Transport transport, Card card)
          {
               if (transport.Equals(Transport.BUS))
                    card.Validate(BUS_FARE);

               if (transport.Equals(Transport.TRAIN))
                    card.Validate(BASIC_TRAIN_FARE);
          }

          public void ChargeMax(Transport transport, Card card)
          {
               if (transport.Equals(Transport.BUS))
                    card.Out(BUS_FARE);

               if (transport.Equals(Transport.TRAIN))
                    card.Out(BASIC_TRAIN_FARE);
          }

          public void Charge(Transport transport, Trip trip, Card card)
          {
               switch (transport)
               {
                    case Transport.TRAIN:
                    {
                         int count = CountZones(trip);

                         if (IsOneZones(count) && IsZoneTwo(trip))
                         {
                              card.In(BASIC_TRAIN_FARE - ANY_ZONE_OUTSIDE_ZONE_ONE_FARE);
                         }
                         else if (HaveZoneOne(trip) && IsOneZones(count))
                         {
                              card.In(BASIC_TRAIN_FARE - ZONE_ONE_FARE);
                         }
                         else if (!HaveZoneOne(trip) && IsOneZones(count))
                         {
                              card.In(BASIC_TRAIN_FARE - ANY_ZONE_OUTSIDE_ZONE_ONE_FARE);
                         }
                         else if (HaveZoneOne(trip) && IsTwoZones(count))
                         {
                              card.In(BASIC_TRAIN_FARE - TWO_ZONES_INC_ZONE_ONE_FARE);
                         }
                         else if (!HaveZoneOne(trip) && IsTwoZones(count))
                         {
                              card.In(BASIC_TRAIN_FARE - TWO_ZONES_EXC_ZONE_ONE_FARE);
                         }
                         else if (IsThreeZones(count))
                         {
                              card.In(BASIC_TRAIN_FARE - THREE_ZONES_FAIR);
                         }

                         break;
                    }
                    case Transport.BUS:
                         card.In(0f);
                         break;
               }
          }

          private bool IsZoneTwo(Trip trip)
          {
               return trip.GetEndPoint().GetZone().Contains("2") && trip.GetStartPoint().GetZone().Contains("2");
          }

          private int CountZones(Trip trip)
          {
               var zonesStart = trip.GetStartPoint().GetZone().Split(',');
               var zonesEnd = trip.GetEndPoint().GetZone().Split(',');

               int x = 10;

               for (int i = 0; i < zonesStart.Length; i++)
               {
                    for (int j = 0; j < zonesEnd.Length; j++)
                    {
                         int z = int.Parse(zonesStart[i]);
                         int y = int.Parse(zonesEnd[j]);
                         z = Math.Abs(z - y);
                         if (z < x)
                              x = z;
                    }
               }

               return Math.Abs(x);
          }

          private bool IsThreeZones(int count)
          {
               return count == 2;
          }

          private bool IsTwoZones(int count)
          {
               return count == 1;
          }

          private bool IsOneZones(int count)
          {
               return count == 0;
          }

          private bool HaveZoneOne(Trip trip)
          {
               return trip.GetEndPoint().GetZone().Contains("1") || trip.GetStartPoint().GetZone().Contains("1");
          }
     }
}
