using System;
using DatingApp.API.Dtos;
using System.Collections.Generic;

namespace DatingApp.API.Dtos
{
    public class UserForDetailedDto
    {
        private ICollection<PhotosForDetailedDto> photos;

        public int Id { set; get; }
        public string UserName { get; set; }

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
        public string PhotoUrl { get; set; }
        public ICollection<PhotosForDetailedDto> Photos { get => photos; set => photos = value; }
    }
}