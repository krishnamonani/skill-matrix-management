using System;
using System.Linq;
using System.Security.Cryptography;

namespace SkillMatrixManagement.Utils
{
    public static class PasswordGenerator
    {
        public static string GenerateRandomPassword(int length = 10)
        {
            // Ensure minimum length is 6 characters
            if (length < 6)
            {
                length = 6;
            }

            const string lowerChars = "abcdefghijklmnopqrstuvwxyz";
            const string upperChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string numberChars = "0123456789";
            const string specialChars = "!@#$%^&*()-_=+[]{}|;:,.<>?";

            // Ensure we have at least one of each character type
            var password = new char[length];
            
            using (var rng = RandomNumberGenerator.Create())
            {
                byte[] randomBytes = new byte[4];

                // Add at least one lowercase character
                rng.GetBytes(randomBytes);
                password[0] = lowerChars[randomBytes[0] % lowerChars.Length];

                // Add at least one uppercase character
                rng.GetBytes(randomBytes);
                password[1] = upperChars[randomBytes[0] % upperChars.Length];

                // Add at least one digit
                rng.GetBytes(randomBytes);
                password[2] = numberChars[randomBytes[0] % numberChars.Length];

                // Add at least one special character
                rng.GetBytes(randomBytes);
                password[3] = specialChars[randomBytes[0] % specialChars.Length];

                // Fill the rest of the password with random characters from all groups
                string allChars = lowerChars + upperChars + numberChars + specialChars;
                for (int i = 4; i < length; i++)
                {
                    rng.GetBytes(randomBytes);
                    password[i] = allChars[randomBytes[0] % allChars.Length];
                }
            }

            // Shuffle the password characters
            return new string(password.OrderBy(x => Guid.NewGuid()).ToArray());
        }
    }
}
