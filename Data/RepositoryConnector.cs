using System;
using Microsoft.Extensions.Configuration;

namespace Data
{
    public class RepositoryConnector
    {
        public IConfiguration _configuration;
        public RepositoryConnector(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public string GetConnection()
        {
             var a = Environment.GetEnvironmentVariable("DATABASE_URL");
            var b = DotNetEnv.Env.GetString("DATABASE_URL");            

            System.Console.WriteLine("teste");
            System.Console.WriteLine(a);            
            System.Console.WriteLine(b);

            var c = _configuration.GetConnectionString("DATABASE_URL");

            return Environment.GetEnvironmentVariable("DATABASE_URL");


            /*return _configuration
                        .GetSection("Connections")
                        .GetSection("ConnectionString")
                        .Value;*/

                        
        }
    }
}
