using System.Net;

namespace ReTo.Abstractions.Models;

public interface IClient
{
    /// <summary>
    /// 客戶端 IP
    /// </summary>
    IPAddress ClientIP { get; }

    /// <summary>
    /// 登入端代理
    /// </summary>
    string UserAgent { get; }
}
