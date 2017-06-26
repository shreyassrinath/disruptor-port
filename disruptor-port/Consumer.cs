using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace disruptor_port
{
    public class Consumer
    {
        private int BufferCapacity { get; set; }
        public Consumer(int bufferCapacity) { BufferCapacity = bufferCapacity; }

        public void Consume(int lower, int upper, int[] buffer)
        {
            while (lower <= upper)
            {
                var message = buffer[lower % BufferCapacity];
                if (message != lower)
                { Console.WriteLine("Race Condition!!!!"); }
                ++lower;
            }
        }
    }
}
