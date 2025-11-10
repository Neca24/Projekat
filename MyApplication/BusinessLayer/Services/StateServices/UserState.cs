using Microsoft.IdentityModel.Tokens;

namespace BusinessLayer.Services.StateServices
{
    public class UserState
    {
        public short? CurrentUserId { get; private set; }
        public string? CurrentUser { get; private set; }
        public int? CurrentUserRights { get; private set; }
        public bool IsAuthenticated => CurrentUserId.HasValue && CurrentUserRights.HasValue;

        public event Action? OnChange;
        public void SetUser(short? id, string? username, int? roleId)
        {
            CurrentUserId = id;
            CurrentUser = username;
            CurrentUserRights = roleId;
            NotifyStateChanged();
        }
        public void Clear()
        {
            CurrentUserId = null;
            CurrentUser = null;
            CurrentUserRights = null;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
