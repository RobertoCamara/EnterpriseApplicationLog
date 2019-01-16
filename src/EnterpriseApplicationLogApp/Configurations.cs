using System;
using System.Collections.Generic;
using System.Text;

namespace EnterpriseApplicationLogApp
{
    public class Configurations
    {
        public ConfigurationRabbitMQ ConfigurationRabbitMQ { get; set; }
    }

    public class ConfigurationRabbitMQ
    {
        public string Hostname { get; set; }
        public int Port { get; set; }
        public string VirtualHost { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
