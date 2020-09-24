using System;

namespace NovacleanX.Helpers
{
    public class DebugLogger
    {
        public static void Log(string message, string label = "NovacleanX")
        {
#if DEBUG
            string output = $"\n\n * ********************** {label} ***********************\n{message}\n ***********************{label} ***********************\n";
            Console.WriteLine(output);

#endif
        }
    }
}
