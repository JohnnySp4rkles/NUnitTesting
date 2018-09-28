using System;

namespace Calculator
{
    public class SimpleCalculator
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public int AddInts(int a, int b) {
            return a + b;
        }
        public double AddDoubles(double a, double b) {
            return a + b;
        }

        public int Divide(int a, int b) {
            if(a > 100) {
                throw new ArgumentOutOfRangeException("value");
            }
            return a / b;
        }

        public int Multiply(int a, int b)
        {
            // Bug for demo purposes

            return a * b;
        }
    }
}
