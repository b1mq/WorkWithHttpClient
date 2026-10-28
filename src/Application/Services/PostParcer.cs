using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Application.Dtos;
using Application.Interfaces;
using Domain.Entities;

namespace Application.Services
{
    internal sealed class PostParcer:IPostParcer
    {
        public async Task<IReadOnlyCollection<Post>> GetAllAsync(Stream rawJson, CancellationToken ct)
        {
            var postDtos = await JsonSerializer.DeserializeAsync<IReadOnlyCollection<PostDto>>(rawJson,ParserOptions.Options, ct);
            if(postDtos is null) return Array.Empty<Post>();
            var posts = new List<Post>(postDtos.Count);
            foreach (var item in postDtos)
            {
                var post = Post.Create(item.UserId, item.Id, item.Title, item.Body);
                posts.Add(post);

            }
            return posts;
        }
        public async Task<Post> ParseAsync(Stream rawJson, CancellationToken ct)
        {
            var postDto = await JsonSerializer.DeserializeAsync<PostDto>(rawJson, ParserOptions.Options, ct);
            return Post.Create(postDto.UserId, postDto.Id, postDto.Title, postDto.Body) ?? throw new ArgumentException("Can not convert");
        }

    }
}
