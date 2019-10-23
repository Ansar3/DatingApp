using System.Linq;
using AutoMapper;
using DatingApp.API.Dtos;
using DatingApp.API.models;

namespace DatingApp.API.helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User,UserForListDto>().ForMember(dest => dest.PhotoUrl,opt => {
                opt.MapFrom(src=>src.photos.FirstOrDefault(p => p.Ismain).Url);
            });
            CreateMap<User,UserForDetailedDto>().ForMember(dest => dest.PhotoUrl,opt => {
                opt.MapFrom(src=>src.photos.FirstOrDefault(p => p.Ismain).Url);
                 });
            CreateMap<Photo,PhotosForDetailedDto>();
            CreateMap<UserForUpdateDto,User>();
            CreateMap<UserForRegiserDtos,User>();
        }
        
    }
}