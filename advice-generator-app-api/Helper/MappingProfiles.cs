using advice_generator_app_api.Dto;
using advice_generator_app_api.Models;
using AutoMapper;

namespace advice_generator_app_api.Helper
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<AdviceItem, AdviceItemDto>();
        }
    }
}
