using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Server.Application.Common.Mappings;
using Server.Application.Interfaces;
using Server.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Tests.Common
{
    public class QueryTestFixture : IDisposable
    {
        public ServerDbContext context;
        public IMapper mapper;

        public QueryTestFixture()
        {
            context = ContextFactory.Create();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AssemblyMappingProfile(
                    typeof(IServerDbContext).Assembly));
            });
            mapper = configurationProvider.CreateMapper();
        }

        public void Dispose()
        {
            ContextFactory.Destroy(context);
        }
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}
