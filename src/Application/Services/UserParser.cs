using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Text.Json;
using Application.Builders;
using Application.Dtos;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Services
{
    internal class UserParser:IUserParser
    {
        private static readonly JsonSerializerOptions Options = new()
        {
            PropertyNameCaseInsensitive = true
        };
        public async Task<IReadOnlyCollection<User>> ParseUsersAsync(Stream rawUsers,CancellationToken ct)
        {
            var dtos = await JsonSerializer.DeserializeAsync<IReadOnlyCollection<UserDto>>(rawUsers, Options, ct);
            if (dtos is null || dtos.Count == 0)
                return Array.Empty<User>();
            var users = new List<User>(dtos.Count);
            foreach (var userDto in dtos)
            {
                var adressDto = userDto?.AddressDto;
                var address = new AdressBuilder().FromDto(adressDto).Build();

                var user = User.Create(userDto.Id, userDto.Name, userDto.Username, userDto.Email, address, userDto.Phone, userDto.Company);
                if (user is not null)
                {
                    users.Add(user);
                }
            }
            return users;
        }

    }
}
