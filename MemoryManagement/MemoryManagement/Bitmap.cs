using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace MemoryManagement
{
    class BitmapEditor : IDisposable
    {
        private bool isDisposed = false;
        private Bitmap bitmap;
        private BitmapData bitmapData;

        public BitmapEditor(Bitmap bitmap)
        {
            this.bitmap = bitmap;
            Rectangle rectangle = new Rectangle(0, 0, this.bitmap.Width, this.bitmap.Height);
            bitmapData = bitmap.LockBits(rectangle, ImageLockMode.ReadWrite, bitmap.PixelFormat);
        }

        ~BitmapEditor()
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
                    bitmap.UnlockBits(bitmapData);
                }
                isDisposed = true;
            }
        }

        public void SetPixel(int x, int y, byte red, byte green, byte blue)
        {
            int offset = 3 * x + bitmapData.Stride * y;
            Marshal.Copy(new[] { blue, green, red }, 0, IntPtr.Add(bitmapData.Scan0, offset), 3);
        }
    }
}
