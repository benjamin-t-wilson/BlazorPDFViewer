using BlazorPDFViewer.Interfaces;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace BlazorPDFViewer.Repositories
{
    public class DocumentRepository : IDocumentRepository
    {
        public PdfDocument GetLocalPdf()
        {
            return PdfReader.Open(new MemoryStream(File.ReadAllBytes("Assets/untitled1.pdf")), PdfDocumentOpenMode.Modify);
        }

        public async Task<PdfDocument> GetPdfFromApi(string documentId)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("DOCUMENT_API_ENDPOINT");

            HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync();
            Stream stream = response.GetResponseStream();

            return PdfReader.Open(stream);
        }
    }
}