using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Text;
using System.Threading;

namespace EnterpriseApplicationLogApp
{
    class Program
    {
        public class Log
        {
            public string Type { get; set; }
            public int OrdemNum { get; set; }
            public string Message { get; set; }
            public DateTime Date { get; set; }
        }

        public static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "192.168.1.248", Port = 5672, VirtualHost = "EnterpriseLog", UserName = "logUser", Password = "logPwd" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                string[] typeLog = new string[] { "Info", "Erro", "Debug" };
                int[] numeroOrdem = new int[] { 1010, 2020, 3030, 4040, 1234, 5678, 9999 };

                Random rnd = new Random();

                while (true)
                {
                    Log log = new Log { Date = DateTime.Now };

                    log.Type = typeLog[rnd.Next(3)];
                    log.OrdemNum = numeroOrdem[rnd.Next(7)];
                    log.Message = $"{log.Type} pedido nº {log.OrdemNum}";

                    string msg = JsonConvert.SerializeObject(log);
                    var body = Encoding.UTF8.GetBytes(msg);
                    channel.BasicPublish(exchange: "",
                                         routingKey: "ApplicationLog",
                                         basicProperties: null,
                                         body: body);

                    Console.WriteLine(msg);
                    Thread.Sleep(1000);
                }
            }

        }
    }
}
