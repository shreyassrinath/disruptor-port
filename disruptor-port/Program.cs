using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace disruptor_port
{
   
    class Program
    {
        static void Main(string[] args)
        {
            //var barrier = new Barrier();
            //barrier.Add(new Cursor());
            //barrier.Add(new Cursor());
            //var writer = new Writer();
            //writer.Commit(100, barrier);

            //writer.Commit(101, barrier);
            //var reader = new Reader();
            //reader.Start();
            //reader.Stop();
           
            // Create new stopwatch.
            Stopwatch stopwatch = new Stopwatch();
            int iterations = 200000000;
            int bufferCapacity = 1000000;
            var sequence = -1;
            var disruptor = new Disruptor();
            

            var buffer = new int[bufferCapacity];
            var len = buffer.Length;
            var reservations = 10000;
            disruptor.Build(new Consumer(bufferCapacity),buffer);
            disruptor.StartReaders();

            // Begin timing.
            stopwatch.Start();
            //for (int i = 0; i < iterations; i++)
            //{
            //    //buffer[i % len] = i;
            //    //Console.WriteLine("Added" + i);
            //    var test = buffer[i % len];

            //}
            var writer = disruptor.Writer;
           
            while (sequence < iterations)
            {
                sequence = writer.Reserve(reservations);
                for (int i = sequence - reservations + 1; i <= sequence; i++) {
                    buffer[i % bufferCapacity] = i;
                }
                writer.Commit(sequence);            


            }
            stopwatch.Stop();

            disruptor.StopReaders();
            
            
            Console.WriteLine("Elapsed time in secs " + (float)stopwatch.ElapsedMilliseconds/1000);
            //Console.WriteLine(2201 % 10);
            Console.Read();
        }
    }
}
