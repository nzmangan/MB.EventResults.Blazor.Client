namespace MB.EventResults.Blazor.Client;

public class DataClient(IDataService _DataService) : IDataClient {
  public async Task<SingleGradeResult> Get(Func<string> urlResolver) {
    return await _DataService.Get<SingleGradeResult>(urlResolver());
  }

  public async Task<List<EventGrade>> Grades(Func<string> urlResolver) {
    return await _DataService.Get<List<EventGrade>>(urlResolver());
  }
}