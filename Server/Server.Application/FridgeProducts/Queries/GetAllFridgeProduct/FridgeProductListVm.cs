using Server.Domain;

namespace Server.Application.FridgeProducts.Queries.GetAllFridgeProduct
{
    public class FridgeProductListVm
    {
        public Fridge fridge; 
        public List<FridgeProductDto> fridgeProducts;
    }
}
