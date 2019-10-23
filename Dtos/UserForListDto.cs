using System;
using System.Collections.Generic;
using DatingApp.API.models;

namespace DatingApp.API.Dtos
{
    public class UserForListDto
    {
        
        public int Id { set; get; }
        public string UserName { get; set; }
         public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string gender { get; set; }

        public int Age { get; set; }

        public string KnownsAS { get; set; }

        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
        public string Introduction { get; set; }
        public string LookingFor { get; set; }
        public string Intrests { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PhotoUrl {get;set;}

    }
    }