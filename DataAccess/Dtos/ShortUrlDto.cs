using ReTo.Abstractions.Models;
using System.Net;

namespace ReTo.DataAccess.Dtos;

internal class ShortUrlDto : IShortUrl
{
    public int SequentialID { get; set; }

    public Guid ID { get; set; }

    public Guid? UserID { get; set; }

    public string ShortCode { get; set; }

    public string OriginalUrl { get; set; }

    public IPAddress ClientIP { get; set; }

    public string UserAgent { get; set; }

    public bool IsEnabled { get; set; }

    public DateTime? ExpireAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
