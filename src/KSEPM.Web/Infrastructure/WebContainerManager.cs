using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KSEPM.Web.Infrastructure
{
    public static class WebContainerManager
    {
        public static IDependencyResolver GetDependencyResolver()
        {
            var dependencyResolver = DependencyResolver.Current;
            if (dependencyResolver != null)
            {
                return dependencyResolver;
            }

            throw new InvalidOperationException("The dependency resolver has not been set");
        }

        public static T Get<T>()
        {
            var service = GetDependencyResolver().GetService(typeof (T));

            if(service == null)
                throw new NullReferenceException(string.Format("Requested service of type {0}, but was not found.", typeof(T).FullName));

            return (T) service;
        }

        public static IEnumerable<T> GetAll<T>()
        {
            var services = GetDependencyResolver().GetServices(typeof (T)).ToList();

            if(!services.Any())
                throw new NullReferenceException(string.Format("Requested service of type {0}, but was not found.", typeof(T).FullName));

            return services.Cast<T>();
        }
    }
}