using System;
using System.Collections.Generic;
using StructureMap;


namespace ZooWebApp.Container
{
    public static class ContainerManager
    {
        private static volatile IContainer _current;
        private static readonly object SyncRoot = new Object();

        /// <summary>
        /// Gets the current instance of the container (thread safe)
        /// </summary>
        public static IContainer Current
        {
            get
            {
                if (_current == null)
                {
                    InitializeContainer(ObjectFactory.Container);
                }

                return _current;
            }
        }

        internal static void InitializeContainer(IContainer container)
        {
            lock (SyncRoot)
            {
                _current = container;
            }

            container.Configure(c => c.Scan(s =>
            {
                
                s.LookForRegistries();
                s.Assembly("Zoo.Services");
                s.Assembly("ZooWebApp");

            }));
        }
    }
}