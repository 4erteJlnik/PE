namespace Web1.PostForms
{
    public class SignInForm
    {
        public string Password { get; set; }
        public string Email { get; set; }
        public SignInForm(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}