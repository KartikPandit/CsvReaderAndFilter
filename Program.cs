using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSV;

namespace employee
{
    class Program
    {
        static void Main (string[] args)
        {
            Options();
        }
        public static void Options()
        {
            Console.WriteLine("Select from the given optios");
            Console.WriteLine("1)Location");
            Console.WriteLine("2)DOB");
            Console.WriteLine("3)Designation");
            Console.WriteLine("4)Exit");
            try
            {
                int option = int.Parse(Console.ReadLine());



                switch (option)
                {

                    case 1:

                        CSV.Program.search_on_location();
                        Options();
                        break;
                    case 2:
                        CSV.Program.search_on_dob();
                        Options();
                        break;
                    case 3:
                        CSV.Program.search_on_designation();
                        Options();
                        break;
                    case 4:
                        return;
                    default:
                        Console.WriteLine("Select the right option");
                        Options();
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Please enter the correct value"+e);
                Options();

            }

            Console.ReadKey();

        }
    }
}