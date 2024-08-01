using PdfiumViewer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

namespace PDF_manipulations
{
    internal class Program
    {
        /// <summary>
        /// Please, note that the project need to use some o these libraries according to documentatoin:
        /// https://github.com/pvginkel/PdfiumViewer
        /// Here´s additional info about how use the dlls to execute the project
        /// https://stackoverflow.com/questions/30573151/library-dependencies-for-pdfiumviewer
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            string outputPath = @"your path folder";
            string pdf = @"pdf location";

            // Define size of image, 
            Size size = new Size(1000, 1000);


            using (var document = PdfiumViewer.PdfDocument.Load(pdf))        //Load PDF with PDFViewer
            using (var stream = new FileStream(outputPath, FileMode.Create)) //Create image 
            using (var image = GetPageImage(1, size, document, 300))         //create the image
            {
                image.Save(stream, ImageFormat.Jpeg); //save image in the place passed
            }
        }
        /// <summary>
        /// Will Render a imagem utilizing a single page of a PDF
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="size"></param>
        /// <param name="document"></param>
        /// <param name="dpi"></param>
        /// <returns></returns>
        private static Image GetPageImage(int pageNumber, Size size, PdfDocument document, int dpi)
        {
            return document.Render(pageNumber - 1, size.Width, size.Height, dpi, dpi, PdfRenderFlags.Annotations);
        }
    }
}