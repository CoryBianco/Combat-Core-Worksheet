namespace CombatCore.Tests
{
    public class EventBusTest
    {
        private readonly struct OtherTestEvent
        {
            public int Value { get; init; }
        }

        [Fact]
        public void Publish_WhenNoSubscribers_DoesNotThrow()
        {
            var bus = new EventBus();

            bus.Publish(new DamageDealtEvent { Amount = 10f, Type = DamageType.Sword });
        }

        [Fact]
        public void Subscribe_Publish_InvokesHandlerWithPublishedEvent()
        {
            var bus = new EventBus();
            DamageDealtEvent? received = null;
            bus.Subscribe<DamageDealtEvent>(e => received = e);

            bus.Publish(new DamageDealtEvent { Amount = 10f, Type = DamageType.Sword });

            Assert.NotNull(received);
            Assert.Equal(10f, received.Value.Amount, 3);
            Assert.Equal(DamageType.Sword, received.Value.Type);
        }

        [Fact]
        public void Publish_InvokesAllSubscribedHandlers()
        {
            var bus = new EventBus();
            var firstCallCount = 0;
            var secondCallCount = 0;
            bus.Subscribe<DamageDealtEvent>(_ => firstCallCount++);
            bus.Subscribe<DamageDealtEvent>(_ => secondCallCount++);

            bus.Publish(new DamageDealtEvent { Amount = 5f, Type = DamageType.Fire });

            Assert.Equal(1, firstCallCount);
            Assert.Equal(1, secondCallCount);
        }

        [Fact]
        public void Publish_DoesNotInvokeHandlersSubscribedToADifferentEventType()
        {
            var bus = new EventBus();
            var damageHandlerCallCount = 0;
            var otherHandlerCallCount = 0;
            bus.Subscribe<DamageDealtEvent>(_ => damageHandlerCallCount++);
            bus.Subscribe<OtherTestEvent>(_ => otherHandlerCallCount++);

            bus.Publish(new DamageDealtEvent { Amount = 5f, Type = DamageType.Fire });

            Assert.Equal(1, damageHandlerCallCount);
            Assert.Equal(0, otherHandlerCallCount);
        }

        [Fact]
        public void Subscribe_SameActionSubscribedTwice_OnlyInvokedOnce()
        {
            var bus = new EventBus();
            var callCount = 0;
            void Handler(DamageDealtEvent e) => callCount++;

            bus.Subscribe<DamageDealtEvent>(Handler);
            bus.Subscribe<DamageDealtEvent>(Handler);
            bus.Publish(new DamageDealtEvent { Amount = 5f, Type = DamageType.Fire });

            Assert.Equal(1, callCount);
        }

        [Fact]
        public void Unsubscribe_StopsFurtherInvocations()
        {
            var bus = new EventBus();
            var callCount = 0;
            void Handler(DamageDealtEvent e) => callCount++;

            bus.Subscribe<DamageDealtEvent>(Handler);
            bus.Unsubscribe<DamageDealtEvent>(Handler);
            bus.Publish(new DamageDealtEvent { Amount = 5f, Type = DamageType.Fire });

            Assert.Equal(0, callCount);
        }

        [Fact]
        public void Unsubscribe_WhenNeverSubscribed_DoesNotThrow()
        {
            var bus = new EventBus();
            void Handler(DamageDealtEvent e) { }

            bus.Unsubscribe<DamageDealtEvent>(Handler);
        }
    }
}
