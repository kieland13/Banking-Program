using System;

namespace BankingProgram
{
   class Program
   {
      static void Main(string[] args)
      {
         decimal interest = 0;
         try
         {
            Account[] account = new Account[6];
            account[0] = new SavingsAccount(250, .03M);
            account[1] = new CheckingAccount(500, 5.00M);
            account[2] = new SavingsAccount(750, .05M);
            account[3] = new CheckingAccount(1000, 10.00M);
            account[4] = new SavingsAccount(1250, .04M);
            account[5] = new CheckingAccount(1500, 15.00M);



            foreach (Account a in account)
            {
               Console.WriteLine(a);
               Console.WriteLine("Would you like to deposit or withdraw from this account? (1 for deposit, 2 for withdraw)");
               int option = Convert.ToInt32(Console.ReadLine());

               while (option < 1 || option > 2)
               {
                  Console.WriteLine("Please choose either 1 for deposit or 2 for withdrawal.");
                  option = Convert.ToInt32(Console.ReadLine());
               }
               if (option == 1)
               {
                  Console.WriteLine("How much would you like to deposit?");
                  int deposit = Convert.ToInt32(Console.ReadLine());

                  while (deposit <= 0)
                  {
                     Console.WriteLine("Must deposit positive amount");
                     deposit = Convert.ToInt32(Console.ReadLine());
                  }
                  if (a is SavingsAccount)
                  {
                     a.Credit(deposit);
                     interest = ((SavingsAccount)a).CalculateInterest();
                     a.Credit(interest);
                  }
                  else
                  {
                     a.Credit(deposit);
                  }
                  Console.WriteLine(a);
               }
               if (option == 2)
               {
                  Console.WriteLine("How much would you like to withdrawal?");
                  int withdrawal = Convert.ToInt32(Console.ReadLine());

                  while (withdrawal < 0)
                  {
                     Console.WriteLine("Must withdraw positive amount");
                     withdrawal = Convert.ToInt32(Console.ReadLine());
                  }
                  if (a is SavingsAccount)
                  {
                     a.Debit(withdrawal);
                     interest = ((SavingsAccount)a).CalculateInterest();
                     a.Debit(interest);
                  }
                  else
                  {
                     a.Debit(withdrawal);
                  }
                  Console.WriteLine(a);
               }
            }

         }

         catch (ArgumentOutOfRangeException ex)
         {
            Console.WriteLine(ex.Message);
         }

         Console.ReadKey();
      }

   }
}
