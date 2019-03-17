using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV
{
    public class Program
    {
        public static void search_on_location ()
        {
            Console.WriteLine("Enter the location");
            String location = Console.ReadLine();
            string delimiter = ",";
            List<string> logs = (File.ReadAllLines(@"C:\Users\yuhub\OneDrive\Desktop\records.csv")
                                .Select(line => line.Split(delimiter.ToCharArray()))
                                .Where(values => values[2].Equals(location, StringComparison.CurrentCultureIgnoreCase))
                                .Select(values => string.Join(",", values))
                                .Distinct()
                                .ToList<string>());
            if (!logs.Any())
            {
                Console.WriteLine(location + "Not found");
            }
            else
            {
                foreach (var col in logs)
                    Console.Write(col);
                Console.ReadKey();
            }

        }
        public static void search_on_designation ()
        {
            Console.WriteLine("Enter the designation");
            String designation = Console.ReadLine();
            string delimiter = ",";
            List<string> logs = (File.ReadAllLines(@"C:\Users\yuhub\OneDrive\Desktop\records.csv")
                    .Select(line => line.Split(delimiter.ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
                    .Where(values => values[3].Equals(designation, StringComparison.CurrentCultureIgnoreCase))
                    .Select(values => string.Join(",", values))
                    .Distinct()
                    .ToList<string>());
            if (!logs.Any())
            {
                Console.WriteLine(designation + " Not found");
            }
            else
            {
                foreach (var col in logs)
                    Console.WriteLine(col);
                Console.ReadKey();
            }
        }
        public static void search_on_dob ()
        {
                 String delimiter = ",";
            Console.Write("enter dob");
            String dob = Console.ReadLine();
            List<string> logs = (File.ReadAllLines(@"C:\Users\yuhub\OneDrive\Desktop\records.csv")
                    .Where(line => !string.IsNullOrEmpty(line))
                    .Select(line => line.Split(delimiter.ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
                    .Where(values => String.Compare(values[1],dob)>0)
                    .Select(values => string.Join(",", values))
                 .Distinct()
                 .ToList<string>());
            if (!logs.Any())
            {
                Console.WriteLine(dob + " Not found");
            }
            else
            {
                foreach (var col in logs)
                    Console.WriteLine(col);
                Console.ReadKey();
            }

        }
    }
}
