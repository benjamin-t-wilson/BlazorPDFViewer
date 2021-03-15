using PdfSharp.Pdf;
using System.Threading.Tasks;

namespace BlazorPDFViewer.Interfaces
{
    public interface IDocumentRepository
    {
        PdfDocument GetLocalPdf();

        Task<PdfDocument> GetPdfFromApi(string documentId);
    }
}