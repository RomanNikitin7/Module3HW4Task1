namespace Module3HW4Task1
{
    internal class Program
    {
        private static event Action<int> OnCalculation;
        static void Main(string[] args)
        {
            int x, y;
            Console.WriteLine("Input x: ");
            x = int.Parse(Console.ReadLine());
            Console.WriteLine("Input y: ");
            y = int.Parse(Console.ReadLine());
            OnCalculation += (int result) => Print(result);
            OnCalculation += (int result) => AnotherPrint(result);

            Run(Sum, x, y);
        }
        private static void Print(int i)
        {
            Console.WriteLine("Result: " + i);
        }
        private static void AnotherPrint(int i)
        {
            Console.WriteLine("AnotherResult: " + i);
        }
        private static void Run(Func<int, int, int> calculation, int x, int y)
        {
            try
            {
                calculation(x, y);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        private static int Sum(int x, int y)
        {
            var result = x + y;
            if (x == 0)
            {
                throw new Exception("X cann't be 0");
            }
            if(OnCalculation != null)
            {
                OnCalculation(result);
            }
            return result;
        }
    }
}
