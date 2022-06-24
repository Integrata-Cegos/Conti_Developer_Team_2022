using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conti.Tom.Publishing.Service
{
    public class ConfigurationService : IConfigurationService
    {
        private string configfile = Path.Combine(Path.GetTempPath(), "application.properties");

        public ConfigurationService()
        {
            InitConfigfile();
        }

        private void InitConfigfile()
        {
            if (!File.Exists(configfile))
            {
                using (StreamWriter file = new StreamWriter(configfile))
                {
                    StringBuilder initialconfiguration = new();
                    initialconfiguration.AppendLine("#Configuration for ISBNService");
                    initialconfiguration.AppendLine("isbn.prefix=isbn");
                    initialconfiguration.AppendLine("isbn.countryCode=-de");
                    file.WriteLine(initialconfiguration.ToString());
                }
            }
        }

        public string GetConfiguration(string key)
        {
            var config = File.ReadLines(configfile).ToList();
            config = config.FindAll(x => !x.StartsWith("#") && !String.IsNullOrEmpty(x));

            foreach (var item in config)
            {
                var keyvalues = item.Split("=");
                if (keyvalues[0] == key)
                    return keyvalues[1];
            }
            return key;
        }
    }
}
