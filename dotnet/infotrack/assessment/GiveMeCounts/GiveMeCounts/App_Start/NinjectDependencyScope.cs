using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using Ninject.Parameters;
using Ninject.Syntax;

namespace GiveMeCounts.App_Start
{
    public class NinjectDependencyScope : IDependencyScope
    {
        private IResolutionRoot resolver;

        public NinjectDependencyScope(IResolutionRoot resolver)
        {
            this.resolver = resolver;
        }

        public object GetService(Type serviceType)
        {
            var request = resolver.CreateRequest(serviceType, null, new Parameter[0], true, true);
            return resolver.Resolve(request).SingleOrDefault();
        }

        public System.Collections.Generic.IEnumerable<object> GetServices(Type serviceType)
        {
            var request = resolver.CreateRequest(serviceType, null, new Parameter[0], true, true);
            return resolver.Resolve(request);
        }

        public void Dispose()
        {
            IDisposable disposable = resolver as IDisposable;
            if (disposable != null)
                disposable.Dispose();

            resolver = null;
        }
    }
}