using System.Text.RegularExpressions;

public static class UserValidation
{
    // to check the name, email, postion, Password if its null or empty
    public static bool isValidString(string userInput)
    {
        return !string.IsNullOrEmpty(userInput);
    }

    // check if the pssword length is less than 7
    public static bool isValidPassword(string password)
    {
        return password.Length > 7;
    }

    //check email validation
    public static bool isValidEmail(string email)
    {
        if (email == null)
        {
            return false;
        }
        bool isEmail = Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
RegexOptions.IgnoreCase);

        if (isEmail)
        {
            return true;
        }
        return false;
    }
}