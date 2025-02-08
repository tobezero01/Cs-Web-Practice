namespace Entities
{
	/// <summary>
	/// Coutries
	/// </summary>
	public class Country
	{
		public Guid CountryId { get; set; }
		public string? CountryName { get; set; }

		public Country(string? countryName)
		{
			CountryName = countryName;
		}

		public Country()
		{
		}
	}
}