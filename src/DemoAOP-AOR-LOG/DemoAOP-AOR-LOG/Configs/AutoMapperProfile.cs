using AutoMapper;
using DemoAOP_AOR_LOG.Models;

namespace DemoAOP_AOR_LOG.Configs
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<StudentInsertReq, Student>();
            CreateMap<StudentUpdateReq, Student>();
        }
    }
}
