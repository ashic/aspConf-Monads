using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsComposition
{
    public class SomeHandler
    {

        public void Handle(SomeMessage message)
        {
            var color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Handling the message");
            Console.ForegroundColor = color;

        }
    }


    //.................................................

    public interface IProvideSomeMessage
    {
        string GetMessage();
    }

    public class SomeOtherHandler
    {
        readonly IProvideSomeMessage _messageProvider;

        public SomeOtherHandler(IProvideSomeMessage messageProvider)
        {
            _messageProvider = messageProvider;
        }

        public void Handle(SomeMessage message)
        {
            var color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Handling the message with {0}", _messageProvider.GetMessage());
            Console.ForegroundColor = color;

        }
    }

    public class HelloProvider : IProvideSomeMessage
    {
        public string GetMessage()
        {
            return "Hello";
        }
    }


    //..................................
    public class SomeHandler2
    {
        //public SomeHandler2(ISecurityService security, ILoggingService log)
        //{
                
        //}

        public void Handle(SomeMessage message)
        {
            //Logger.Log
            //Security.CheckForSecurity
            var color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Handling the message");
            Console.ForegroundColor = color;

        }
    }
}
