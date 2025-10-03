namespace MB.EventResults.Blazor.Client;

public interface IGraphTypeService<T> {
  string ChartType { get; }
  string OptionType { get; }
  List<string> GetLabels(GradeResult gradeResult);
  List<DataSerie<T>> GetDataSeries(GradeResult gradeResult);
}