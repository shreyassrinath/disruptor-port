using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace disruptor_port
{
    public class Cursor
    {
        private const int MAXSEQUENCEVALUE = int.MaxValue;

        private int InitialSequenceValue = -1;

        public int sequence { get; set; }

        public Cursor() { sequence = InitialSequenceValue; }

        #region Methods

        public void Store(int seq) { sequence = seq; }

        public int Load() { return sequence; }
        #endregion


    }
}
