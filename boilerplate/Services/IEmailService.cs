namespace boilerplate.Services
{
    public interface IEmailService
    {
        /// <summary>
        /// Sends Emails Asynchronesly
        /// </summary>
        /// <param name="to"></param>
        /// <param name="subject"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        Task SendEmailAsync(string[] to, string subject, string content);
    }
}
