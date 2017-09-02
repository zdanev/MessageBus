using System.Threading.Tasks;

namespace MessageBus
{
    public interface IMessageBus
    {
        void Send(Message message);
    }
}