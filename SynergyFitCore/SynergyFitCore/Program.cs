using System;
using System.Collections.Generic;
using System.Threading;

namespace SynergyFitCore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Initiating Class test: ");
            Console.WriteLine("\nCreating SleepData");

            SleepData sleepData = new SleepData("mySleepData");

            Console.WriteLine("\nStarting a sensor loop to gather random data for 10 seconds:");
            sleepData.StartSensorLoop();

            DateTime firstDateTime = DateTime.Now;
            DateTime secondDateTime = DateTime.Now;

            for (int i = 10; i > 0; i = i - 1)
            {
                Console.WriteLine(i);
                if (i == 7)
                    firstDateTime = DateTime.Now;
                if (i == 3)
                    secondDateTime = DateTime.Now;
                Thread.Sleep(1000);
            }

            Console.WriteLine("\nEnding Sensor loop");
            sleepData.EndSensorLoop();

            Console.WriteLine("\nPrinting all Data:");

            foreach (var item in sleepData.DataDictionary)
            {
                Console.WriteLine(item.Key + ": " + item.Value);
            }


            Console.WriteLine("\nPrinting Data from " + firstDateTime.ToString() + " to " + secondDateTime.ToString());

            Dictionary<DateTime, int> dict = sleepData.ReturnDataRequest(firstDateTime, secondDateTime);

            foreach (var item in dict)
            {
                Console.WriteLine(item.Key + ": " + item.Value);
            }

        }
    }
}
