using System.Text;

public static class PasswordHasher
{
    public static void createPasswordHash(string password, out byte[] PasswordHash, out byte[] PasswordSalt)
    {
        using (var h = new System.Security.Cryptography.HMACSHA512())
        {
            PasswordSalt = h.Key; // come from method sha512
            PasswordHash = h.ComputeHash(Encoding.UTF8.GetBytes(password)); //password => hashing
        }
    }
    public static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
    {
        using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
        {
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return computedHash.SequenceEqual(storedHash);
        }
    }
}
