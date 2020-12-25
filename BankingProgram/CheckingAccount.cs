using System;
using System.Collections.Generic;
using System.Text;

namespace BankingProgram
{
   class CheckingAccount : Account
   {
      private decimal transactionFee;

      public CheckingAccount(decimal accountBalance, decimal transactionFee) : base(accountBalance)
      {
         TransactionFee = transactionFee;
      }
      public decimal TransactionFee
      {
         get
         {
            return transactionFee;
         }
         set
         {
            if (value < 0)
            {
               throw new ArgumentOutOfRangeException(nameof(value),
                  value, $"{nameof(TransactionFee)} must be >= 0");
            }
            transactionFee = value;
         }
      }
      public override void Credit(decimal value)
      {
         base.Credit(value);
         AccountBalance -= TransactionFee;
      }
      public override void Debit(decimal value)
      {
         if (value < (AccountBalance + TransactionFee))
         {
            base.Debit(value);

            AccountBalance -= TransactionFee;
         }
         else
         {
            throw new ArgumentOutOfRangeException("Cannot withdraw money because it will overdraft the account.");
         }
      }

      public override string ToString()
      {
         return $"The starting account balance is {AccountBalance:C} and the transaction fee is {TransactionFee:C}";
      }
   }
}
