using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MessageBus
{
    public class MessageBus : IMessageBus
    {
        private IList<Type> handlers = new List<Type>();

        public IList<Type> Handlers { get { return handlers; } } // readonly?

        public MessageBus()
        {
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                foreach (var type in assembly.GetTypes())
                {
                    if (type.Is(typeof(MessageHandler<>)))
                    {
                        Debug.WriteLine("Registered handler " + type.FullName);
                        handlers.Add(type);
                    }
                }
            }
        }

        public void Send(Message message)
        {
            foreach (var handler in handlers)
            {
                if (handler.BaseType.GenericTypeArguments.Length == 1
                    && handler.BaseType.GenericTypeArguments[0] == message.GetType())
                {
                    Debug.WriteLine("Calling handler " + handler.FullName);

                    var instance = Activator.CreateInstance(handler);

                    var handle = handler.GetMethod("Handle");
                    handle.Invoke(instance, new[] { message });
                }             
            }       
        }
    }
}