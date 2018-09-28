using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator {
    public class ClassWithBugs {
        public void DoWork() {
            if (DateTime.Now.Ticks % 2 == 0)
                throw new ApplicationException("Simulated bug");
        }
    }
}
