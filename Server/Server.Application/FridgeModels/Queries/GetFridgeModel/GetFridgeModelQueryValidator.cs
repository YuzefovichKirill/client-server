using System;
using FluentValidation;

namespace Server.Application.FridgeModels.Queries.GetFridgeModel
{
    public class GetFridgeModelQueryValidator : AbstractValidator<GetFridgeModelQuery>
    {
        public GetFridgeModelQueryValidator()
        {
            RuleFor(getFridgeModelQuery =>
                getFridgeModelQuery.Id).NotEqual(Guid.Empty);
        }
    }
}
