using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UASKELOMPOK1API
{
    public class Statistika
    {
        public abstract class Data
        {
            public abstract double HitungData();
        }

        public class StatistikFactory
        {
            private static StatistikFactory instance;

            private StatistikFactory() { }

            public static StatistikFactory Instance
            {
                get
                {
                    if (instance == null)
                    {
                        instance = new StatistikFactory();
                    }
                    return instance;
                }
            }

            public Data HitungMean(string arg1)
            {
                return new Mean(arg1);
            }
            public Data HitungMedian(string arg1)
            {
                return new Median(arg1);
            }
            public Data HitungJangkauan(string arg1)
            {
                return new Jangkauan(arg1);
            }
            public Data HitungSimpanganBaku(string arg1)
            {
                return new SimpanganBaku(arg1);
            }
            public Data HitungSimpanganRata(string arg1)
            {
                return new SimpanganRata(arg1);
            }

        }

        public class Mean : Data
        {
            private string input;

            public Mean(String input)
            {
                this.input = input;
            }


            public override double HitungData()
            {
                string[] bilanganString = input.Split(' ');
                int jumlahBilangan = bilanganString.Length;
                double total = 0;

                foreach (string bilangan in bilanganString)
                {
                    total += double.Parse(bilangan);
                }

                double mean = total / jumlahBilangan;
                return mean;
            }

        }

        public class Median : Data
        {
            private string input;

            public Median(string input)
            {
                this.input = input;
            }

            public override double HitungData()
            {

                string[] dataString = input.Split(' ');
                double[] data = Array.ConvertAll(dataString, double.Parse);

                Array.Sort(data);

                int n = data.Length;
                double median;

                if (n % 2 == 0)
                {
                    int middleIndex1 = (n / 2) - 1;
                    int middleIndex2 = n / 2;
                    median = (data[middleIndex1] + data[middleIndex2]) / 2;
                }
                else
                {
                    int middleIndex = n / 2;
                    median = data[middleIndex];
                }

                return median;
            }
        }

        public class Jangkauan : Data
        {
            private string input;

            public Jangkauan(string input)
            {
                this.input = input;
            }

            public override double HitungData()
            {

                string[] dataString = input.Split(' ');
                int[] data = Array.ConvertAll(dataString, int.Parse);

                int nilaiTerbesar = data.Max();
                int nilaiTerkecil = data.Min();

                double jangkauan = nilaiTerbesar - nilaiTerkecil;

                return jangkauan;
            }


        }

        public class SimpanganBaku : Data
        {
            private string input;

            public SimpanganBaku(String input)
            {
                this.input = input;
            }

            public override double HitungData()
            {

                string[] dataString = input.Split(' ');
                double[] data = Array.ConvertAll(dataString, double.Parse);

                double mean = data.Average();

                double sumOfSquaredDeviations = 0;
                foreach (double value in data)
                {
                    double deviation = value - mean;
                    sumOfSquaredDeviations += deviation * deviation;
                }

                double variance = sumOfSquaredDeviations / data.Length;
                double standardDeviation = Math.Sqrt(variance);

                return standardDeviation;
            }
        }

        public class SimpanganRata : Data
        {
            private string input;

            public SimpanganRata(string input)
            {
                this.input = input;
            }

            public override double HitungData()
            {

                string[] dataString = input.Split(' ');
                double[] data = Array.ConvertAll(dataString, double.Parse);

                double mean = data.Average();

                double sumOfAbsoluteDeviations = 0;
                foreach (double value in data)
                {
                    double deviation = Math.Abs(value - mean);
                    sumOfAbsoluteDeviations += deviation;
                }

                double meanAbsoluteDeviation = sumOfAbsoluteDeviations / data.Length;

                return meanAbsoluteDeviation;
            }

        }




    }

}