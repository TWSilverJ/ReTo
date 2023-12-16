using ReTo.Abstractions.Models;
using System.Net;

namespace CoreLib.Models;

internal class ShortUrl : SoftdeleteableModel, IShortUrl
{
    public Guid? UserID { get; set; }

    public string ShortCode { get; set; }

    public string OriginalUrl { get; set; }

    public IPAddress ClientIP { get; set; }

    public string UserAgent { get; set; }

    public bool IsEnabled { get; set; } = true;

    public DateTime? ExpireAt { get; set; }
}
