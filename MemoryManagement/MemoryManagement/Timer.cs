using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryManagement
{
    class Timer : IDisposable
    {
        private Stopwatch timer = new Stopwatch();
        private bool isDisposed = false;
        public long ElapsedMilliseconds
        {
            get
            {
                return timer.ElapsedMilliseconds;
            }
        }

        public Timer() { }

        ~Timer()
	    {
		    Dispose(false);
	    }

	    public void Dispose()
	    {
		    Dispose(true);
		    GC.SuppressFinalize(this);
	    }

	    protected virtual void Dispose(bool fromDisposeMethod)
	    {
		    if (!isDisposed)
		    {
			    if (fromDisposeMethod)
			    {
                    timer.Stop();
			    }
			    isDisposed = true;
			}
	    }

        public Timer Start()
        {
            timer.Restart();
            return this;
        }

        public Timer Continue()
        {
            timer.Start();
            return this;
        }
    }
}
