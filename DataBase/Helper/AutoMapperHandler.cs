using AutoMapper;
using DataBase.Models;

namespace DataBase.Helper
{
    public class AutoMapperHandler : Profile
    {
        public AutoMapperHandler()
        {
            CreateMap<MorenModelHeroes, AutoMapperMorenHeroes>().ForMember(item => item.StatusCode, opt => opt.MapFrom(
               item => item.IsActive == true ? "Is Active" : "In Active")).ReverseMap();

            CreateMap<MorenModelLocations, AutoMapperMorenLocations>().ForMember(item => item.OldOrYoung, opt => opt.MapFrom(
               item => item.AgeOfLocation > 60 ? "This location is old" : "This location is young" ));
        }
    }
}
