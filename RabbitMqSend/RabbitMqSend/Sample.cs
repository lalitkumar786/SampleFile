using System.Text;
using RabbitMQ.Client;

namespace RabbitMqSend
{
    /// <summary>
    /// This Class is  Responsible to send Message to Topic of Rabbit Mq
    /// </summary>
    internal  class Sample
    {
        /// <summary>
        /// Initialize Props here
        /// </summary>
        public Sample()
        {   
        }

        /// <summary>
        /// This method will connect with the rabbit mq message broker and send message to message broker.
        /// </summary>
        public static void SendMessage()
        {
            try
            {
                // create a connection to the server
                var factory = new ConnectionFactory() { HostName = "localhost" };
                using var connection = factory.CreateConnection();
                using var channel = connection.CreateModel();
                Console.WriteLine("Hello, World!");
                channel.QueueDeclare(queue: "hello",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                const string message = "Hello World!";
                var body = Encoding.UTF8.GetBytes(message);
                channel.BasicPublish(exchange: string.Empty,
                                     routingKey: "hello",
                                     basicProperties: null,
                                     body: body);
                Console.WriteLine($" [x] Sent {message}");

                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
            }catch(Exception ex)
            {
                Console.WriteLine("exception in this method is ", ex.Message);
            }
        }
    }
}
