using System;


namespace caesar
{
    class Cipher
    {
        static string Encode()
        {
            string a_z = "abcdefghijklmnopqrstuvwxyz";
            string A_Z = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string nums = "0123456789";
            Console.Clear();
            Console.WriteLine("Enter the text to be encoded: ");
            string input = Console.ReadLine();
            Console.WriteLine("Enter the step for cipher: ");
            int step = Convert.ToInt32(Console.ReadLine());
            string encoded = "";
            for(int i = 0;i < input.Length; i++)
            {
                int index;
                if(Char.IsNumber(input[i]))
                {
                    index = nums.IndexOf(input[i]);
                    if(index + step <= 10)
                    {
                        index = index + step;
                        encoded += nums[index];
                    }
                    else
                    {
                        index = (index + step) - 10;
                        encoded += nums[index];
                    }
                }
                else if(Char.IsLower(input[i]))
                {
                    index = a_z.IndexOf(input[i]);
                    if(index+step<=25)
                    {
                        index = index + step;
                        encoded += a_z[index];
                    }
                    else
                    {
                        index = (index + step) - 25;
                        encoded += a_z[index];
                    }
                }
                else
                {
                    index = A_Z.IndexOf(input[i]);
                    if(index + step <=25)
                    {
                        index = index + step;
                        encoded += A_Z[index];
                    }
                    else
                    {
                        index = (index + step) - 25;
                        encoded += A_Z[index];
                    }
                }
            }

            return encoded;

        }

        static string Decode()
        {
            string a_z = "abcdefghijklmnopqrstuvwxyz0123456789";
            string A_Z = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string nums = "0123456789";
            Console.Clear();
            Console.WriteLine("Enter the text to be decoded: ");
            string input = Console.ReadLine();
            Console.WriteLine("Enter the step for decipher: ");
            int step = Convert.ToInt32(Console.ReadLine());
            string decoded = "";
            for (int i = 0; i < input.Length; i++)
            {
                int index;
                if(Char.IsNumber(input[i]))
                {
                    index = nums.IndexOf(input[i]);
                    if(index - step >= 0)
                    {
                        index = index - step;
                        decoded += nums[index];
                    }
                    else
                    {
                        index = 10 - Math.Abs(index - step);
                        decoded += nums[index];
                    }
                }
                else if(Char.IsLower(input[i]))
                {
                    index = a_z.IndexOf(input[i]);
                    if(index - step >= 0)
                    {
                        index = index - step;
                        decoded += a_z[index];
                    }
                    else
                    {
                        index = 25 - Math.Abs(index - step);
                        decoded += a_z[index]; 
                    }
                }
                else
                {
                    index = A_Z.IndexOf(input[i]);
                    if(index - step >= 0)
                    {
                        index = index - step;
                        decoded += A_Z[index];
                    }
                    else
                    {
                        index = 25 - Math.Abs(index - step);
                        decoded += A_Z[index]; 
                    }
                }
            }

            return decoded;
        }

        static void Main(string[] args)
        {
            Console.Write("Choose operation:\n1.Encode\n2.Decode\n:");
            int operation = Convert.ToInt32(Console.ReadLine());
            switch (operation)
            {
                case 1:
                    string encoded = Encode();
                    Console.WriteLine("Your encoded word is: "+encoded);
                    break;
                case 2:
                    string decoded = Decode();
                    Console.WriteLine("Your decoded cipher is: "+decoded);
                    break;
                default:
                    Console.WriteLine("Wrong input :(");
                    break;
            }
            Console.ReadLine();
        }
    }
}