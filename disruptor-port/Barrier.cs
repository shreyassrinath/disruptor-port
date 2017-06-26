using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace disruptor_port
{
    public class Barrier
    {
        private List<Cursor> BarrierCursors { get; set; }

        public Barrier()
        {
            BarrierCursors = new List<Cursor>();
        }

        public void Add(Cursor cursor)
        {
            BarrierCursors.Add(cursor);
        }
        //index=0 reserved for Producer
        public Cursor Get(int i) { return BarrierCursors[i]; }

        public int Read()
        {
            int minimum = int.MaxValue;
            foreach(var item in BarrierCursors)
            {
                if (item.sequence < minimum)
                {
                    minimum = item.sequence;
                }
            }
            return minimum;
        }
    }
}
