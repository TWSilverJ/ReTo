using ReTo.Abstractions.Models;

namespace ReTo.DataAccess.Dtos;

internal class UserDto : IUser
{
    public int SequentialID { get; set; }

    public Guid ID { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }

    public bool IsEmailVerified { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }
}
