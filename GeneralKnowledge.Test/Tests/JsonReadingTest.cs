using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Script.Serialization;
using System.Linq;

namespace GeneralKnowledge.Test.App.Tests
{
    /// <summary>
    /// Basic data retrieval from JSON test
    /// </summary>
    public class JsonReadingTest : ITest
    {
        public string Name { get { return "JSON Reading Test";  } }

        public void Run()
        {
            var jsonData = Resources.SamplePoints;

            // TODO: 
            // Determine for each parameter stored in the variable below, the average value, lowest and highest number.
            // Example output
            // parameter   LOW AVG MAX
            // temperature   x   y   z
            // pH            x   y   z
            // Chloride      x   y   z
            // Phosphate     x   y   z
            // Nitrate       x   y   z

            PrintOverview(jsonData);
        }

        private void PrintOverview(byte[] data)
        {
            string jsonStr = Encoding.UTF8.GetString(data);
            var Samples = new JavaScriptSerializer().Deserialize<SamplePoints>(jsonStr);
            Console.WriteLine(string.Format("parameter   low   avg   max"));
           foreach(var prop in  typeof(Sample).GetProperties())
            {
                if (prop.Name != "date" && prop.Name != "temperature")
                {
                    var valueList = Samples.samples.Select(x => x.GetType().GetProperty(prop.Name).GetValue(x, null));
                    var low= valueList.Min();
                    var avg = valueList.Select(x => (int)x).Average();
                    var max = valueList.Max();
                    Console.WriteLine(string.Format("{0}        {1}      {2}      {3}", prop.Name, low, avg, max));
                }
                if (prop.Name == "temperature")
                {
                    var valueList = Samples.samples.Select(x => x.GetType().GetProperty(prop.Name).GetValue(x, null));
                    var low = valueList.Min();
                    var avg = valueList.Select(x => (double)x).Average();
                    var max = valueList.Max();
                    Console.WriteLine(string.Format("{0}        {1}      {2}      {3}", prop.Name, low, avg, max));
                }


            }


        }
    }
    public class Sample
    {
        public DateTime date { get; set; }
        public double temperature { get; set; }
        public int pH { get; set; }
        public int phosphate { get; set; }
        public int chloride { get; set; }
        public int nitrate { get; set; }
    }

    public class SamplePoints
    {
        public List<Sample> samples { get; set; }
    }
}
