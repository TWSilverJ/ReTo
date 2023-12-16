using System.Text;

namespace ReTo.CoreLib.Utilities;

internal static class RandomMagic
{
    private const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
    private static readonly Random _random = new();

    /// <summary>
    /// 產生指定長度的隨機字串
    /// </summary>
    /// <param name="length">指定長度</param>
    /// <returns>隨機字串</returns>
    public static string GenerateRandomString(int length)
    {
        var result = new StringBuilder(length);
        for (int i = 0; i < length; i++)
        {
            int index = _random.Next(chars.Length);
            result.Append(chars[index]);
        }
        return result.ToString();
    }
}
