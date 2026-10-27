using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;
using Application.Dtos;
using Application.Interfaces.Builder;
using Domain.Entities;

namespace Application.Builders
{
    public class AdressBuilder:IBuilder<Address>
    {
        private string _street = string.Empty;
        private string _suite = string.Empty;
        private string _city = string.Empty;
        private string _zipCode = string.Empty;
        private string _lat = "0";
        private string _lng = "0";
        public AdressBuilder WithStreet(string? street)
        {
            _street = street ?? string.Empty;
            return this;
        }
        public AdressBuilder WithSuite(string? suite)
        {
            _suite = suite ?? string.Empty;
            return this;
        }
        public AdressBuilder WithCity(string? city)
        {
            _city = city?? string.Empty;
            return this;
        }
        public AdressBuilder WithZipCode(string? zipCode)
        {
            _zipCode = zipCode ?? string.Empty;
            return this;
        }
        public AdressBuilder WithLat(string? lat)
        {
            _lat = lat ?? string.Empty;
            return this;
        }
        public AdressBuilder WithLng(string? lng)
        {
            _lng = lng ?? string.Empty;
            return this;
        }
        public AdressBuilder WithGeo(string? lat,string? lng)
        {
            _lat = lat ?? string.Empty;
            _lng = lng ?? string.Empty;
            return this;
        }
        public AdressBuilder FromDto(AddressDto dto)
        {
            if (dto is null) return this;
            _street = dto.Street ?? string.Empty;
            _suite = dto.Suite ?? string.Empty;
            _city = dto.City ?? string.Empty;
            _zipCode = dto.Zipcode ?? string.Empty;
            _lat = dto.Geo?.Lat ?? "0";
            _lng = dto.Geo?.Lng ?? "0";

            return this;
        }
        public Address Build()
        {
            var geoDict = new Dictionary<string, string>() 
            {
                ["lat"] =_lat,
                ["lng"] = _lng,
            };
            return new Address(_street,_suite,_city,_zipCode,geoDict);
        }



    }
}
