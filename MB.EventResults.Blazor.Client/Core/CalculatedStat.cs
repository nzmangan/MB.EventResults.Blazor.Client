namespace MB.EventResults.Blazor.Client.Pages;

public class CalculatedStat {
  public Stat<double?> KmRate { get; set; }
  public Stat<double?> PerformanceIndex { get; set; }
  public Stat<double?> ActualTime { get; set; }
  public Stat<double?> LegTime { get; set; }
  public Stat<double?> PerformanceIndexAdjusted { get; set; }
  public Stat<double?> TimeLoss { get; set; }
  public int Leg { get; set; }
}