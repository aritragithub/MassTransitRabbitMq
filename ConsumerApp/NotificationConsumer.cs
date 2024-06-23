using MassTransit;
using MassTransitRabbitMq.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsumerApp
{
    public class ConsumerNotification : IConsumer<Notification>
    {
        public async Task Consume(ConsumeContext<Notification> context)
        {
            var serializedMessage = JsonSerializer.Serialize(context.Message, new JsonSerializerOptions { });

            Console.WriteLine($"Notification consumed: {serializedMessage}");
        }
    }
}
