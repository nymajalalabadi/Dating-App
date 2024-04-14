namespace Application.Senders.Mail
{
    public interface ISendMail
    {
        void Send(string to, string subject, string body);
    }

}
