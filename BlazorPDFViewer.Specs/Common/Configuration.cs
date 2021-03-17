using Microsoft.Extensions.Configuration;

namespace BlazorPDFViewer.Specs.Common
{
    public class Configuration
    {
        public IConfiguration InitConfiguration()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.test.json")
                .Build();
            return config;
        }
    }
}