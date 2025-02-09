﻿using Entities;
using ServiceContracts;
using ServiceContracts.DTO;

namespace Service
{
	public class CountryService : IContriesService
	{
		private readonly List<Country> _countries;

		public CountryService()
		{
			_countries = new List<Country>();
		}

		public List<CountryResponse> GetAllCountries()
		{
			return _countries.Select(country => country.ToCountryResponse()).ToList();
		}

		CountryResponse IContriesService.AddCountry(CountryAddRequest? request)
		{
			if (request == null) throw new ArgumentNullException(nameof(request));
			if (request.CountryName == null) throw new ArgumentException(nameof(request.CountryName));
			if (_countries.Where(temp => temp.CountryName == request.CountryName).Count() > 0)
			{
				throw new ArgumentException("Duplicated country name");
			}
			Country? country = request.ToCountry();
			country.countryID = Guid.NewGuid();
			_countries.Add(country);

			return country.ToCountryResponse();
		}

		public CountryResponse? GetCountryByCountryID(Guid? countryID)
		{
			if (countryID == null)
				return null;

			Country? country_response_from_list = _countries.FirstOrDefault(temp => temp.countryID == countryID);

			if (country_response_from_list == null)
				return null;

			return country_response_from_list.ToCountryResponse();
		}
	}
}