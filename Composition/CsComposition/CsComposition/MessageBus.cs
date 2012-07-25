using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsComposition
{
    public class MessageBus
    {
        readonly Dictionary<Type, Action<object>> _handlers= new Dictionary<Type, Action<object>>();

        public void RegisterHandler<T>(Action<T> handler)
        {
            List<Action<object>> handlers;

            _handlers[typeof(T)] = x => handler((T)x);
        }

        public void Handle(object command)
        {
            _handlers[command.GetType()](command);
        }
    }
}
