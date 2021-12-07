using System.IO;
using System;
using System.Diagnostics;
// See https://aka.ms/new-console-template for more information

public class Program {

    private static readonly string InputFileName = "input.txt";

    public static void Main(string[] args)
    {
        PartOne();

        PartTwo();
    }

    //Find the number of value increases between single values in a list
    private static void PartOne() 
    {
        int totalIncreases = 0;

        using(var fsr = new StreamReader(new FileStream(InputFileName, FileMode.Open)))
        {
            var lastReading = ReadNextEntry(fsr);
            do 
            {
                var currValue = ReadNextEntry(fsr);
                totalIncreases += currValue > lastReading ? 1 : 0;
                lastReading = currValue;
            } while (lastReading > 0);
        }

        Console.WriteLine($"There are {totalIncreases.ToString()} increases between values");
    }
    
    private static int ReadNextEntry(StreamReader sr)
    {
        try{
            return Convert.ToInt32(sr.ReadLine());
        }catch {
            return 0;
        }
    }

    //Find the number of sliding window increases of a size 
    private static void PartTwo() 
    {
        int totalIncreases = 0;
        int rangeSize = 3;
        string[] endOfReadingChars = new string[] { "\r", "\n" };

        //Read in file
        var rawReadings = string.Empty;
        using(var fsr = new StreamReader(new FileStream(InputFileName, FileMode.Open)))
        {
            rawReadings = fsr.ReadToEnd();
        }

        //Split into readings
        var readings = rawReadings.Split(endOfReadingChars, StringSplitOptions.RemoveEmptyEntries);
        rawReadings = null;

        var lastSum = 0;
        for(int i = 0; i < readings.Length; i++)
        {
            int sum = 0;

            //if we have no more to make a group, break
            if(i + rangeSize > readings.Length){
                //Debug.WriteLine($"No more space for groupings at {i} with group size of {rangeSize}");
                break;
            }
            
            //Loop around the range size and sum the integers with conversion, not the best gets the job done
            for(int j = 0; j < rangeSize; j++)
            {
                sum += Convert.ToInt32(readings[i + j]);
            }

            if(i > 0 && sum > lastSum){
                totalIncreases++;
            }

            lastSum = sum;
        }  

        Console.WriteLine($"There are {totalIncreases.ToString()} sliding window increases");
    }
}