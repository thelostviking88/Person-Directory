using PersonDirectory.Application.Interfaces;
using PersonDirectory.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonDirectory.Persistance.Repositories;

public class PhoneRepository(PersonDbContext context) : IPhoneRepository
{
    private readonly PersonDbContext _dbContext = context;

    public async Task AddAsync(Phone phone)
    {
        await _dbContext.Phones.AddAsync(phone);
    }
    public void DeleteMany(IEnumerable<Phone> phones)
    {
        _dbContext.Phones.RemoveRange(phones);
    }
}