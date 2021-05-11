using System;
using System.IO;
namespace String_Interpolation
{
    class Program
    {
        static void Main(string[] args)
        {
            var file = "data.txt";
           
            Console.WriteLine("Enter 1 to create data file.");
            Console.WriteLine("Enter 2 to parse data.");
            Console.WriteLine("Enter anything else to quit.");
            
            string resp = Console.ReadLine();
            if (resp == "1")
            {
               
                Console.WriteLine("How many weeks of data is needed?");
                
                int weeks = int.Parse(Console.ReadLine());
                
                DateTime today = DateTime.Now;
               
                DateTime dataEndDate = today.AddDays(-(int)today.DayOfWeek);
               
                DateTime dataDate = dataEndDate.AddDays(-(weeks * 7));
                
                
                Random rnd = new Random();

                
               
                StreamWriter sw = new StreamWriter(file);
                
                while (dataDate < dataEndDate)
                {
                    
                    int[] hours = new int[7];
                    for (int i = 0; i < hours.Length; i++)
                    {

                        hours[i] = rnd.Next(4, 13);
                    }
                  
                    sw.WriteLine($"{dataDate:M/d/yyyy},{string.Join("|", hours)}");
                    dataDate = dataDate.AddDays(7);
                }
                sw.Close();
            }
            else if (resp == "2")
            {
               
                if (File.Exists(file))
                {
                    
                    StreamReader sr = new StreamReader(file);
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        
                        
                        string[] week = line.Split(',');
                        
                        DateTime date = DateTime.Parse(week[0]);
                        
                        int[] hours = Array.ConvertAll(week[1].Split('|'), int.Parse);
                        
                        Console.WriteLine($"Week of {date:MMM}, {date:dd}, {date:yyyy}");
                        
                        Console.WriteLine($"{"Su",3}{"Mo",3}{"Tu",3}{"We",3}{"Th",3}{"Fr",3}{"Sa",3}{"Tot",4}{"Avg",4}");
                        int sum =0;
                        Array.ForEach(hours, delegate(int i){sum += i;});
                       decimal average= Math.Round(((Convert.ToDecimal(sum))/7),1);
                      
                        Console.WriteLine($"{"--",3}{"--",3}{"--",3}{"--",3}{"--",3}{"--",3}{"--",3}{"---",4}{"---",4}");

                        

                        Console.WriteLine($"{hours[0],3}{hours[1],3}{hours[2],3}{hours[3],3}{hours[4],3}{hours[5],3}{hours[6],3}{sum,4}{average,4}"); 
                        
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("File does not exist");
                }
            }
        }
    }
}