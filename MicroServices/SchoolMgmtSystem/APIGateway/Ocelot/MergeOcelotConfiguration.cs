using Newtonsoft.Json.Linq;

namespace APIGateway.Ocelot
{
    public static class MergeOcelotConfiguration
    {
       public static JObject MergeOcelotConfigurationFiles(string directoryPath)
        {
            var mergedConfig = new JObject
            {
                ["Routes"] = new JArray(),
                ["GlobalConfiguration"] = null
            };

            var configFiles = Directory.GetFiles(directoryPath, "*.json");

            foreach (var file in configFiles)
            {
                var json = JObject.Parse(File.ReadAllText(file));

                // Merge Routes
                if (json["Routes"] is JArray routes)
                {
                    foreach (var route in routes)
                    {
                        ((JArray)mergedConfig["Routes"]).Add(route);
                    }
                }
                // Merge GlobalConfiguration (only one global configuration is allowed)
                if (json["GlobalConfiguration"] != null)
                {
                    mergedConfig["GlobalConfiguration"] ??= json["GlobalConfiguration"];
                }
            }
            return mergedConfig;
        }
    }
}
