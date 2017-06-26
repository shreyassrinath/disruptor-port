using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace disruptor_port
{
    public class Reader
    {
        private bool Ready { get; set; }

        public Barrier barrier { get; set; }

        private Consumer consumer { get; set; }

        private int[] Buffer { get; set; }

        public Reader(Consumer consume,int[] ringBuffer, Barrier commonBarrier)
        {
            this.consumer = consume;
            this.Buffer = ringBuffer;
            this.barrier = commonBarrier;
        }
        public void Start()
        {
            //Console.WriteLine("Task thread ID: {0}", Thread.CurrentThread.ManagedThreadId);
            this.Ready = true;
            Task.Run(()=>this.Receive());
        }

        public void Stop()
        {
            this.Ready = false;
        }

        public void Receive() {
            //Console.WriteLine("Task thread ID: {0}",Thread.CurrentThread.ManagedThreadId);
            while (true)
            {
                var read = barrier.Get(1).sequence;
                var lower = read + 1;
                var upper = barrier.Get(0).sequence;
                if (lower < upper)
                {
                    this.consumer.Consume(lower, upper, this.Buffer);
                    barrier.Get(1).sequence = upper;
                    //consume
                    //update read
                }
                else if (lower >= upper)
                {
                    //spin
                }
                else if (this.Ready)
                { 
                    //spin
                }
                else { break; }
                
            }
        }
    }
}
