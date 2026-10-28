using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Services
{
    public class PostJsonService:IPostJsonService
    {
        private static readonly HttpClient _client;
        private static readonly IPostParcer _parser;

        static PostJsonService()
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
            _parser = new PostParcer();
        }
        public async Task<IReadOnlyCollection<Post>> GetAllAsync(CancellationToken ct)
        {
            await using var stream =await  _client.GetStreamAsync("posts", ct);
            return await _parser.GetAllAsync(stream, ct);

        }
        public async Task<Post> GetByIdAsync(int id, CancellationToken ct)
        {
            await using var stream = await _client.GetStreamAsync($"posts/{id}", ct);
            return await _parser.ParseAsync(stream, ct);
        }
    }
}
