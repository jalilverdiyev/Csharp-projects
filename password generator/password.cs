using System;

namespace password
{
    class Generator
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            string a_zA_Z = "aAbBcCdDeEfFgGhHiIjJkKlLmMnNoOpPqQrRsStTuUvVwWxXyYzZ";
            string symblos = "0123456789+-/*!@#$%^&(){}[]?,.<>|";
            string password = "";
            int length,option;
            bool is_succeed = false;
            Console.WriteLine("Enter length of the password: ");
            length =  Convert.ToInt32(Console.ReadLine());
            Console.Write("Choose password characters:\n1.Without special\n2.With special\n:");
            option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    for(int i = 0; i < length; i++)
                    {
                        password += a_zA_Z[rnd.Next(0,a_zA_Z.Length - 1)]; 
                    }
                    is_succeed = true;
                    break;
                case 2:
                    string special = symblos + a_zA_Z;
                    for(int i = 0; i < length; i++)
                    {
                        password += special[rnd.Next(0,special.Length - 1)];
                    }
                    is_succeed = true;
                    break;
                default:
                    Console.WriteLine("Err wrong input :(");
                    is_succeed = false;
                    break;
            }
            if (is_succeed)
            {
               Console.WriteLine("Your generated password is: " + password);       
            }
            else
            {
                Console.WriteLine("Unexpected error :(");
            }

        }    
    }    
}