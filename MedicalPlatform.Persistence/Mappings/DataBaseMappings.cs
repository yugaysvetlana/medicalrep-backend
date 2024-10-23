using AutoMapper;
using MedicalPlatform.Core.Models;
using MedicalPlatform.Persistence.Entities;

namespace MedicalPlatform.Persistence.Mappings
{
    public class DataBaseMappings: Profile
    {
        public DataBaseMappings() {
            CreateMap<UserEntity, User>();
        }
    }
}
