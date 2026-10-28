using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Post
    {
        public  int UserId { get; private set; }
        public  int Id { get; private set; }
        public  string Title { get; private set; }
        public  string Body { get; private set; }
        private Post(int userId, int id, string title, string body)
        {
            UserId = userId;
            Id = id;
            Title = title;
            Body = body;
        }
        public static Post? Create(int userId, int id, string title, string body)
        {
            if (userId < 0 || id < 0 || title is null or "" || body is null or "") return null;
            return new Post(userId, id, title, body);
        }
        public override string ToString()
        {
            return $"\n Post with id {Id} from User with id {UserId} \n Title: {Title} \n Content {Body} \n \n";
        }
    }
}
