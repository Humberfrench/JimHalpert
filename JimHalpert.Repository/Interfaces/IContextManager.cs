
using JimHalpert.Repository.Context;

namespace JimHalpert.Repository.Interfaces
{
    public interface IContextManager
    {
        JimHalpertContext GetContext();
        string GetConnectionString { get; }
    }
}