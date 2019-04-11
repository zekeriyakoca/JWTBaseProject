namespace BaseJWT.Service.Interface
{
  public interface IMailService
  {
    void SendMessage(string to, string subject, string body);
  }
}