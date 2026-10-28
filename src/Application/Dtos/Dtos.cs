using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dtos
{
    public sealed record PostDto(int Id, int UserId, string Title, string Body);
    public sealed record GeoDto(string Lat, string Lng);
    public sealed record AddressDto(string Street, string Suite, string City, string Zipcode, GeoDto Geo);
    public sealed record UserDto(int Id, string Name, string Username, string Email,AddressDto AddressDto,GeoDto GeoDto, string Phone,Dictionary<string,string> Company);
}
