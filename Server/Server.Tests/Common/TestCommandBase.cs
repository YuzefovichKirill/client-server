using Server.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Tests.Common
{
    public abstract class TestCommandBase : IDisposable
    {
        protected readonly ServerDbContext context;

        public TestCommandBase()
        {
            context = ContextFactory.Create();
        }

        public void Dispose()
        {
            ContextFactory.Destroy(context);
        }
    }
}
