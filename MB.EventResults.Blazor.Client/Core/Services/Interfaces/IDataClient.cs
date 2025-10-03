namespace MB.EventResults.Blazor.Client;

public interface IDataClient {
  Task<SingleGradeResult> Get(string id);
  Task<List<EventGrade>> Grades();
}