const myState = {
  pdf: null,
  currentPage: 1,
  zoom: 1.5
};

async function setPdf(url) {
  pdfjsLib
    .getDocument(url)
    .then(pdf => {
      myState.pdf = pdf;
      renderPdf();
    })
    .then(() => {
      setPageThumbnails();
    });
}

function renderPdf() {
  myState.pdf.getPage(myState.currentPage).then(page => {
    const oldCanvas = document.getElementById("pdf_renderer");

    const canvas = document.createElement("canvas");
    canvas.id = "pdf_renderer";

    oldCanvas.parentNode.appendChild(canvas);
    oldCanvas.parentNode.removeChild(oldCanvas);

    const ctx = canvas.getContext("2d");

    const viewport = page.getViewport(myState.zoom);

    canvas.width = viewport.width;
    canvas.height = viewport.height;

    page.render({
      canvasContext: ctx,
      viewport: viewport
    });
  });
}

function setPageThumbnails() {
  let num = 1;
  const thumbnailContainer = document.getElementById("thumbnails");

  while (num <= myState.pdf._pdfInfo.numPages) {
    const safeNum = num;
    myState.pdf.getPage(num).then(page => {
      const listItem = thumbnailContainer.children[safeNum];

      var canvasContainer = document.createElement("div");
      canvasContainer.classList.add("thumbnail_canvas_container");
      const canvas = document.createElement("canvas");

      listItem.removeChild(listItem.getElementsByTagName("div")[0]);
      listItem.appendChild(canvasContainer);
      canvasContainer.appendChild(canvas);

      const ctx = canvas.getContext("2d");
      const viewport = page.getViewport(0.15);

      canvas.width = 100;
      canvas.height = 120;

      page.render({
        canvasContext: ctx,
        viewport: viewport
      });
    });

    num++;
  }
}

function previousPage() {
  if (myState.pdf == null || myState.currentPage == 1) {
    return;
  }

  myState.currentPage -= 1;
  document.getElementById("current_page").value = myState.currentPage;
  renderPdf();
  return myState.currentPage;
}

function nextPage() {
  if (
    myState.pdf == null ||
    myState.currentPage >= myState.pdf._pdfInfo.numPages
  ) {
    return;
  }

  myState.currentPage += 1;
  document.getElementById("current_page").value = myState.currentPage;
  renderPdf();
  return myState.currentPage;
}

function changePageToNumber(desiredPage) {
  if (desiredPage >= 1 && desiredPage <= myState.pdf._pdfInfo.numPages) {
    myState.currentPage = desiredPage;
    document.getElementById("current_page").value = desiredPage;
    renderPdf();
  }
}

function zoomIn() {
  if (myState.pdf == null) {
    return;
  }
  myState.zoom += 0.25;

  renderPdf();
}

function zoomOut() {
  if (myState.pdf == null) {
    return;
  }
  myState.zoom -= 0.25;

  renderPdf();
}
