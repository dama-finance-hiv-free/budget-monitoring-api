using Microsoft.Extensions.Configuration;

namespace Dama.Fin.API.Core;

public static class ConfigurationExtensions
{
    public static bool IsMessageProcessingEnabled(this IConfiguration config) => config.GetValue<bool>("Features:MessageProcessing:MessageProcessing");
}