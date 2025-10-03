namespace MB.EventResults.Blazor.Client;

public static class HostingExtensions {
  public static IServiceCollection AddEventResultsBlazorClient(this IServiceCollection services) {
    services
      .AddScoped<IJsonSerializerService, JsonSerializerService>()
      .AddScoped<ITextService, TextService>()
      .AddScoped<IMenuService, MenuService>()
      .AddScoped<IClassPerformanceIndexNormalizedGraphService, ClassPerformanceIndexNormalizedGraphService>()
      .AddScoped<IClassPerformanceIndexHistogramNormalizedGraphService, ClassPerformanceIndexHistogramNormalizedGraphService>()
      .AddScoped<IClassPerformanceIndexHistogramGraphService, ClassPerformanceIndexHistogramGraphService>()
      .AddScoped<IClassPerformanceIndexGraphService, ClassPerformanceIndexGraphService>()
      .AddScoped<IClassMistakeTotalGraphService, ClassMistakeTotalGraphService>()
      .AddScoped<IMistakeGraphService, MistakeGraphService>()
      .AddScoped<IMistakeTotalGraphService, MistakeTotalGraphService>()
      .AddScoped<IPackGraphService, PackGraphService>()
      .AddScoped<IPerformanceIndexGraphService, PerformanceIndexGraphService>()
      .AddScoped<IPerformanceIndexHistogramGraphService, PerformanceIndexHistogramGraphService>()
      .AddScoped<IPerformanceIndexHistogramNormalizedGraphService, PerformanceIndexHistogramNormalizedGraphService>()
      .AddScoped<IPerformanceIndexNormalizedGraphService, PerformanceIndexNormalizedGraphService>()
      .AddScoped<IPositionLegGraphService, PositionLegGraphService>()
      .AddScoped<IPositionTotalGraphService, PositionTotalGraphService>()
      .AddScoped<ITimeGraphService, TimeGraphService>()
      .AddScoped<IDataClient, DataClient>()
      .AddScoped<IDataService, DataService>()
      .AddScoped<IStatsCalculator, StatsCalculator>()
      .AddScoped<IGraphRenderingService, GraphRenderingService>()
      .AddScoped<IGraphOptionsService, GraphOptionsService>();

    return services;
  }
}