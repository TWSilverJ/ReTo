using ReTo.Abstractions.Models;

namespace ReTo.CoreLib.Models;

internal class User : SoftdeleteableModel, IUser
{
    public string Name { get; set; }

    public string Email { get; set; }

    public bool IsEmailVerified { get; set; } = false;
}
