using System;
using System.ComponentModel.DataAnnotations;

namespace DatingApp.API.Dtos
{
    public class UserForRegiserDtos
    {
    
     
       
               
        [Required]
        public string Username{get;set;}
        [Required]
        [StringLength(8,MinimumLength=4,ErrorMessage="You must specify the password between 4 and 8")]
        public string Password{get;set;}
        [Required]
        public string gender{get; set;}
        [Required]
        public string KnownAs{ get;set;}
        [Required]
        public DateTime DateOfBirth{get;set;}
        [Required]
        public string City{get; set;}
        [Required]
        public string Countrt{get; set;}
        [Required]
        public DateTime Created{get; set;}
        public DateTime LastActive{get;set;}
        public UserForRegiserDtos()
        {
            Created=DateTime.Now;
            LastActive=DateTime.Now;
        }
    }
}