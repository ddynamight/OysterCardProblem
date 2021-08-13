﻿using System;
using OysterCardProblem.Data.Exceptions;

namespace OysterCardProblem.Data.Entities
{
     public class Card
     {
          private float _balance;

          public Guid Id { get; set; } = Guid.NewGuid();
          public string Name { get; set; } = "Ismail Umar";
          public string PhoneNumber { get; set; } = "08035848681";

          public Card(float balance)
          {
               _balance = balance;
          }

          public Card()
          {
               _balance = 0;
          }

          public float GetBalance()
          {
               return _balance;
          }

          public void SetBalance(float balance)
          {
               _balance = balance;
          }

          public void AddMoney(float money)
          {
               _balance = _balance + money;
          }

          public void Out(float fare)
          {
               Validate(fare);
               _balance = _balance - fare;
          }

          public void Validate(float fare)
          {
               if (_balance < fare)
                    throw new FareException("You don't have enough balance!");
          }

          public void In(float f)
          {
               _balance = _balance + f;
          }
     }
}