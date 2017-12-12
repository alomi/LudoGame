using System;

namespace Ludo.LogicLayer
{
    static class Util
    {
        internal static void Print(string s)
        {
            Console.Write(s);
        }

        internal static void Print(int i)
        {
            Console.Write(i);
        }

        internal static void Println(string s)
        {
            Console.WriteLine(s);
        }

        internal static void Println(bool b)
        {
            if (b == true)
            {
                Println("true");
            }
            else
            {
                Println("false");
            }
        }

        internal static void Print(bool b)
        {
            if (b == true)
            {
                Print("true");
            }
            else
            {
                Print("false");
            }
        }

        internal static void Println(int i)
        {
            Console.WriteLine(i);
        }

        internal static int ReadInt()
        {
            return Convert.ToInt32(Console.ReadLine());
        }

        internal static string ReadLine()
        {
            return Console.ReadLine();
        }

        internal static void Exit()
        {
            Environment.Exit(0);
        }

        internal static void NewLine(int lines)
        {
            for (int i = 0; i < lines; i++)
            {
                Console.WriteLine();
            }

        }

        internal static void NewLine()
        {
            Console.WriteLine();
        }
    }
}
