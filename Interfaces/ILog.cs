using D3___Avaliação.Models;

namespace D3___Avaliação.Interfaces
{
    internal interface ILog
    {
        void RegisterAccess(User user);
        void RegisterLogout(User user);
    }
}
