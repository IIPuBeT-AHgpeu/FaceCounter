using DlibDotNet;
using System.Drawing.Imaging;
using System.Drawing;

namespace FaceCounter
{
    public class Recognizer
    {
        //private FrontalFaceDetector faceDetector = Dlib.GetFrontalFaceDetector();
        public int GetObjectsCount(byte[] image)
        {
            int count = 0;

            //using (var ms = new MemoryStream(image))
            //{
            //    using (var bitmap = (Bitmap)System.Drawing.Image.FromStream(ms))
            //    using (var png = new MemoryStream())
            //    {
            //        bitmap.Save(png, ImageFormat.Png);
            //        using (var matrix = Dlib.LoadPng<BgrPixel>(png.ToArray()))
            //        {
            //            var dets = faceDetector.Operator(matrix);
            //            count = dets.Count();
            //        }
            //    }
            //}
            Random rnd = new Random();
            return rnd.Next(3);
            //return (count);
        }
    }
}
