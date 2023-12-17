using ReTo.Abstractions.Dtos;
using ReTo.Abstractions.Models;
using ReTo.Abstractions.Repositories;
using ReTo.Abstractions.Services;
using ReTo.CoreLib.Models;
using BCryptHelper = BCrypt.Net.BCrypt;

namespace ReTo.CoreLib.Services;

public class AccountService(IAccountRepository accountRepository) : IAccountService
{
    private readonly IAccountRepository _accountRepository = accountRepository;

    public async Task<IEnumerable<IAccount>> GetAccountListAsync(IPagination pagination)
        => Enumerable.Empty<IAccount>();

    public Task<IAccount?> GetAccountByIdAsync(Guid id)
        => _accountRepository.GetAccountByIdAsync(id);

    public async Task<IAccount?> CreateAccountAsync(IAccountDto accountDto)
    {
        // 檢查是否重複
        var account = await _accountRepository.GetAccountByUsernameAsync(accountDto.Username);
        if (account != null)
            return null;

        // 建立實例
        account = new Account
        {
            Username = accountDto.Username,
            Password = BCryptHelper.HashPassword(accountDto.Password)
        };

        // 寫入資料庫
        await _accountRepository.AddAccountAsync(account);
        var changeCount = await _accountRepository.SaveChangeAsync();

        // 回傳實例
        if (changeCount > 0)
            return await _accountRepository.GetAccountByIdAsync(account.ID);
        return null;
    }

    public async Task<bool?> ChangePasswordAsync(Guid id, IAccountPasswordDto passwordDto)
    {
        // 取得實例
        var account = await _accountRepository.GetAccountByIdAsync(id);
        if (account is null)
            return null;

        // 檢查原始密碼
        var passwordVerificationResult = BCryptHelper.Verify(passwordDto.OriginalPassword, account.Password);
        if (!passwordVerificationResult)
            return false;

        // 記錄密碼變更
        var passwordChange = new AccountPasswordChange
        {
            AccountID = account.ID,
            OriginalPassword = passwordDto.OriginalPassword,
            ClientIP = passwordDto.ClientIP,
            UserAgent = passwordDto.UserAgent
        };
        await _accountRepository.AddPasswordChangeAsync(passwordChange);

        // 變更密碼
        account.Password = BCryptHelper.HashPassword(passwordDto.NewPassword);
        await _accountRepository.UpdateAccountAsync(account);

        // 寫入資料庫並回傳結果
        var changeCount = await _accountRepository.SaveChangeAsync();
        return changeCount > 0;
    }

    public async Task<IAccountLogin> LoginAsync(IAccountLoginDto loginDto)
    {
        // 建立登入
        var login = new AccountLogin
        {
            ClientIP = loginDto.ClientIP,
            UserAgent = loginDto.UserAgent,
        };

        // 取得實例
        var account = await _accountRepository.GetAccountByUsernameAsync(loginDto.Username);

        // 檢查密碼
        if (account != null && account.IsEnabled && account.DeletedAt is null)
        {
            login.AccountID = account.ID;
            login.IsSuccessful = DateTime.UtcNow < account.PasswordExpireAt
                && BCryptHelper.Verify(loginDto.Password, account.Password);
        }

        // 寫入資料庫
        await _accountRepository.AddLoginAsync(login);
        await _accountRepository.SaveChangeAsync();

        // 回傳登入結果
        return login;
    }

    public async Task<bool?> LogoutAsync(Guid loginId)
    {
        // 取得登入
        var login = await _accountRepository.GetLoginByIdAsync(loginId);
        if (login is null)
            return null;

        // 作廢登入
        login.IsRevoked = true;

        // 寫入資料庫並回傳結果
        await _accountRepository.UpdateLoginAsync(login);
        var changeCount = await _accountRepository.SaveChangeAsync();
        return changeCount > 0;
    }

    public Task<bool?> LogoutAllSessionsAsync(Guid accountId)
    {
        throw new NotImplementedException();
    }
}
