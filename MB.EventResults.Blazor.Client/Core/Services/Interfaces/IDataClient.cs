namespace MB.EventResults.Blazor.Client;

public interface IDataClient {
  Task<SingleGradeResult> Get(Func<string> urlResolver);
  Task<List<EventGrade>> Grades(Func<string> urlResolver);
}