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
            Console.WriteLine("\nWelcome to the casino\nTwo dice will be rolled and you will bet on the outcome\n");
            Console.WriteLine("If you correctly guess doubles, you will earn twice your bet\nThis has a 16.7% chance of happening\n");
            Console.WriteLine("If you correctly guess not doubles, you'll earn half your bet\nThis has a 83.3% chance of happening\n");
            Console.WriteLine("If you correctly guess even sum, you will earn your bet\nThis has a 50% chance of happening\n");
            Console.WriteLine("If you correctly guess odd sum, you will earn your bet\nThis has a 50% chance of happening\n\n");
        }

        static void Main(string[] args)
        {
            bool done = false;
            int bank = 100, bet, diceBet;
            string answer;
            Die die1 = new Die(), die2 = new Die();

            Console.Title = "CASINO GAME";

            Help();

            while (!done)
            {
                Console.WriteLine("To continue press C, \nto see instructions again press H, \nto leave with your earnings press D");
                answer = Console.ReadLine().ToLower();
                Console.Clear();

                if (answer == "c")
                {
                    Console.WriteLine($"How much are you betting?\nYou have {bank.ToString("C")}");

                    while (!Int32.TryParse(Console.ReadLine(), out bet) || !(bet >= 1) || !(bet <= bank))
                        Console.WriteLine("You can't make a bet like that...");

                    Console.WriteLine();
                    Console.WriteLine("What are you betting on?\n 1 - Doubles\n 2 - Not Doubles\n 3 - Even Sum\n 4 - Odd Sum\n");

                    while (!Int32.TryParse(Console.ReadLine(), out diceBet) || !(diceBet >= 1) || !(diceBet <= 4))
                        Console.WriteLine("That's not what I'm looking for...");

                    Console.Clear();

                    die1.RollDie(); die2.RollDie(); die2.RollDie();
                    die1.DrawDie(); System.Threading.Thread.Sleep(100); die2.DrawDie();

                    if (die1.Roll == die2.Roll && diceBet == 1)
                    {
                        bank += bet * 2;
                        Console.WriteLine($"YOU WIN!\nYour new balance is {bank.ToString("C")}\n");
                    }
                    else if (die1.Roll != die2.Roll && diceBet == 2)
                    {
                        bank += bet / 2;
                        Console.WriteLine($"YOU WIN!\nYour new balance is {bank.ToString("C")}\n");
                    }
                    else if ((die1.Roll + die2.Roll) % 2 == 0 && diceBet == 3)
                    {
                        bank += bet;
                        Console.WriteLine($"YOU WIN!\nYour new balance is {bank.ToString("C")}\n");
                    }
                    else if ((die1.Roll + die2.Roll) % 2 != 0 && diceBet == 4)
                    {
                        bank += bet;
                        Console.WriteLine($"YOU WIN!\nYour new balance is {bank.ToString("C")}\n");
                    }
                    else
                    {
                        bank -= bet;
                        Console.WriteLine($"You lost...\nYour new balance is {bank.ToString("C")}\n");

                        if (bank < 1)
                        {
                            Console.WriteLine("I'm sorry, you've gone bankrupt, we have to kick you out.\nCome back when you have more money.");
                            Console.WriteLine($"You cashed out with {bank.ToString("C")}");
                            System.Threading.Thread.Sleep(600);
                            done = true;
                        }
                    }
                }

                else if (answer == "h")
                {
                    Help();
                }

                else if (answer == "d") 
                {
                    Console.WriteLine($"You cashed out with {bank.ToString("C")}");
                    System.Threading.Thread.Sleep(600);
                    done = true;
                }
            }
        }
    }
}
