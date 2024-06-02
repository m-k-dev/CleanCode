using System.Diagnostics;

namespace CleanCode
{
    public class CTimer : IDisposable
    {
        private Stopwatch startTime;
        private string messageString;

        public CTimer(String str = "")
        {
            messageString = str;
            startTime = System.Diagnostics.Stopwatch.StartNew();
        }

        ~CTimer()
        {
            Console.WriteLine("=== Timer dtor ===");
        }
        public void Dispose()
        {
            startTime.Stop();
            var resultTime = startTime.Elapsed;

            // elapsedTime - строка, которая будет содержать значение затраченного времени
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:000}",
                resultTime.Hours,
                resultTime.Minutes,
                resultTime.Seconds,
                resultTime.Milliseconds);

            Console.WriteLine(messageString + "\t" + elapsedTime);
        }
    }
}
