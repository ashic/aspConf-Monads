using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsComposition
{
    public class LoggingExecutor<T>
    {
        readonly Action<T> _next;

        public LoggingExecutor(Action<T> next)
        {
            _next = next;
        }

        public void Handle(T command)
        {
            Console.WriteLine("----Log Entry: Command of type {0} received at {1}", typeof(T), DateTime.UtcNow);
            _next(command);
        }
    }

    public class SecurityEnabledExecutor<T>
    {
        readonly Action<T> _next;

        public SecurityEnabledExecutor(Action<T> next)
        {
            _next = next;
        }

        public void Handle(T command)
        {
            var prev = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Done security check");
            Console.ForegroundColor = prev;
            
            _next(command);
        }
    }
}
