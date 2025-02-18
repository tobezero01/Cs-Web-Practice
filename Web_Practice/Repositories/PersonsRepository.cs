using Entities;
using Entities.Data;
using Microsoft.EntityFrameworkCore;
using RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
	public class PersonsRepository : IPersonsRepository
	{
		private readonly ApplicationDbContext _context;

		public PersonsRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<Person> AddPerson(Person person)
		{
			_context.Persons.Add(person);
			await _context.SaveChangesAsync();
			return person;
		}

		public async Task<bool> DeletePersonByPersonID(Guid personID)
		{
			_context.Persons.RemoveRange(_context.Persons.Where(temp => temp.PersonID == personID));
			int rowsDeleted = await _context.SaveChangesAsync();

			return rowsDeleted > 0;
		}

		public async Task<List<Person>> GetAllPersons()
		{
			return await _context.Persons.Include("Country").ToListAsync();
		}

		public async Task<List<Person>> GetFilteredPersons(Expression<Func<Person, bool>> predicate)
		{
			return await _context.Persons.Include("Country")
					.Where(predicate)
					.ToListAsync();
		}

		public async Task<Person?> GetPersonByPersonID(Guid personID)
		{
			return await _context.Persons.Include("Country")
				.FirstOrDefaultAsync(temp => temp.PersonID == personID);
		}

		public async Task<Person> UpdatePerson(Person person)
		{
			Person? matchingPerson = await _context.Persons.FirstOrDefaultAsync(temp => temp.PersonID == person.PersonID);

			if (matchingPerson == null)
				return person;

			matchingPerson.PersonName = person.PersonName;
			matchingPerson.Email = person.Email;
			matchingPerson.DateOfBirth = person.DateOfBirth;
			matchingPerson.Gender = person.Gender;
			matchingPerson.CountryID = person.CountryID;
			matchingPerson.Address = person.Address;
			matchingPerson.ReceiveNewsLetters = person.ReceiveNewsLetters;

			int countUpdated = await _context.SaveChangesAsync();

			return matchingPerson;
		}
	}
}