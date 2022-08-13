namespace Portal.Application.Services.Config
{
    internal class ConfigService : IConfigService
    {
        public string GetSetting(string key)
        {
            return ConfigurationManager.AppSettings[key] ?? string.Empty;
        }
    }
}
