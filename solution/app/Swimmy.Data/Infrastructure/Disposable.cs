namespace Swimmy.Data.Infrastructure
{
    using global::System;

    public class Disposable : IDisposable
    {
        private bool isDisposed;

        #region Public Methods and Operators

        /// <summary>
        ///   Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        #region Methods

        /// <summary>
        ///   Releases unmanaged and - optionally - managed resources
        /// </summary>
        /// <param name="disposing"> <c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources. </param>
        protected virtual void Dispose(
            bool disposing)
        {
            if (!this.isDisposed && disposing)
            {
                // Dispose of managed resources
                DisposeCore();
            }

            // Dispose of native resources
            this.isDisposed = true;
        }

        ~Disposable()
        {
            Dispose(false);
        }

        protected virtual void DisposeCore()
        {
        }

        #endregion
    }
}