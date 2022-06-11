using AutoMapper;
using System;
using Customers.Application.Common.Mappings;
using Customers.Application.Customers.Commands.UpdateCustomer;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class UpdateCustomerDto : IMapWith<UpdateCustomerCommand>
    {
        [Required]
        public long Id { get; set; }

        [Required]
        public string Firstname { get; set; }

        [Required]
        public string Lastname { get; set; }

        public void Mapping(Profile profile) 
        {
            profile.CreateMap<UpdateCustomerDto, UpdateCustomerCommand>()
                .ForMember(customerCommand => customerCommand.Id,
                    opt => opt.MapFrom(customerDto => customerDto.Id))
                .ForMember(customerCommand => customerCommand.Firstname,
                    opt => opt.MapFrom(customerDto => customerDto.Firstname))
                .ForMember(customerCommand => customerCommand.Lastname,
                    opt => opt.MapFrom(customerDto => customerDto.Lastname));
        }
    }
}
