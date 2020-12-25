using System;
using System.Collections.Generic;
using System.Text;

namespace BankingProgram
{
   class SavingsAccount : Account
   {
      private decimal interestRate;
      public SavingsAccount(decimal accountBalance, decimal interestRate) : base(accountBalance)
      {
         InterestRate = interestRate;
      }

      public decimal InterestRate
      {
         get
         {
            return interestRate;
         }
         set
         {
            if (value < 0 || value >= 1)
            {
               throw new ArgumentOutOfRangeException(nameof(value),
                  value, $"{nameof(InterestRate)} must be between 0 and 1");
            }
            interestRate = value;
         }
      }
      public decimal CalculateInterest()
      {
         return InterestRate * AccountBalance;
      }

      public override string ToString()
      {
         return $"The current account balance for your savings account is {AccountBalance:C} and the interest rate is {InterestRate}%";
      }
   }
}
