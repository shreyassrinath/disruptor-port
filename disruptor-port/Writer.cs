using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace disruptor_port
{
    public class Writer
    {
        private int Capacity { get; set; }

        private int Previous { get; set; }

        private int Gate { get; set; }

        private Barrier barrier { get; set; }

        public Writer(int bufferCapacity,Barrier commonBarrier)
        {
            this.Previous = -1;
            this.Gate = -1;
            this.Capacity = bufferCapacity;
            this.barrier = commonBarrier;
        }

        public int Reserve(int count)
        {
            this.Previous += count;
            while (this.Previous - this.Capacity > this.Gate)
            {
                this.Gate = barrier.Read();
            }
           
            return this.Previous;
        }

        public void Commit(int upper) { this.barrier.Get(0).sequence = upper; }
    }
}
