using AutoMapper;
using MedApplication.Common.Identity.Models;
using MedDomain.Entities;

namespace MedInfrastructure.Common.Mappers;

public class UserMapper : Profile
{
    public UserMapper()
    {
        CreateMap<SignUpDetails, UserModule>();
    }
}
