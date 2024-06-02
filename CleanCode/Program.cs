// по мотивам
// https://www.computerenhance.com/p/clean-code-horrible-performance
///

namespace CleanCode
{
    public class Settings
    {
        public static readonly uint Lim = 10000000;
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Lim = {Settings.Lim}");

            using (VTBL_Tests tests = new())
            {
                using (var timer = new CTimer("Listing 22 - VTBL init: "))
                {
                    tests.CreateaShapes();
                }
                using (var timer = new CTimer("Listing 22 - VTBL tests: "))
                {
                    tests.Run();
                }
            }
            GC.Collect();

            using (Struct_Tests tests = new())
            {
                using (var timer = new CTimer("Listing 27 - Struct init: "))
                {
                    tests.CreateaShapes();
                }
                using (var timer = new CTimer("Listing 27 - Struct tests: "))
                {
                    tests.Run();
                }
            }
            GC.Collect();
            Console.ReadKey();
        }
    }
}
