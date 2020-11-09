using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;

namespace Lib1
{
    public static class MainLib
    {
        public static void PerformTask(string filename, int window)
        {
            var vals = OpenFileAndCalculate(filename);
            var averages = CalculateAverage(vals, window);
            foreach(var avg in averages)
            {
                Console.WriteLine(avg);
            }
        }
        
        public static List<int> OpenFileAndCalculate(string filename)
        {
            var result = new List<int>();
            if (File.Exists(filename))
            {
                using (FileStream fs = File.OpenRead(filename))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        var line = string.Empty;
                        while ((line = sr.ReadLine()) != null)
                        {
                            result.Add(Calculate(line));
                        }
                        sr.Close();
                    }
                    fs.Close();
                }
            }
            return result;
        }
        public static int Calculate(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                var numbers = input.Split(' ').Select(int.Parse).ToArray();
                var parameters = numbers.SubArray<int>(1, numbers.Length - 1);
                switch (numbers[0])
                {
                    case 1: return parameters.Sum() % 255;
                    case 2: return parameters.MultiplyInteger() % 255;
                    case 3: return parameters.Max();
                    case 4: return parameters.Min();
                }
            }
            return 0;
        }

        public static List<double> CalculateAverage(List<int> input, int window)
        {
            var result = new List<double>();
            var values = new int[input.Count];
            Array.Copy(input.ToArray(), values, input.Count);
            if (window % 2 == 1 && window >= 3 && window <= 1000001 && input.Count - 1 > window)
            for(int i = 0; i < input.Count - 1 - window; i++)
            {
                result.Add(GetPartAverage(values.SubArray<int>(i, window)));
            }
            return result;
        }

        public static double GetPartAverage(int[] values)
        {
            double sum = 0;
            foreach (var value in values)
            {
                sum += Convert.ToDouble(value);
            }
            return sum / values.Length;
        }
    }
}
