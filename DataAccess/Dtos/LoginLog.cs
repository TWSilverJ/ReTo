using ReTo.Abstractions.Models;
using System.Net;

namespace ReTo.DataAccess.Dtos;

internal class LoginLog : ILoginLog
{
    public int SequentialID { get; set; }

    public Guid ID { get; set; }

    public Guid? UserID { get; set; }

    public DateTime LoginTime { get; set; }

    public IPAddress ClientIP { get; set; }

    public string UserAgent { get; set; }

    public bool IsSuccessful { get; set; }

    public bool IsRevoked { get; set; }

    public DateTime? ExpireAt { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
