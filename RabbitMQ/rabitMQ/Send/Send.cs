using System;
using RabbitMQ.Client;
using System.Text;

class Send
{
    public static void Main()
    {
        //var factory = new ConnectionFactory() { HostName = "localhost"};
        var factory = new ConnectionFactory() { HostName = "localhost"};
        using(var connection = factory.CreateConnection())
        using(var channel = connection.CreateModel())
        {
            channel.QueueDeclare(queue: "hello",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            

            for(int i=0; i <=100; i++)
            {
                var message =  $" MENSSAGEM   => TESTE de menssagem - "+i;
                var body = Encoding.UTF8.GetBytes($"Menssagem {i} -> {message}");
                channel.BasicPublish(exchange: "",
                                 routingKey: "hello",
                                 basicProperties: null,
                                 body: body);
                Console.WriteLine($" [x] Sent {i}", message);
                Thread.Sleep(200);
                Console.WriteLine("Insira sua mensagem para envio: ");
            }
        }

        Console.WriteLine(" Press [enter] to exit.");
        Console.ReadLine();
    }
}