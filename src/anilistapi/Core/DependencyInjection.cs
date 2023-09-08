using anilistapi.application;
using anilistapi.domain.Interfaces;
using anilistapi.domain.Models;
using anilistapi.infra;
using anilistapi.infra.rest;
using anilistapi.infra.Settings;

namespace anilistapi.Core;

public static class DependencyInjection
{
    public static void Inject(WebApplicationBuilder builder)
    {
        var anilistSettings = builder.Configuration.GetSection("AnilistSettings").Get<AnilistSettings>();
        builder.Services.AddSingleton<IAnilistSettings>(anilistSettings);
        builder.Services.AddScoped<IGraphqlRepository<Media>, AnilistGraphqlRepository>();
        builder.Services.AddScoped<IGenericRepository<Media>, AnilistRepository>();
        builder.Services.AddScoped<IAnilistService, AnilistService>();
    }
}