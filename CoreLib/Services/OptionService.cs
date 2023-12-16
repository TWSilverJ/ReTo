using ReTo.Abstractions.Repositories;
using ReTo.Abstractions.Services;
using ReTo.CoreLib.Models;

namespace ReTo.CoreLib.Services;

public class OptionService(IOptionRepository optionRepository) : IOptionService
{
    private readonly IOptionRepository _optionRepository = optionRepository;

    public async Task<IDictionary<string, string?>> GetOptionsAsync()
    {
        // 取得列表
        var list = await _optionRepository.GetOptionListAsync();

        // 產生字典
        var options = new Dictionary<string, string?>();
        foreach (var option in list)
        {
            options[option.Name] = option.Value;
        }
        return options;
    }

    public async Task<bool> SetOptionsAsync(IDictionary<string, string?> options)
    {
        // 更新實例
        foreach (var item in options)
        {
            var option = await _optionRepository.GetOptionByNameAsync(item.Key);
            if (option != null)
            {
                option.Value = item.Value;
                option.UpdaterID = null;
            }
            else
            {
                option = new Option
                {
                    Name = item.Key,
                    Value = item.Value
                };
                await _optionRepository.AddOptionAsync(option);
            }
        }

        // 寫入資料庫並回傳結果
        var changeCount = await _optionRepository.SaveChangeAsync();
        return changeCount > 0;
    }
}
