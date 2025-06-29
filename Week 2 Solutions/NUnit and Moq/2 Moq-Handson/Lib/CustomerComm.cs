namespace CustomerCommLib
{
    public class CustomerComm
    {
        private readonly IMailSender _mailSender;

        public CustomerComm(IMailSender mailSender)
        {
            _mailSender = mailSender;
        }

        public bool SendMailToCustomer()
        {
            string customerEmail = "cust123@abc.com";
            string message = "Some Message";

            _mailSender.SendMail(customerEmail, message);

            return true;
        }
    }
}
