using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BTI_1
{
    class Program
    {
        public static string Encipher(string input, int key)
        {
            string output = string.Empty;

            foreach (char k in input)
                output += cipher(k, key);
            return output;
        }

        public static char cipher(char k, int key)
        {
            if (!char.IsLetter(k))
            {
                return k;
            }

            char d = char.IsUpper(k) ? 'A' : 'a';
            return (char)((((k + key) - d) % 26) + d);
        }
       
        public static string Decipher(string input, int key)
        {
            return Encipher(input, 26 - key);
        }
        static void Main(string[] args)
        {
            while (true)
            {
                bool condition = false;
                bool condition2 = false;

                string UserString = "";

                while (!condition2)
                {
                    Console.Write("Wpisz słowo do zaszyfrowania bez znaków polskich: ");
                    UserString = Console.ReadLine();

                    if (String.IsNullOrEmpty(UserString))
                    {
                        Console.WriteLine("Musisz wpisać słowo/litery!");
                    }

                    else
                    {
                        condition2 = true;
                    }
                }

                while (!condition)
                {

                    Console.Write("O ile przesunąć litery: ");
                    int key;
                    var inputKey = Console.ReadLine();
                    bool success = Int32.TryParse(inputKey, out key);

                    if (success)
                    {
                        Console.Write("Zaszyforwane słowo: ");
                        string cipherText = Encipher(UserString, key);
                        Console.WriteLine(cipherText);
                        Console.Write("Odszyfrowane słowo: ");
                        string t = Decipher(cipherText, key);
                        Console.WriteLine(t);
                        condition = true;
                    }

                    else
                    {
                        Console.WriteLine("Wpisz liczbę!");
                    }
                }
                Console.ReadKey();
            }
        }
    }
}
