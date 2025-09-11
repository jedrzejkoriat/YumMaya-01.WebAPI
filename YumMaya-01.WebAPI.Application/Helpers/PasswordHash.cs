namespace YumMaya_01.WebAPI.Application.Helpers;

public static class PasswordHash
{
    public static bool VerifyPassword(string providedPassword, string hashedPassword)
    {
        return BCrypt.Net.BCrypt.Verify(providedPassword, hashedPassword);
    }
}