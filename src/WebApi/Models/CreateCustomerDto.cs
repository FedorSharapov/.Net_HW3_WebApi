using AutoMapper;
using Customers.Application.Common.Mappings;
using Customers.Application.Customers.Commands.CreateCustomer;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class CreateCustomerDto : IMapWith<CreateCustomerCommand>
    {

        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateCustomerDto, CreateCustomerCommand>()
                .ForMember(customerCommand => customerCommand.Firstname,
                    opt => opt.MapFrom(customerDto => customerDto.Firstname))
                .ForMember(customerCommand => customerCommand.Lastname,
                    opt => opt.MapFrom(customerDto => customerDto.Lastname));
        }
    }
}
