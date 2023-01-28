using Server.Application.Common.Mappings;
using Server.Domain;


namespace Server.Application.Products.Queries.GetProduct
{
    public class ProductVm : IMapWith<Product>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int DefaultQuantity { get; set; }
    }
}
