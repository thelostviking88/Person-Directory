using System;
using System.Threading.Tasks;

namespace PersonDirectory.Persistance.Interfaces;

    public  interface IUnitOfWork : IDisposable
    {
        IPersonRepository PersonRepository { get; }
        IPhoneRepository PhoneRepository { get; }
        IConnectionRepository ConnectionRepository { get; }
        Task<int> CommitAsync();
    }
