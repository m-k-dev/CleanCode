// по мотивам
// https://www.computerenhance.com/p/clean-code-horrible-performance

using System.Reflection.Metadata;

///
namespace CleanCode
{
    public class Settings
    {
        // Shapes limit, default value
        public static uint Lim = 10000000;
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write($"Please enter shapes count limit (current Lim = {Settings.Lim}: )");
            string? str = Console.ReadLine();
            if (str != null)
            {
                str = str.Trim();
                if (str.Length > 0)
                {
                    Settings.Lim = uint.Parse(str);
                }
            }
            Console.WriteLine();

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

            Console.WriteLine();
            Console.WriteLine("Done! Please, press any key...");
            Console.ReadKey();
        }
    }
}
