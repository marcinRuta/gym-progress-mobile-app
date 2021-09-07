namespace ClientApi.Application.Commands
{
    public class AddUserDetailsCommand
    {
        public string Name { get; set; }
        public string Surname { get;  set; }
        public string Email { get;  set; }
        public string TelephoneNumber { get; set; }
    }
}