using System;

namespace DatingApp.API.models
{
    public class Photo
    {
        public int id { get; set;}
        public string Url { get; set;}
        public string Description { get; set;}
        public DateTime DateAdd{ get; set;}
        public bool Ismain { get; set; }
        public User User {get;set;}
        public int UserId {get;set;}
    }
}