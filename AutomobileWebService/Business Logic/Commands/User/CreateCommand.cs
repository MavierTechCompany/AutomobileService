namespace AutomobileWebService.Business_Logic.Commands.User
{
    public class CreateCommand
    {
        public string Login { get; set; }
        public string Email { get; set; }
        public string MobilePhone { get; set; }
        public string Password { get; set; }
    }
}