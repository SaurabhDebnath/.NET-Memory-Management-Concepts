using System;

namespace OOPSTutorial
{
    // managed unmanaged concept 
    //https://msdn.microsoft.com/en-in/library/ms973872.aspx
    //https://en.wikipedia.org/wiki/Windows_API
    //wrapper library section

    public class Base : IDisposable
    {
        private bool disposed = false;

        //Implement IDisposable.
        public void Dispose()
        {
            Dispose(true); //I am calling you from Dispose, it's safe
            GC.SuppressFinalize(this); //Hey, GC: don't bother calling finalize later
        }

        protected virtual void Dispose(bool itIsSafeToAlsoFreeManagedObjects)
        {
            if (!disposed)
            {
                if (itIsSafeToAlsoFreeManagedObjects)
                {
                    // Free other state (managed objects).
                }
                // Free your own state (unmanaged objects).
                // Set large fields to null.
                //Win32.DestroyHandle(this.CursorFileBitmapIconServiceHandle);

                disposed = true;
            }
        }

        // Use C# destructor syntax for finalization code.// this will be called by GC
        ~Base()
        {
            Dispose(false); //I am *not* calling you from Dispose, it's *not* safe
        }
    }

    // Design pattern for a derived class.
    public class Derived : Base
    {
        private bool disposed = false;

        protected override void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // Release managed resources.
                }
                // Release unmanaged resources.
                // Set large fields to null.
                // Call Dispose on your base class.
                disposed = true;
            }
            base.Dispose(disposing);
        }
        // The derived class does not have a Finalize method
        // or a Dispose method without parameters because it inherits
        // them from the base class.
    }
}
