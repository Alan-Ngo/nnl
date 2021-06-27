using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ConsoleTables;


namespace cons
{
    class Program
    {
        static void Main(string[] args)
        {
            var attributes = new List<String>{ "model", "mpg", "cyl", "disp", "hp", "drat", "wt", "qsec", "vs", "am", "gear", "carb"};
            var fileName = "mtcars.csv";
            var cars = readCSV(fileName);

            
            Console.WriteLine("Welcome!!! \n");

            while (true)
            {
                Console.WriteLine("Press R to read file, Press E to edit, Press S to save, Q to exit");
                var input = Console.ReadKey().Key;
                if (input == ConsoleKey.Q)
                {
                    System.Environment.Exit(1);
                }
                else if (input == ConsoleKey.R)
                {
                    displayCars(cars);
                }
                else if (input == ConsoleKey.S)
                {
                    Console.WriteLine("Do you want to sort before you save? Y/N");
                    var sortInput = Console.ReadKey().Key;
                    if (sortInput == ConsoleKey.Y)
                    {
                        cars = cars.OrderBy(c => c.Model).ToList();
                    }
                    saveCars(fileName, cars);
                }
                else if (input == ConsoleKey.E)
                {
                    Console.WriteLine("Enter the row number you want to edit");
                    
                    String strNum = Console.ReadLine();
                    int convNum;
                    if (int.TryParse(strNum, out convNum))
                    {
                        Console.WriteLine("Your are editing row " + strNum);

                        var inputs = new List<String>();
                        for (int i=0; i< attributes.Count();i++)
                        {
                            Console.WriteLine("Enter value for " + attributes[i]);
                            String val = Console.ReadLine();
                            inputs.Add(val);
                        }

                        editRow(convNum, cars, inputs);
                        saveCars(fileName,cars);
                    };
                }
            }
        }

        public static List<Car> readCSV(String fileName)
        {
            var arr = new List<Car>();

            var reader = new StreamReader(fileName);
            using (reader)
            {
                string columns = reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';')[0];
                    var elements = values.Split(',');
                    arr.Add(new Car(elements[0], float.Parse(elements[1]), int.Parse(elements[2]), float.Parse(elements[3]), int.Parse(elements[4]), float.Parse(elements[5]), float.Parse(elements[6]), float.Parse(elements[7]), Convert.ToBoolean(int.Parse(elements[8])), Convert.ToBoolean(int.Parse(elements[9])), int.Parse(elements[10]), int.Parse(elements[11])));
                }
            }
            reader.Dispose();
            return arr;
        }

        public static void displayCars(List<Car> cars)
        {
            var table = new ConsoleTable("model", "mpg", "cyl", "disp", "hp", "drat", "wt", "qsec", "vs", "am", "gear", "carb");

            for (int i = 0 ; i < cars.Count() ; i++)
            {
                table.AddRow(cars[i].Model, cars[i].Mpg, cars[i].Cyl, cars[i].Disp, cars[i].Hp, cars[i].Drat, cars[i].Wt, cars[i].Qsec, Convert.ToInt32(cars[i].Vs), Convert.ToInt32(cars[i].Am), cars[i].Gear, cars[i].Carb);
            }
            table.Write();
        }

        static void editRow(int row, List<Car> arr, List<String> inputs)
        {
            for (int i = 0; i < arr.Count(); i++)
            {
                if (i == row)
                {
                    //Generate new object based on user input
                    arr[i] = new Car(inputs[0], float.Parse(inputs[1]), int.Parse(inputs[2]), float.Parse(inputs[3]), int.Parse(inputs[4]), float.Parse(inputs[5]), float.Parse(inputs[6]), float.Parse(inputs[7]), Convert.ToBoolean(int.Parse(inputs[8])), Convert.ToBoolean(int.Parse(inputs[9])), int.Parse(inputs[10]), int.Parse(inputs[11]));
                }
            }
        }

        public static void saveCars(String fileName, List<Car> obj)
        {
            String s = "";

            foreach (Car car in obj)
            {
                s += car.Model +","+  car.Mpg + "," + car.Cyl + "," + car.Disp + "," + car.Hp + "," + car.Drat + "," + car.Wt + "," + car.Qsec + "," + Convert.ToInt32(car.Vs) + "," + Convert.ToInt32(car.Am) + "," + car.Gear + "," + car.Carb + "\n";

            }
            File.WriteAllText(fileName, s);
            Console.WriteLine("Saved");
        }
    }
}
