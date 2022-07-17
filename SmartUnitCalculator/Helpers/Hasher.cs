namespace SmartUnitCalculator.Helpers
{
    public static class Hasher
    {
        public static string Hash(string input)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                return Convert.ToHexString(hashBytes);
            }
        }

        public static bool Verify(string input, string hash) => Hash(input) == hash;
    }
}
