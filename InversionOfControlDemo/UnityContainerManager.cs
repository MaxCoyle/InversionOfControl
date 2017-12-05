using Microsoft.Practices.Unity.Configuration;
using System;
using InversionOfControlDemo.Interfaces;
using Unity;

namespace InversionOfControlDemo
{
    public sealed class UnityContainerManager : IDisposable
    {
        // ReSharper disable once InconsistentNaming
        private IUnityContainer container;
        // ReSharper disable once InconsistentNaming
        private bool disposed;

        /// <summary>
        ///     Initializes static members of the <see cref="UnityContainerManager" /> class.
        /// </summary>
        static UnityContainerManager()
        {
            Current = new UnityContainerManager();
        }

        /// <summary>
        ///     Prevents a default instance of the <see cref="UnityContainerManager" /> class from being created.
        /// </summary>
        private UnityContainerManager()
        {
        }

        /// <summary>
        ///     Gets the current <see cref="UnityContainerManager" /> instance.
        /// </summary>
        public static UnityContainerManager Current { get; }

        /// <inheritdoc />
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        ///     Finalizes an instance of the <see cref="UnityContainerManager" /> class.
        /// </summary>
        ~UnityContainerManager()
        {
            Dispose(false);
        }

        /// <summary>
        ///     Gets the IoC container.
        /// </summary>
        /// <returns>A <see cref="IUnityContainer" /> object.</returns>
        public IUnityContainer GetContainer()
        {
            if (!disposed)
            {
                if (container == null)
                {
                    container = new UnityContainer();
                    RegisterDependancies();
                    container.LoadConfiguration();
                }

                return container;
            }
            throw new ObjectDisposedException(GetType().Name, "The 'GetContainer' method cannot be called once the object has been disposed.");
        }

        private void RegisterDependancies()
        {
            container.RegisterType<IOrderService, OrderService>();
        }

        private void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing)
            {
                container?.Dispose();
            }

            disposed = true;
        }
    }
}
