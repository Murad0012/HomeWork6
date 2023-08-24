using System.Text.RegularExpressions;

namespace ConsoleApp2
{
    class ShortEmailException : Exception
    {
        public ShortEmailException(string message) : base(message) { }
    }

    class NotAnEmailAdressException : Exception
    {
        public NotAnEmailAdressException(string message) : base(message) { }
    }

    public class EmailValidator
    {
        public bool Validate(string mail)
        {
            if (mail.Length < 10)
            {
                throw new ShortEmailException("Email address is too short.");
            }

            Regex emailRegEx = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
            if (emailRegEx.IsMatch(mail))
            {
                return true;
            }
            else
            {
                throw new NotAnEmailAdressException("It is not email");
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var emailValidator = new EmailValidator();
            try
            {
                bool isValid = emailValidator.Validate("ali.aliyev@gmail.com");
                Console.WriteLine(isValid);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}