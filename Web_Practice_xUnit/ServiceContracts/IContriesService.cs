using ServiceContracts.DTO;

namespace ServiceContracts
{
	public interface IContriesService
	{
		/// <summary>
		/// Adds the country.
		/// </summary>
		/// <param name="request">The request.</param>
		/// <returns></returns>
		CountryResponse AddCountry(CountryAddRequest? request);

		/// <summary>
		/// Gets all countries.
		/// </summary>
		/// <returns></returns>
		List<CountryResponse> GetAllCountries();
	}
}