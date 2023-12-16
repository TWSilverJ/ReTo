using ReTo.Abstractions.Models;

namespace CoreLib.Models;

internal class Account : SoftdeleteableModel, IAccount
{
    public string Username { get; set; }

    public string Password { get; set; }

    public DateTime? PasswordExpireAt { get; set; }

    public bool IsEnabled { get; set; } = true;
}
