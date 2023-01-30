using System;
using FluentValidation;

namespace Server.Application.FridgeProducts.Queries.GetAllFridgeProduct
{
    public class GetAllFridgeProductQueryValidator : AbstractValidator<GetAllFridgeProductQuery>
    {
        public GetAllFridgeProductQueryValidator()
        {
            RuleFor(getAllFridgeProductQuery =>
                getAllFridgeProductQuery.FridgeId).NotEqual(Guid.Empty);
        }
    }
}
