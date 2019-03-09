using _19115.Application.Interfaces.Mapping;
using AutoMapper;

namespace _19115.Application
{
	public class NotificationViewModel : IHaveCustomMapping
	{
		public void CreateMappings(Profile configuration)
		{
			throw new System.NotImplementedException();
			//configuration.CreateMap<Product, ProductDto>()
			//	.ForMember(pDTO => pDTO.SupplierCompanyName, opt => opt.MapFrom(p => p.Supplier != null ? p.Supplier.CompanyName : string.Empty))
			//	.ForMember(pDTO => pDTO.CategoryName, opt => opt.MapFrom(p => p.Category != null ? p.Category.CategoryName : string.Empty));
		}
	}
}
