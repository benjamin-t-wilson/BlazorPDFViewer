function b64toBlob(b64Data, contentType) {
  var byteCharacters = atob(b64Data);

  var byteArrays = [];

  for (let offset = 0; offset < byteCharacters.length; offset += 512) {
    var slice = byteCharacters.slice(offset, offset + 512),
      byteNumbers = new Array(slice.length);
    for (let i = 0; i < slice.length; i++) {
      byteNumbers[i] = slice.charCodeAt(i);
    }
    var byteArray = new Uint8Array(byteNumbers);

    byteArrays.push(byteArray);
  }

  var blob = new Blob(byteArrays, { type: contentType });
  return blob;
}

function createPdfDataUrl(b64Data) {
  return (
    URL.createObjectURL(b64toBlob(b64Data, "application/pdf")) + "#toolbar=0"
  );
}

function setPageLoading(status, loadingModalId, pdfViewerComponentId) {
    var modal = document.getElementById(loadingModalId);
  modal.style.display = status ? "block" : "none";

    var pdfViewer = document.getElementById(pdfViewerComponentId);
  pdfViewer.style.display = status ? "none" : "block";
}
