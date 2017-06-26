using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace disruptor_port
{
    public class Disruptor
    {
        public List<Reader> Readers{get; set;}
        public Writer Writer { get; set; }
        public void StartReaders()
        {
            foreach (var item in Readers) { item.Start(); }
        }

        public void StopReaders()
        {
            foreach (var item in Readers) { item.Stop(); }
        }

        public void Build(Consumer consume, int[] ringBuffer)
        {
            var commonBarrier = new Barrier();
            commonBarrier.Add(new Cursor());
            commonBarrier.Add(new Cursor());
            Writer = new Writer(ringBuffer.Length,commonBarrier);
            Readers = new List<Reader>() { new Reader(consume,ringBuffer,commonBarrier)};
        }
    }
}
