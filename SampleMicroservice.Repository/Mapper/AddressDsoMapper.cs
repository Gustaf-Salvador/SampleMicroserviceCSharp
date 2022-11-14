using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleMicroservice.Domain.Model;
using SampleMicroservice.Repository.Model;

namespace SampleMicroservice.Repository.Mapper
{
    public class AddressDsoMapper : Profile
    {
        public AddressDsoMapper()
        {
            CreateMap<Address, AddressDso>().ReverseMap();
        }
    }
}
