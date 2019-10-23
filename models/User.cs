using System;
using System.Collections.Generic;

namespace DatingApp.API.models
{
    public class User
    {
        private ICollection<Photo> photo1;

        public int Id { set; get; }
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public string gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string KnownsAS { get; set; }

        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
        public string Introduction { get; set; }
        public string LookingFor { get; set; }
        public string Intrests { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public ICollection<Photo> photos { get;set; }

    }
}