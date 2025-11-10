using BusinessLayer.ResultWrappers;

namespace BusinessLayer.Interfaces
{
    public interface IClientService
    {
        Task<bool> LogAsync(string ip);
    }
}
