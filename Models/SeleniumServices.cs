using Microsoft.VisualBasic.FileIO;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.App.Models
{
    public class SeleniumServices
    {

        public static void TypeIntoDelayedMs(IWebElement input, string row, int delay)
        {
            for (int i = 0; i < row.Length; i++)
            {
                input.SendKeys(row[i].ToString());
                Thread.Sleep(delay);
            }
        }

        public static void ReadCsv(string file, ref List<string> list, int col, string del)
        {
            using (TextFieldParser parser = new(file))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(del);

                // Skip header row if needed
                if (!parser.EndOfData)
                    parser.ReadLine();

                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();
                    if (fields != null && fields.Length > 0)
                    {
                        list.Add(fields[col]);
                    }
                }
            }
        }

        public static void InfoMsg(string v)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($"Info: {v}");
            Console.ResetColor();
        }

        public static void DeleteIfExist(string file)
        {
            if (File.Exists(file))
            {
                File.Delete(file);
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Info: Old file deleted");
                Console.ResetColor();
            }
        }
    }
}
