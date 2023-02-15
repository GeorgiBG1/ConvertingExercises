using System.Net;

namespace ConvertingExercises
{
    public class Program
    {
        static void Main(string[] args)
        {
            Converting converting = new Converting();
            while (true)
            {
                int input = 0;
                Console.WriteLine("Choose between option\n" +
                    "1 => Convert decimal to binary,\n" +
                    "2 => Convert binary to decimal,\n" +
                    "3 => Convert decinal to hexadecimal,\n" +
                    "4 => Convert hexadecimal to decimal;\n");
                try { input = int.Parse(Console.ReadLine()!); }
                catch (FormatException mes)
                { Console.WriteLine(mes); }
                if (input == 1)
                {
                    Console.Write("Enter value: ");
                    int input2 = int.Parse(Console.ReadLine()!);
                    string result = converting.ConvertDecimalToBinary(input2);
                    Console.WriteLine($"Result: {result}\n");
                }
                else if (input == 2)
                {
                    Console.Write("Enter value: ");
                    string input2 = Console.ReadLine()!;
                    int result = converting.ConvertBinaryToDecimal(input2);
                    Console.WriteLine($"Result: {result}\n");
                }
                else if (input == 3)
                {
                    Console.Write("Enter value: ");
                    int input2 = int.Parse(Console.ReadLine()!);
                    string result = converting.ConvertDecimalToHexaDecimal(input2);
                    Console.WriteLine($"Result: {result}\n");
                }
                else if (input == 4)
                {
                    Console.Write("Enter value: ");
                    string input2 = Console.ReadLine()!;
                    int result = converting.ConvertingHexaDecimalToDecimal(input2);
                    Console.WriteLine($"Result: {result}\n");
                }
            }
        }
    }
    public class Converting
    {
        public string ConvertDecimalToBinary(int dec)
        {
            List<string> list = new List<string>();
            string result = string.Empty;
            while (dec > 0.9)
            {
                list.Add((dec % 2).ToString());
                dec = dec / 2;
            }
            list.Reverse();
            result = string.Concat(list);
            return result;
        }
        public int ConvertBinaryToDecimal(string bin)
        {
            List<char> charList = new List<char>();
            List<int> intList = new List<int>();
            try
            {
                double sum = 0;
                for (int i = 0; i < bin.Length; i++)
                {
                    charList.Add(bin[i]);
                }
                intList.Add(Convert.ToInt32(bin));
                intList.RemoveAt(0);
                charList.Reverse();
                for (int i = 0; i < charList.Count; i++)
                {
                    intList.Add(Convert.ToInt32(charList[i].ToString()));
                }
                for (int i = 0; i < intList.Count; i++)
                {
                    if (intList[i] == 1)
                    {
                        sum += Math.Pow(2, i);
                    }
                    else if (intList[i] > 1)
                    {
                        return 0;
                    }
                }
                int res = int.Parse(sum.ToString());
                return res;
            }
            catch (FormatException mes)
            {
                Console.WriteLine(mes);
                return 0;
            }
        }
        public string ConvertDecimalToHexaDecimal(int dec)
        {
            List<string> list = new List<string>();
            string result = string.Empty;
            while (dec > 0.9)
            {
                if ((dec % 16) == 15)
                {
                    list.Add("F");
                    dec = dec / 16;
                }
                if ((dec % 16) == 14)
                {
                    list.Add("E");
                    dec = dec / 16;
                }
                if ((dec % 16) == 13)
                {
                    list.Add("D");
                    dec = dec / 16;
                }
                if ((dec % 16) == 12)
                {
                    list.Add("C");
                    dec = dec / 16;
                }
                if ((dec % 16) == 11)
                {
                    list.Add("B");
                    dec = dec / 16;
                }
                if ((dec % 16) == 10)
                {
                    list.Add("A");
                    dec = dec / 16;
                }
                else if ((dec % 16) < 10)
                {
                    list.Add((dec % 16).ToString());
                    dec = dec / 16;
                }
            }
            list.Reverse();
            result = string.Concat(list);
            return result;
        }
        public int ConvertingHexaDecimalToDecimal(string hex)
        {
            List<char> charList = new List<char>();
            List<int> intList = new List<int>();
            double sum = 0;
            for (int i = 0; i < hex.Length; i++)
            {
                charList.Add(hex[i]);
            }
            charList.Reverse();
            for (int i = 0; i < charList.Count; i++)
            {
                try
                {
                    if (charList[i].ToString() == "F")
                    {
                        intList.Add(15);
                    }
                    else if (charList[i].ToString() == "E")
                    {
                        intList.Add(14);
                    }
                    else if (charList[i].ToString() == "D")
                    {
                        intList.Add(13);
                    }
                    else if (charList[i].ToString() == "C")
                    {
                        intList.Add(12);
                    }
                    else if (charList[i].ToString() == "B")
                    {
                        intList.Add(11);
                    }
                    else if (charList[i].ToString() == "A")
                    {
                        intList.Add(10);
                    }
                    else
                    {
                        intList.Add(Convert.ToInt32(charList[i].ToString()));
                    }
                }
                catch (FormatException mes)
                {
                    Console.WriteLine(mes);
                }
            }
            for (int i = 0; i < intList.Count; i++)
            {
                sum += intList[i] * Math.Pow(16, i);
            }
            int res = int.Parse(sum.ToString());
            return res;
        }
    }
}