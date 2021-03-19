const myState = {
  pdf: null,
  currentPage: 1,
  zoom: 1.5
};

async function setPdf(
  url,
  mainCanvasElementId,
  thumbnailContainerId,
  thumbnailCanvasContainerClass
) {
  pdfjsLib
    .getDocument(url)
    .then(pdf => {
      myState.pdf = pdf;
      renderPdf(mainCanvasElementId);
    })
    .then(() => {
      setPageThumbnails(thumbnailContainerId, thumbnailCanvasContainerClass);
    });
}

function renderPdf(mainCanvasElementId) {
  myState.pdf.getPage(myState.currentPage).then(page => {
    const oldCanvas = document.getElementById(mainCanvasElementId);

    const canvas = document.createElement("canvas");
    canvas.id = mainCanvasElementId;

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

function setPageThumbnails(
  thumbnailContainerId,
  thumbnailCanvasContainerClass
) {
  let num = 1;
  const thumbnailContainer = document.getElementById(thumbnailContainerId);

  while (num <= myState.pdf._pdfInfo.numPages) {
    const safeNum = num;
    myState.pdf.getPage(num).then(page => {
      const listItem = thumbnailContainer.children[safeNum];

      var canvasContainer = document.createElement("div");
      canvasContainer.classList.add(thumbnailCanvasContainerClass);
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

function previousPage(currentPageId, mainCanvasElementId) {
  if (myState.pdf == null || myState.currentPage == 1) {
    return;
  }

  myState.currentPage -= 1;
  document.getElementById(currentPageId).value = myState.currentPage;
  renderPdf(mainCanvasElementId);
  return myState.currentPage;
}

function nextPage(currentPageId, mainCanvasElementId) {
  if (
    myState.pdf == null ||
    myState.currentPage >= myState.pdf._pdfInfo.numPages
  ) {
    return;
  }

  myState.currentPage += 1;
  document.getElementById(currentPageId).value = myState.currentPage;
  renderPdf(mainCanvasElementId);
  return myState.currentPage;
}

function changePageToNumber(desiredPage, currentPageId, mainCanvasElementId) {
  if (desiredPage >= 1 && desiredPage <= myState.pdf._pdfInfo.numPages) {
    myState.currentPage = desiredPage;
    document.getElementById(currentPageId).value = desiredPage;
    renderPdf(mainCanvasElementId);
  }
}

function zoom(amount, mainCanvasElementId) {
  if (myState.pdf == null) {
    return;
  }
  myState.zoom += amount;

  renderPdf(mainCanvasElementId);
}

function printPdf(url) {
  var iframe = this._printIframe;
  if (!this._printIframe) {
    iframe = this._printIframe = document.createElement("iframe");
    iframe.src = url;
    document.body.appendChild(iframe);

    iframe.style.display = "none";
    iframe.onload = function() {
      setTimeout(function() {
        iframe.focus();
        iframe.contentWindow.print();
      }, 1);
    };
  } else {
    iframe.contentWindow.print();
  }
}
