using AutoMapper;
using GeekBrains.SD.Lesson5.BL.Model;
using GeekBrains.SD.Lesson5.UI.Models;

namespace GeekBrains.SD.Lesson5.UI.Automapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<CreateModel, CreateModel_BL>();

        }
    }
}
