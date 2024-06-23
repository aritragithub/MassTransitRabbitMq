namespace MassTransitRabbitMq.Shared
{
    public class Notification
    {
        public int Id { get; set; } 
        public string Type { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
