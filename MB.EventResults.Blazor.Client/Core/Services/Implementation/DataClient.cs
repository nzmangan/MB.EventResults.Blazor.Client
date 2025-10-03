namespace MB.EventResults.Blazor.Client;

public class DataClient(IDataService _DataService) : IDataClient {
  public async Task<SingleGradeResult> Get(string id) {
    return await _DataService.Get<SingleGradeResult>(UrlConstants.GetClass.Replace("{id}", id));
  }

  public async Task<List<EventGrade>> Grades() {
    return await _DataService.Get<List<EventGrade>>(UrlConstants.Grades);
  }
}