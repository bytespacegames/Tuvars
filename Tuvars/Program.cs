using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Tuvars
{
    class Program
    {

        static int currentLine = 1;
        static List<string> lines = new List<string>();
        static string filename = "code.tux";

        static double a = 0;
        static double b = 0;
        static void Main(string[] args)
        {
            TextReader tr = new StreamReader(Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) + @"\" + @filename);

            string reader = tr.ReadLine();
            while (reader != null)
            {
                lines.Add(reader);

                reader = tr.ReadLine();
            }

            while (currentLine <= lines.Count)
            {
                string line = lines[currentLine - 1];
                string[] inputs = line.Split(" ");
                switch(inputs[0])
                {
                    case "print":
                        int i = line.IndexOf(" ") + 1;
                        string input = line.Substring(i);
                        Console.Write(input);
                        break;
                    case "title":
                        int ie = line.IndexOf(" ") + 1;
                        string inpute = line.Substring(ie);
                        Console.Title = inpute;
                        break;
                    case "set":
                        double value = 0;
                        try
                        {
                            value = double.Parse(inputs[3]);
                        } catch (FormatException)
                        {
                            switch (inputs[3])
                            {
                                case "a":
                                    value = a;
                                    break;
                                case "b":
                                    value = b;
                                    break;
                            }
                        }

                        switch (inputs[1])
                        {
                            case "a":
                                a = value;
                                break;
                            case "b":
                                b = value;
                                break;
                        }
                        break;
                    case "char":
                        int ASCIIVal = 0;
                        switch(inputs[1])
                        {
                            case "a":
                                ASCIIVal = Convert.ToInt32(a);
                                break;
                            case "b":
                                ASCIIVal = Convert.ToInt32(b);
                                break;
                        }
                        Console.Write(Encoding.ASCII.GetString(new byte[] { (byte) ASCIIVal }));
                        break;
                    case "read":
                        switch (inputs[1])
                        {
                            case "a":
                                a = (double)Console.ReadKey().KeyChar;
                                break;
                            case "b":
                                b = (double)Console.ReadKey().KeyChar;
                                break;
                        }
                        break;
                    case "number":
                        switch (inputs[1])
                        {
                            case "a":
                                if ((a % 1) == 0)
                                {
                                    Console.Write((int) a);
                                } else
                                {
                                    Console.Write(a);
                                }
                                break;
                            case "b":
                                if ((b % 1) == 0)
                                {
                                    Console.Write((int)b);
                                }
                                else
                                {
                                    Console.Write(b);
                                }
                                break;
                        }
                        break;
                    case "math":
                        string var = inputs[1];
                        double val1 = 0;
                        string operation = inputs[3];
                        double val2 = 0;

                        try
                        {
                            val1 = double.Parse(inputs[2]);
                        }
                        catch (FormatException)
                        {
                            switch (inputs[2])
                            {
                                case "a":
                                    val1 = a;
                                    break;
                                case "b":
                                    val1 = b;
                                    break;
                            }
                        }
                        try
                        {
                            val2 = double.Parse(inputs[4]);
                        }
                        catch (FormatException)
                        {
                            switch (inputs[4])
                            {
                                case "a":
                                    val2 = a;
                                    break;
                                case "b":
                                    val2 = b;
                                    break;
                            }
                        }

                        double result = 0;

                        switch (operation)
                        {
                            case "+":
                                result = val1 + val2;
                                break;
                            case "-":
                                result = val1 - val2;
                                break;
                            case "/":
                                result = val1 / val2;
                                break;
                            case "x":
                                result = val1 * val2;
                                break;
                            case "%":
                                result = val1 % val2;
                                break;
                        }

                        switch (var)
                        {
                            case "a":
                                a = result;
                                break;
                            case "b":
                                b = result;
                                break;
                        }
                        break;
                    case "if":
                        double val = 0;
                        switch (inputs[1])
                        {
                            case "a":
                                val = a;
                                break;
                            case "b":
                                val = b;
                                break;
                        }

                        if (val == 0)
                        {
                            currentLine += 1;
                        }

                        break;
                    case "ifnot":
                        double valt = 0;
                        switch (inputs[1])
                        {
                            case "a":
                                valt = a;
                                break;
                            case "b":
                                valt = b;
                                break;
                        }

                        if (valt != 0)
                        {
                            currentLine += 1;
                        }

                        break;
                    case "goto":
                        int skipline = 1;
                        try
                        {
                            skipline = int.Parse(inputs[1]) -1;
                        } catch (FormatException)
                        {
                            skipline = 69-1;
                        }
                        currentLine = skipline;
                        break;
                    case "close":
                        Environment.Exit(0);
                        break;
                    case "linebreak":
                        Console.Write("\n");
                        break;
                    case "clear":
                        Console.Clear();
                        break;

                }
                currentLine += 1;
            }

            //while (true) { }
        }
    }
}
