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
            return _configuration
                        .GetSection("Connections")
                        .GetSection("ConnecionString")
                        .Value;
        }
    }
}
