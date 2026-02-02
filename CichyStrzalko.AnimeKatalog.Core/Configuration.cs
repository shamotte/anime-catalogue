using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Graph;

namespace CichyStrzalko.AnimeKatalog.Core
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Configuration.Json;
    using System;
    using System.IO;

    namespace Project.Core.Configuration
    {
        public static class AppConfiguration
        {
            
            

            private static IConfiguration? _configuration;

            public static IConfiguration Configuration
            {
                get
                {
                    if (_configuration == null)
                        _configuration = BuildConfiguration();

                    return _configuration;
                }
            }

            private static IConfiguration BuildConfiguration()
            {
                if (!File.Exists("appsettings.json"))
                {
                    File.WriteAllText("appsettings.json", "{}");
                    throw new FileNotFoundException("Brak pliku konfiguracyjnego 'appsettings.json'.");
                }

                return new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .Build();
            }
        }
    }





}
