using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interest_Calculator
{
    internal class Program
    {
        public static decimal CalculateBalance(decimal deposit, decimal interestRate, int numberOfYears)
        {
            decimal balance = 0;
            decimal interest = 0;

            for (int year = 1; year <= numberOfYears; year++)
            {
                interest = (deposit + balance) * (interestRate / 100);
                balance = balance + deposit + interest;
            }

            return balance;
        }
        static void Main(string[] args)
        {

            Console.Write("Enter the annual deposit: ");
            decimal annualDeposit = decimal.Parse(Console.ReadLine());

            Console.Write("Enter the interest rate (%): ");
            decimal interestRate = decimal.Parse(Console.ReadLine());

            Console.Write("Enter the number of years: ");
            int numberOfYears = int.Parse(Console.ReadLine());

            decimal finalBalance = CalculateBalance(annualDeposit, interestRate, numberOfYears);
            Console.WriteLine($"Final balance after {numberOfYears} years: €{finalBalance:F2}");
            Console.ReadLine();

        }
    }
}
