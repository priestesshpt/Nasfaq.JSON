namespace Nasfaq.JSON
{
    //api/changeEmail
    public class ChangeEmail
    {
        public ChangeEmail(string email)
        {
            this.email = email;
        }

        public string email { get; set; }
    }
}