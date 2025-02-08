using Service;
using ServiceContracts;
using ServiceContracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUnitTest
{
	public class CountriesServiceTest
	{
		private readonly IContriesService _countriesService;

		public CountriesServiceTest()
		{
			_countriesService = new CountryService();
		}

		#region AddCountry

		[Fact]
		public void AddCountry_NullCountry()
		{
			CountryAddRequest? request = null;

			Assert.Throws<ArgumentNullException>(() =>
			{
				_countriesService.AddCountry(request);
			});
		}

		[Fact]
		public void AddCountry_CountryNameIsNull()
		{
			CountryAddRequest? request = new CountryAddRequest() { CountryName = null };

			Assert.Throws<ArgumentException>(() =>
			{
				_countriesService.AddCountry(request);
			});
		}

		[Fact]
		public void AddCountry_DuplicatedCountryName()
		{
			CountryAddRequest? request = new CountryAddRequest() { CountryName = "vietnam" };
			CountryAddRequest? request2 = new CountryAddRequest() { CountryName = "vietnam" };

			Assert.Throws<ArgumentException>(() =>
			{
				_countriesService.AddCountry(request2);
				_countriesService.AddCountry(request);
			});
		}

		[Fact]
		public void AddCountry_ProperCountryDetails()
		{
			//Arrange
			CountryAddRequest? request = new CountryAddRequest() { CountryName = "Japan" };

			//Act
			CountryResponse response = _countriesService.AddCountry(request);

			//Assert
			Assert.True(response.CountryID != Guid.Empty);
		}

		#endregion AddCountry

		#region GetAllCountries

		[Fact]
		public void GetAllCountries_EmptyList()
		{
			//Act
			List<CountryResponse> actual_country_response_list = _countriesService.GetAllCountries();

			//Assert
			Assert.Empty(actual_country_response_list);
		}

		[Fact]
		public void GetAllCountries_AddFewCountries()
		{
			//Arrange
			List<CountryAddRequest> country_request_list = new List<CountryAddRequest>() {
				new CountryAddRequest() { CountryName = "USA" },
				new CountryAddRequest() { CountryName = "UK" }
			};

			//Act
			List<CountryResponse> countries_list_from_add_country = new List<CountryResponse>();

			foreach (CountryAddRequest country_request in country_request_list)
			{
				countries_list_from_add_country.Add(_countriesService.AddCountry(country_request));
			}

			List<CountryResponse> actualCountryResponseList = _countriesService.GetAllCountries();

			//read each element from countries_list_from_add_country
			foreach (CountryResponse expected_country in countries_list_from_add_country)
			{
				Assert.Contains(expected_country, actualCountryResponseList);
			}
		}

		#endregion GetAllCountries
	}
}