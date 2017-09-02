using System.Threading.Tasks;

namespace MessageBus
{
    public abstract class MessageHandler<M> where M: Message
    {
        public abstract void Handle(M Message);
    }
}