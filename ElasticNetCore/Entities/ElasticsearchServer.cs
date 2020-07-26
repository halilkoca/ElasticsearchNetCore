using System;

namespace ElasticNetCore.Entities
{
    public class ElasticsearchServer
    {
        public string Host { get; set; }
        public string Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        
    }
}
