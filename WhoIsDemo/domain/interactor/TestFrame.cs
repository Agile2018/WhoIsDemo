using ASSLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using WhoIsDemo.model;

namespace WhoIsDemo.domain.interactor
{
    class TestFrame
    {
        #region variables
        private Aipu aipu;
        //[DllImport("Kernel32.dll", EntryPoint = "RtlMoveMemory")]
        //public static extern void MoveMemory(IntPtr dest, IntPtr src, int size);
        #endregion

        #region methods
        public TestFrame(int indexVideo)
        {
            aipu = HeapAipuVideo
               .Instance.GetAipuVideo(indexVideo);

        }

        [HandleProcessCorruptedStateExceptions]
        public Bitmap GetFrame()
        {
            //IntPtr Bits = IntPtr.Zero;
            //aipu.GetFrame();

            //Bitmap bitmap = new Bitmap(1020,
            //    768, System.Drawing.Imaging.PixelFormat.Format32bppRgb);

            //var bmpData = bitmap.LockBits(new Rectangle(0, 0,
            //bitmap.Width, bitmap.Height), 
            //System.Drawing.Imaging.ImageLockMode.ReadWrite,
            //System.Drawing.Imaging.PixelFormat.Format32bppRgb);

            //MoveMemory(bmpData.Scan0, Bits, bmpData.Stride * bmpData.Height);
            //bitmap.UnlockBits(bmpData);
            //Marshal.FreeHGlobal(Bits);
            //try
            //{
            //    Bitmap bmp = (Bitmap)aipu.GetImage.Clone();
            //    //Bitmap bmp = aipu.GetImage;
            //    bmp.Save("wertOLO.bmp");
            //    return bmp;
            //}
            //catch (System.AccessViolationException exception)
            //{
            //    // Output explicit exception.
            //    Console.WriteLine(exception.Message);
                
            //}
            //catch (Exception exception)
            //{
            //    // Output inexplicit exception.
            //    Console.WriteLine(exception.Message);
            //}
            return null;
        }
        #endregion
    }
}
