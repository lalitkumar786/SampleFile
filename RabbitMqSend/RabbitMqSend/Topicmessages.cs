using System.Text;
using RabbitMQ.Client;

namespace RabbitMqSend
{
    /// <summary>
    /// This Class will Send Messaage to Rabbit mq
    /// </summary>
    internal class Topicmessages
    {
        public Topicmessages() { }
        //private const string UName = "guest";
       // private const string PWD = "guest";
       // private const string HName = "localhost";

        /// <summary>
        /// This method will connect with the rabbit mq message broker and send message to message broker.
        /// </summary>
        public  void SendMessage()
        {
            try
            {
                //Main entry point to the RabbitMQ .NET AMQP client               
                var connectionFactory = new ConnectionFactory() { UserName = ConstantFile.UName, Password = ConstantFile.PWD, HostName = ConstantFile.HName };
                using var connection = connectionFactory.CreateConnection();
                using var model = connection.CreateModel();
                var properties = model.CreateBasicProperties();
                properties.Persistent = false;
                byte[] messagebuffer = Encoding.Default.GetBytes("Message from Topic Exchange 'Bombay' ");
                model.BasicPublish("topic.exchange", "Message.Bombay.Email", properties, messagebuffer);
                Console.WriteLine("Message Sent From: topic.exchange ");
                Console.WriteLine("Routing Key: Message.Bombay.Email");
                Console.WriteLine("Message Sent");
            } catch (Exception ex)
            {
                Console.WriteLine(ex.ToString()); 
            }
        }
    }
}
