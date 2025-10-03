namespace MB.EventResults.Blazor.Client;

public interface IStatsCalculator {
  Stat<double?> CalculateStat(IEnumerable<double?> enumerable);
}