using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Summative_Casino_Game
{
    internal class Program
    {
        public static void Help()
        {
            Console.WriteLine("Welcome to the casino\nTwo dice will be rolled and you will bet on the outcome\n");
            Console.WriteLine("If you correctly guess doubles, you will earn twice your bet\nThis has a 16.7% chance of happening\n");
            Console.WriteLine("If you correctly guess not doubles, you'll earn half your bet\nThis has a 83.3% chance of happening\n");
            Console.WriteLine("If you correctly guess even sum, you will earn your bet\nThis has a 50% chance of happening\n");
            Console.WriteLine("If you correctly guess odd sum, you will earn your bet\nThis has a 50% chance of happening\n");
        }

        static void Main(string[] args)
        {
            bool done = false;
            int bank = 100;
            string answer;

            Help();

            while (!done)
            {
                
            }
        }
    }
}
