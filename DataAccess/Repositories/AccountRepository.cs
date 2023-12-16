using Microsoft.EntityFrameworkCore;
using ReTo.Abstractions.Models;
using ReTo.Abstractions.Repositories;
using ReTo.DataAccess.Dtos;
using ReTo.DataAccess.Models;
using System.Net;

namespace ReTo.DataAccess.Repositories;

public class AccountRepository(ReToContext context)
    : Repository(context), IAccountRepository
{
    private readonly ReToContext _context = context;

    #region Query
    public async Task<IAccount?> GetAccountByIdAsync(Guid id)
    {
        // 建立查詢語法
        var query = BuildAccountQuery()
            .Where(x => x.ID == id);

        // 產生搜尋結果
        return await query.FirstOrDefaultAsync();
    }

    public async Task<IAccount?> GetAccountByUsernameAsync(string username)
    {
        // 建立查詢語法
        var query = BuildAccountQuery()
            .Where(x => x.Username == username);

        // 產生搜尋結果
        return await query.FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<IAccountLogin>> GetLoginListAsync(Guid? accountId)
    {
        // 建立查詢語法
        var query = BuildLoginQuery();

        // 條件篩選
        if (accountId != null)
            query = query.Where(x => x.AccountID == accountId);

        // 產生搜尋結果
        return await query.ToListAsync();
    }

    public async Task<IAccountLogin?> GetLoginByIdAsync(Guid id)
    {
        // 建立查詢語法
        var query = BuildLoginQuery()
            .Where(x => x.ID == id);

        // 產生搜尋結果
        return await query.FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<IAccountPasswordChange>> GetPasswordChangeListAxync(Guid? accountId)
    {
        // 建立查詢語法
        var query = BuildPasswordChangeQuery();

        // 條件篩選
        if (accountId != null)
            query = query.Where(x => x.AccountID == accountId);

        // 產生搜尋結果
        return await query.ToListAsync();
    }
    #endregion
    #region Account
    public async Task AddAccountAsync(IAccount account)
    {
        // 建立實例
        var entity = new Account
        {
            Id = account.ID,
            Username = account.Username,
            Password = account.Password,
            PasswordExpireAt = account.PasswordExpireAt,
            IsEnabled = account.IsEnabled,
            CreatedAt = GetCurrentDateTime()
        };

        // 加入資料表
        await _context.Accounts.AddAsync(entity);
    }

    public async Task UpdateAccountAsync(IAccount account)
    {
        // 取得實例
        var entity = await _context.Accounts.FindAsync(account.ID);
        if (entity is null)
            return;

        // 更新實例
        entity.Username = account.Username;
        entity.Password = account.Password;
        entity.PasswordExpireAt = account.PasswordExpireAt;
        entity.IsEnabled = account.IsEnabled;
        entity.UpdatedAt = GetCurrentDateTime();
    }

    public async Task DeleteAccountAsync(Guid id, bool isSoft = false)
    {
        // 取得實例
        var entity = await _context.Accounts.FindAsync(id);
        if (entity is null)
            return;

        // 刪除實例或標記刪除
        if (!isSoft)
            _context.Accounts.Remove(entity);
        else
            entity.DeletedAt ??= GetCurrentDateTime();
    }

    public async Task RestoreAccountAdync(Guid id)
    {
        // 取得實例
        var entity = await _context.Accounts.FindAsync(id);
        if (entity is null)
            return;

        // 還原軟刪除項目
        entity.DeletedAt = null;
    }
    #endregion
    #region AccountLogin
    public async Task AddLoginAsync(IAccountLogin login)
    {
        // 建立實例
        var entity = new AccountLogin
        {
            Id = login.ID,
            AccountId = login.AccountID,
            LoginTime = login.LoginTime,
            ClientIp = login.ClientIP.ToString(),
            UserAgent = login.UserAgent,
            IsSuccessful = login.IsSuccessful,
            IsRevoked = login.IsRevoked,
            ExpireAt = login.ExpireAt,
            CreatedAt = GetCurrentDateTime()
        };

        // 加入資料表
        await _context.AccountLogins.AddAsync(entity);
    }

    public async Task UpdateLoginAsync(IAccountLogin login)
    {
        // 取得實例
        var entity = await _context.AccountLogins.FindAsync(login.ID);
        if (entity is null)
            return;

        // 更新實例
        entity.IsRevoked = login.IsRevoked;
        entity.ExpireAt = login.ExpireAt;
        entity.UpdatedAt = GetCurrentDateTime();
    }
    #endregion
    #region AccountPasswordChange
    public async Task AddPasswordChangeAsync(IAccountPasswordChange passwordChange)
    {
        // 建立實例
        var entity = new AccountPasswordChange
        {
            Id = passwordChange.ID,
            AccountId = passwordChange.AccountID,
            ChangeTime = passwordChange.ChangeTime,
            OriginalPassword = passwordChange.OriginalPassword,
            ClientIp = passwordChange.ClientIP.ToString(),
            UserAgent = passwordChange.UserAgent,
            CreatedAt = GetCurrentDateTime()
        };

        // 加入資料表
        await _context.AccountPasswordChanges.AddAsync(entity);
    }
    #endregion

    #region 私有方法
    /// <summary>
    /// 建立 Account 查詢語法
    /// </summary>
    /// <returns>Query</returns>
    private IQueryable<AccountDto> BuildAccountQuery()
    {
        var query = from account in _context.Accounts.AsNoTracking()
                    select new AccountDto
                    {
                        SequentialID = account.SequentialId,
                        ID = account.Id,
                        Username = account.Username,
                        Password = account.Password,
                        PasswordExpireAt = account.PasswordExpireAt,
                        IsEnabled = account.IsEnabled,
                        CreatedAt = account.CreatedAt,
                        UpdatedAt = account.UpdatedAt,
                        DeletedAt = account.DeletedAt
                    };
        return query;
    }

    /// <summary>
    /// 建立 LoginLog 查詢語法
    /// </summary>
    /// <returns>Query</returns>
    private IQueryable<AccountLoginDto> BuildLoginQuery()
    {
        var query = from login in _context.AccountLogins.AsNoTracking()
                    select new AccountLoginDto
                    {
                        SequentialID = login.SequentialId,
                        ID = login.Id,
                        AccountID = login.AccountId,
                        LoginTime = login.LoginTime,
                        ClientIP = IPAddress.Parse(login.ClientIp),
                        UserAgent = login.UserAgent,
                        IsSuccessful = login.IsSuccessful,
                        IsRevoked = login.IsRevoked,
                        ExpireAt = login.ExpireAt,
                        CreatedAt = login.CreatedAt,
                        UpdatedAt = login.UpdatedAt
                    };
        return query;
    }

    /// <summary>
    /// 建立 PasswordLog 查詢語法
    /// </summary>
    /// <returns>Query</returns>
    private IQueryable<AccountPasswordChangeDto> BuildPasswordChangeQuery()
    {
        var query = from passwordChange in _context.AccountPasswordChanges.AsNoTracking()
                    select new AccountPasswordChangeDto
                    {
                        SequentialID = passwordChange.SequentialId,
                        ID = passwordChange.Id,
                        AccountID = passwordChange.AccountId,
                        ChangeTime = passwordChange.ChangeTime,
                        OriginalPassword = passwordChange.OriginalPassword,
                        ClientIP = IPAddress.Parse(passwordChange.ClientIp),
                        UserAgent = passwordChange.UserAgent,
                        CreatedAt = passwordChange.CreatedAt,
                        UpdatedAt = passwordChange.UpdatedAt
                    };
        return query;
    }
    #endregion
}
