using System;
using FluentValidation;

namespace Server.Application.Products.Queries.GetProduct
{
    public class GetProductQueryValidator : AbstractValidator<GetProductQuery>
    {
        public GetProductQueryValidator()
        {
            RuleFor(getProductQuery =>
                getProductQuery.Id).NotEqual(Guid.Empty);
        }
    }
}