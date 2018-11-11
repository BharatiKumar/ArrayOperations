using ArrayOperations.Implementation;
using ArrayOperations.Interfaces;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArrayOperations.Utilities
{
    public static class WindsorContainerConfiguration
    {
        /// <summary>
        /// The Container.
        /// </summary>
        private static readonly WindsorContainer Container = new WindsorContainer();

        /// <summary>
        /// The factory sync root.
        /// </summary>
        private static readonly object FactorySyncRoot = new object();

        /// <summary>
        /// The has loaded castle.
        /// </summary>
        private static bool hasLoadedCastle = false;

        /// <summary>
        /// The Inversion of Control resolve.
        /// </summary>
        /// <typeparam name="T">
        /// Type to get.
        /// </typeparam>
        /// <returns>
        /// The <see cref="T"/> object in the Inversion of Control Container.
        /// </returns>
        public static T IocResolve<T>()
        {
            if (!hasLoadedCastle)
            {
                LoadContainer();
            }

            return Container.Resolve<T>();
        }

        /// <summary>
        /// The Inversion of Control resolve.
        /// </summary>
        /// <param name="namedInstance">
        /// The named instance.
        /// </param>
        /// <typeparam name="T">
        /// Type to get.
        /// </typeparam>
        /// <returns>
        /// The <see cref="T"/> object in the Inversion of Control Container.
        /// </returns>
        public static T IocResolve<T>(string namedInstance)
        {
            if (!hasLoadedCastle)
            {
                LoadContainer();
            }

            return Container.Resolve<T>(namedInstance);
        }         

        private static void LoadContainer()
        {
            lock (FactorySyncRoot)
            {
                if (hasLoadedCastle)
                {
                    return;
                }

                Container.Register(Component.For<IArrayOperations>().LifestyleSingleton().ImplementedBy<ArrayOperationsImplementation>());

                hasLoadedCastle = true;
            }
        }         
    }
}