using System;

namespace guess
{

    class Program
    {
        static void Main(string[] args)
        {
            bool guessed = false;
            Random rnd = new Random();
            int number = rnd.Next(0,100); 
            Console.WriteLine("I guessed a number between 0 and 100 try to find it. I will tell warm or cold");
            while(!guessed)
            {
                Console.WriteLine("Go on: ");
                int guessing = Convert.ToInt32(Console.ReadLine());
                if(guessing == number)
                {
                    Console.WriteLine("Congratulations you found the number!");
                    guessed = true;
                    break;
                }
                if(Math.Abs(guessing - number)<=5)
                {
                    Console.WriteLine("Too warm");
                }
                else if(Math.Abs(guessing - number)>=40)
                {
                    Console.WriteLine("Too cold");
                }
                else if(Math.Abs(guessing - number)<=10)
                {
                    Console.WriteLine("Warm");
                }
                else
                {
                    Console.WriteLine("Cold");
                }
            }

            Console.ReadLine();
        }
    }
}