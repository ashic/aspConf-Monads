using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsComposition
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program().Run4();
        }

        private void Run()
        {
            var items = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var foo = items.Select(x =>
            {
                Console.WriteLine("Selecting {0}", x);
                return x;
            });

            var bar = foo.OrderByDescending(x => x);

            bar.ToArray();
        }



        //...........................................................
        private void Run2()
        {
            //in composition root
            var bus = new MessageBus();
            var handler = new SomeHandler();

            bus.RegisterHandler<SomeMessage>(handler.Handle);

            //in application code
            bus.Handle(new SomeMessage());
        }




        //............................................................
        private void Run3()
        {
            //in composition root
            var bus = new MessageBus();
            var someMessageProvider = new HelloProvider();
            var handler = new SomeOtherHandler(someMessageProvider);

            bus.RegisterHandler<SomeMessage>(handler.Handle);

            //in application code
            bus.Handle(new SomeMessage());
        }



        //............................................................
        private void Run4()
        {
            //in composition root
            var bus = new MessageBus();
            var someMessageProvider = new HelloProvider();
            var handler = new SomeOtherHandler(someMessageProvider);

            bus.RegisterHandler(
                WrapWithLogger(
                WrapWithSecurity<SomeMessage>(
                handler.Handle)));

            //in application code
            bus.Handle(new SomeMessage());
        }

        static Action<T> WrapWithLogger<T>(Action<T> inner)
        {
            return new LoggingExecutor<T>(inner).Handle;
        }

        static Action<T> WrapWithSecurity<T>(Action<T> inner)
        {
            return new SecurityEnabledExecutor<T>(inner).Handle;
        }
    }
}
