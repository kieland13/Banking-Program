using System;
using System.Collections.Generic;
using System.Text;

namespace BankingProgram
{
   public class Account
   {
      private decimal accountBalance;

      public Account(decimal accountBalance)
      {
         AccountBalance = accountBalance;
      }

      public decimal AccountBalance
      {
         get
         {
            return accountBalance;
         }
         set
         {
            if (value < 0)
            {
               throw new ArgumentOutOfRangeException(nameof(value),
                  value, $"{nameof(AccountBalance)} must be >= 0");
            }
            accountBalance = value;
         }
      }

      public virtual void Debit(decimal value)
      {
         if (value < 0)
         {
            throw new ArgumentOutOfRangeException("Cannot withdraw negative amount.");
         }
         else
         {
            AccountBalance -= value;
         }
      }

      public virtual void Credit(decimal value)
      {
         if (value < 0)
         {
            throw new ArgumentOutOfRangeException("Cannot deposit a number that is negative.");
         }
         else
         {
            AccountBalance += value;
         }
      }
      public override string ToString()
      {
         return $"Your starting balance is: {AccountBalance}";
      }

   }
}
