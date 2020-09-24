using System;
using System.Threading.Tasks;

namespace NovacleanX.Services.ExceptionsManager
{
    public interface IExceptionsManager
    {
        Task ManageException(Exception exception);
    }
}
