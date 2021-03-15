using PdfSharp.Pdf;
using System;
using System.IO;

namespace BlazorPDFViewer.Extensions
{
    public static class PDFExtensions
    {
        public static string ToBase64String(this PdfDocument doc)
        {
            byte[] pdfAsBytes = null;
            using (MemoryStream stream = new MemoryStream())
            {
                doc.Save(stream, true);
                pdfAsBytes = stream.ToArray();
            }

            return Convert.ToBase64String(pdfAsBytes);
        }
    }
}