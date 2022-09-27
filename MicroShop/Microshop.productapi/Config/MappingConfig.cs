using AutoMapper;
using Microshop.productapi.Data.ValueObjects;
using Microshop.productapi.Model;

namespace Microshop.productapi.Config
{
    public class MappingConfig
    {

        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductVO, Productc>();
                config.CreateMap<Productc, ProductVO>();
            });
                return mappingConfig;

        }
    }
}
