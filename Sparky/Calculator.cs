namespace Sparky
{
    public class Calculator
    {
        public List<int> NumberRange = new List<int>();

        public int AddNumbers(int a,int b)
        {
            return a + b;
        }

        public double AddNumbersDouble(double a, double b)
        {
            return a + b;
        }

        public bool odd(int a)
        {
            return a % 2 != 0;
        }

        public List<int> OddRange(int min,int max)
        {
            NumberRange.Clear();

            for (int i = min; i <= max; i++)
            {
                if (odd(i))
                {
                    NumberRange.Add(i);
                }
            }
            return NumberRange;
        }
    }
}
