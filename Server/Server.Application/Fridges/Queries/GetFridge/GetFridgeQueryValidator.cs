using System;
using FluentValidation;

namespace Server.Application.Fridges.Queries.GetFridge
{
    public class GetFridgeQueryValidator : AbstractValidator<GetFridgeQuery>
    {
        public GetFridgeQueryValidator()
        {
            RuleFor(getFridgeQuery =>
                getFridgeQuery.Id).NotEqual(Guid.Empty);
        }
    }
}
