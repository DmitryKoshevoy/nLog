using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace nLog
{
    class ExceptionExample
    {
        private Int32 _value;
        public Int32 Value
        {
            private get { return _value; }
            set
            {
                if(value == 0)
                  throw new ArgumentException();
                _value = value;
            }
        }

    }
    internal class Program
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private static void Main(string[] args)
        {
            var exception = new ExceptionExample();
            try
            {
                exception.Value = 0;
            }
            catch (ArgumentException exc)
            {
                logger.Error("Zero value was assigned", exc);
            }
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
