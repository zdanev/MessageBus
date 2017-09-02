using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace MessageBus.Tests
{
    public class MessageBusTests
    {
        class TestMessage : Message
        {
            public bool Handled { get; set; }

            public bool Handled2 { get; set; }
        }

        class TestHandler : MessageHandler<TestMessage>
        {
            public override void Handle(TestMessage message)
            {
                message.Handled = true;
            }
        }

        class TestHandler2 : MessageHandler<TestMessage>
        {
            public override void Handle(TestMessage message)
            {
                message.Handled2 = true;
            }
        }

        [Fact]
        public void MessageBus_RegistersHandlers()
        {
            // arrange
            var bus = new MessageBus();

            // act

            // assert
            Assert.True(bus.Handlers.Any());
        }

        [Fact]
        public void MessageBus_SendMessage()
        {
            // arrange
            var bus = new MessageBus();
            var message = new TestMessage();

            // act
            bus.Send(message);

            // assert
            Assert.True(message.Handled);
        }

        [Fact]
        public void MessageBus_MultipleHandlers()
        {
            // arrange
            var bus = new MessageBus();
            var message = new TestMessage();

            // act
            bus.Send(message);

            // assert
            Assert.True(message.Handled2);
            Assert.True(message.Handled2);
        }    
    }
}