﻿using MediatR;
using Server.Application.Interfaces;
using Server.Application.Common.Exceptions;
using Server.Domain;

namespace Server.Application.FridgeModels.Commands.DeleteFridgeModel
{
    public class DeleteFridgeModelCommandHandler
        : IRequestHandler<DeleteFridgeModelCommand>
    {
        private readonly IServerDbContext _dbContext;

        public DeleteFridgeModelCommandHandler(IServerDbContext dbContext) =>
            _dbContext = dbContext;
        
        public async Task<Unit> Handle(DeleteFridgeModelCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.FridgeModels
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(FridgeModel), request.Id);
            }

            _dbContext.FridgeModels.Remove(entity);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

    }
}
