using System.Text.RegularExpressions;

namespace Xinder.Validators
{
    public static class LoginValidator
    {
        public static bool EmailValidator(string email)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            return match.Success;
        }
    }
}
