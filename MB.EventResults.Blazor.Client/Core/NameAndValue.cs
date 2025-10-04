namespace MB.EventResults.Blazor.Client;

public class NameAndValue<T> {
  public string FirstName { get; set; }
  public string LastName { get; set; }
  public T Value { get; set; }
  public string Club { get; set; }
}