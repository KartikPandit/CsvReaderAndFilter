using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV
{
    public class MyMappedCSVFile
    {
        public string Name { get; set; }
        public string dob { get; set; }
        public string EID { get; set; }
        public string location { get; set; }
        public string desig { get; set; }
        
        public static MyMappedCSVFile FromCsv (string csvLine)
        {
            string[] values = csvLine.Split(',');
            MyMappedCSVFile obj = new MyMappedCSVFile();
            obj.Name = values[0];
            obj.dob = values[1];
            obj.location = values[2];
            obj.desig = (values[3]);
            return obj;
        }
    }
    public class Program
    {
        public static void search_on_location ()
        {
            Console.WriteLine("Enter the location");
            String location = Console.ReadLine();
            string delimiter = ",";
            List<string> logs = (File.ReadAllLines(@"C:\Users\yuhub\OneDrive\Desktop\record.csv")
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
            List<string> logs = (File.ReadAllLines(@"C:\Users\yuhub\OneDrive\Desktop\record.csv")
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
            List<MyMappedCSVFile> values = File.ReadAllLines(@"C:\Users\yuhub\OneDrive\Desktop\record.csv")
                                          .Skip(1)
                                          .Select(v => MyMappedCSVFile.FromCsv(v))
                                          .ToList();
            Console.Write("enter dob \n");
            DateTime dob = DateTime.Parse(Console.ReadLine());
            foreach (var record in values)
            {
                DateTime.TryParseExact(record.dob, "MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime date);
                if (DateTime.Compare(date, dob) >= 0)
                {
                    Console.WriteLine(record.Name + "," + record.dob + "," + record.location + "," + record.desig);
                }
                

            }
        }
    }
}

