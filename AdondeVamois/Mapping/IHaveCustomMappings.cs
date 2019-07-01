
using AutoMapper;

namespace AdondeVamos.Mapping
{
    public interface IHaveCustomMappings
    {
        void CreateMappings(IMapperConfiguration configuration);
    }
}