using ReTo.Abstractions.Models;

namespace ReTo.DataAccess.Dtos;

internal class AccountDto : IAccount
{
    public int SequentialID { get; set; }

    public Guid ID { get; set; }

    public string Username { get; set; }

    public string Password { get; set; }

    public DateTime? PasswordExpireAt { get; set; }

    public bool IsEnabled { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }
}
