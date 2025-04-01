﻿using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Options;

namespace TodosApi;

internal class AppSettings
{
    [Required(ErrorMessage = """
                 Connection string not found.
                 If running locally, set the connection string in user secrets for key 'AppSettings:ConnectionString'.
                 If running after deployment, set the connection string via the environment variable 'APPSETTINGS__CONNECTIONSTRING'.
                 """)]
    public required string ConnectionString { get; set; }

    public string? JwtSigningKey { get; set; }

    public bool SuppressDbInitialization { get; set; }
}

[OptionsValidator]
internal partial class AppSettingsValidator : IValidateOptions<AppSettings>
{
}

internal static class AppSettingsExtensions
{
    public static IServiceCollection ConfigureAppSettings(this IServiceCollection services, IConfigurationRoot configurationRoot, IHostEnvironment hostEnvironment)
    {
        var optionsBuilder = services.AddOptions<AppSettings>()
            .BindConfiguration(nameof(AppSettings));

        if (!hostEnvironment.IsBuild())
        {
            services.AddSingleton<IValidateOptions<AppSettings>, AppSettingsValidator>();
            optionsBuilder.ValidateOnStart();
        }

        return services;
    }
}
