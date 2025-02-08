using System;
using ServiceContracts.DTO;
using ServiceContracts.Enums;

namespace ServiceContracts
{
	/// <summary>
	/// Represents business logic for manipulating Perosn entity
	/// </summary>
	public interface IPersonsService
	{
		/// <summary>
		/// Addds a new person into the list of persons
		/// </summary>
		/// <param name="personAddRequest">Person to add</param>
		/// <returns>Returns the same person details, along with newly generated PersonID</returns>
		PersonResponse AddPerson(PersonAddRequest? personAddRequest);

		/// <summary>
		/// Returns all persons
		/// </summary>
		/// <returns>Returns a list of objects of PersonResponse type</returns>
		List<PersonResponse> GetAllPersons();

		/// <summary>
		/// Returns the person object based on the given person id
		/// </summary>
		/// <param name="personID">Person id to search</param>
		/// <returns>Returns matching person object</returns>
		PersonResponse? GetPersonByPersonID(Guid? personID);

		/// <summary>
		/// Gets the filtered persons.
		/// </summary>
		/// <param name="searchBy">The search by.</param>
		/// <param name="searchString">The search string.</param>
		/// <returns></returns>
		List<PersonResponse> GetFilteredPersons(string searchBy, string? searchString);

		/// <summary>
		/// Gets the sorted persons.
		/// </summary>
		/// <param name="allPersons">All persons.</param>
		/// <param name="sortBy">The sort by.</param>
		/// <param name="sortOrder">The sort order.</param>
		/// <returns></returns>
		List<PersonResponse> GetSortedPersons(List<PersonResponse> allPersons, string sortBy, SortOrderOptions sortOrder);
	}
}