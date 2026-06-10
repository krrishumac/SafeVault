using System.Text.RegularExpressions;

namespace SafeVault.Helpers
{
    public static class InputValidator
    {
        public static string SanitizeInput(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            input = Regex.Replace(input, "<.*?>", string.Empty);

            input = input.Replace("'", "")
                         .Replace("\"", "")
                         .Replace(";", "")
                         .Replace("--", "");

            return input.Trim();
        }
    }
}