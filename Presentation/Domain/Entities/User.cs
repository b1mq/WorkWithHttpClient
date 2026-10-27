using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public sealed record Address(string Street, string Suite, string City, string ZipCode, Dictionary<string, string> geo);

    public class User
    {
        public  int Id { get; private set; } 
        public string Name { get; private set; }
        public string Username { get; private set; }
        public string Email { get; private set; }
        public Address Adress { get; private set; }
        public string Phone { get; private set; }
        public Dictionary<string,string> Company { get; private set; }
        private User(int id, string name, string username, string email, Address adress, string phone, Dictionary<string, string> company)
        {
            Id = id;
            Name = name;
            Username = username;
            Email = email;
            Adress = adress;
            Phone = phone;
            Company = company;
        }   
        public static User? Create(int id,string name,string username,string email,Address adress,string phone,Dictionary<string,string> company)
        {
            if(id <0 || name is null or "" || username is null or "" || adress is null || phone is null or "" || company is null ) return null;
            if (!email.Contains("@") || !email.Contains(".")) return null;
            return new User(id, name, username, email, adress, phone, company);
        }
        public override string ToString()
        {
            return $"\tPerson with id {Id}\nName : {Name}\nEmail : {Email}\n";
        }

    }
}
