using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Array
    {
        public Array(Int32 lenth)
        {
            Output(lenth);
        }

        private Int32[] OutputArray(Int32 lenth)
        {
            Int32[] sample = new Int32[lenth];
            for (var i = 0; i < sample.Length; i++)
            {
                sample[i] = i*2;
            }
            return sample;
        }
        private String OutputText(Int32 number, Int32 value)
        {
            return "sample[" + number + "]: " + value;
        }

        private void Output(Int32 lenth)
        {
            for (var i = 0; i < OutputArray(lenth).Length; i++)
            {
                Console.WriteLine(OutputText(i, OutputArray(lenth)[i]));
            }
        }
    }
    internal class Program
    {
        private static void Main()
        {
            var test = new Array(10);
            Console.ReadKey();
        }
    }
}

