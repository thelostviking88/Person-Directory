using PersonDirectory.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System;
using System.Threading;
using PersonDirectory.Application.Interfaces;
using PersonDirectory.Application.Models;


namespace PersonDirectory.Persistance.Repositories;

/// <inheritdoc/>
public class PersonRepository(PersonDbContext context) : IPersonRepository
{
    private readonly PersonDbContext _dbContext = context;

    /// <inheritdoc/>
    public async Task CreateAsync(Person person, CancellationToken cancellationToken)
    {
        await _dbContext.Persons.AddAsync(person, cancellationToken);
    }

    /// <inheritdoc/>
    public void Delete(Person person)
    {
        _dbContext.Persons.Remove(person);
    }

    /// <inheritdoc/>
    public async Task<Person> GetByIdAsync(int personId, CancellationToken cancellationToken)
    {
        return await _dbContext.Persons.Where(person => person.Id.Equals(personId)).FirstOrDefaultAsync(cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<Person>> GetByCondition(Expression<Func<Person, bool>> expression, CancellationToken cancellationToken)
    {
        return await _dbContext.Persons.Include(c => c.Connections).Include(p => p.Phones).Include(c=>c.City).Where(expression).AsNoTracking().ToListAsync(cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Person> GetPersonWithDetailsAsync(int personId, CancellationToken cancellationToken)
    {
        return await _dbContext.Persons
            .Where(person => person.Id.Equals(personId))
            .Include(p => p.City)
            .Include(p => p.Phones)
            .Include(p => p.Connections)
                .ThenInclude(c => c.ConnectedPerson)
            .Include(p => p.Connections)
                .ThenInclude(c => c.ConnectedPerson.City)
            .Include(p => p.Connections)
                .ThenInclude(c => c.ConnectedPerson.Phones)
            .FirstOrDefaultAsync(cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Person> GetAsync(int personId, CancellationToken cancellationToken)
    {
        return await _dbContext.Persons.Include(c => c.Connections).Include(p => p.Phones).Include(c => c.City).FirstOrDefaultAsync(f => f.Id == personId, cancellationToken);
    }

    /// <inheritdoc/>
    public void Update(Person person)
    {
        _dbContext.Persons.Update(person);
    }

    public IQueryable<Person> DetailedSearch(PersonSearchRequestDto searchRequest)
    {
        var query = _dbContext.Persons.Include(c => c.Connections).Include(p => p.Phones).Include(c => c.City).AsQueryable();

        if (!string.IsNullOrEmpty(searchRequest.FirstName))
            query = query.Where(p => p.FirstName.Contains(searchRequest.FirstName));

        if (!string.IsNullOrEmpty(searchRequest.LastName))
            query = query.Where(p => p.LastName.Contains(searchRequest.LastName));

        if (!string.IsNullOrEmpty(searchRequest.PrivateNumber))
            query = query.Where(p => p.PrivateNumber.Contains(searchRequest.PrivateNumber));

        if (!string.IsNullOrEmpty(searchRequest.PhoneNumber))
            query = query.Where(p => p.Phones.Any(a => a.Number.Equals(searchRequest.PhoneNumber)));

        if (!string.IsNullOrEmpty(searchRequest.City))
            query = query.Where(p => p.City.Name.Contains(searchRequest.City));

        if (searchRequest.Gender != null)
            query = query.Where(p => p.Gender == searchRequest.Gender);

        if (searchRequest.DateOfBirth != null)
            query = query.Where(p => p.DateOfBirth.Equals(searchRequest.DateOfBirth));

        return query;
    }
}
