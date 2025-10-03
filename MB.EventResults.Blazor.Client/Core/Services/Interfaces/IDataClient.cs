namespace MB.EventResults.Blazor.Client;

public interface IDataClient {
  Task<SingleGradeResult> Get(Func<string, string> urlResolver, string classId);
  Task<List<EventGrade>> Grades(Func<string> urlResolver);
}