using MassTransit;
using MassTransitRabbitMq.Shared;

namespace ConsumerApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var bus = Bus.Factory.CreateUsingRabbitMq(x =>
            {

                x.ReceiveEndpoint("notification-queue", ep =>
                {
                    ep.PrefetchCount = 16;
                    ep.UseMessageRetry(r => r.Interval(2, 100));
                    ep.Consumer<ConsumerNotification>();
                });

            });
            bus.StartAsync();
            Console.ReadLine();
            bus.StopAsync();
        }
    }
}
