using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Services
{
    public class UserJsonService : IUserJsonService
    {
        private static readonly HttpClient _client;
        private static readonly IUserParser _parser;

        static UserJsonService()
        {
            var handler = new SocketsHttpHandler
            {
                PooledConnectionLifetime = TimeSpan.FromMinutes(2),
            };
            _client = new HttpClient(handler)
            {
                BaseAddress = new Uri("https://jsonplaceholder.typicode.com/"),
                Timeout = TimeSpan.FromSeconds(10)
            };
            _parser = new UserParser();

        }
        public async Task<IReadOnlyCollection<User>> GetAllAsync(CancellationToken ct)
        {
           await using var stream  =   await _client.GetStreamAsync("users",ct);
            return await _parser.ParseUsersAsync(stream, ct);
          
        }
        public async Task<User?> GetByIdAsync(int id,CancellationToken ct)
        {
            return await _client.GetFromJsonAsync<User>($"users/{id}", ct);
        }
    }
}
