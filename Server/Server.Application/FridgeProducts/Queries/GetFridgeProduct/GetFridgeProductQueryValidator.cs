using System;
using FluentValidation;

namespace Server.Application.FridgeProducts.Queries.GetFridgeProduct
{
    public class GetFridgeProductQueryValidator : AbstractValidator<GetFridgeProductQuery>
    {
        public GetFridgeProductQueryValidator()
        {
            RuleFor(getAllFridgeProductQuery =>
                getAllFridgeProductQuery.FridgeId).NotEqual(Guid.Empty);
            RuleFor(getAllFridgeProductQuery =>
                getAllFridgeProductQuery.ProductId).NotEqual(Guid.Empty);
        }
    }
}
