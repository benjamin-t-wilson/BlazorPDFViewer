﻿namespace BlazorPDFViewer.Entities
{
    public static class Constants
    {
        public static class PdfViewerSelectors
        { // this will prevent JS from breaking, but CSS will still need updated if anything here changes
            public const string PdfViewerComponentId = "PdfViewer";
            public const string PdfWindowId = "PdfWindow";
            public const string MainCanvasContainerId = "CanvasContainer";
            public const string MainCanvasId = "MainPdfCanvas";
            public const string ThumbnailContainerId = "ThumbnailContainer";
            public const string ThumbnailCanvasContainerClass = "ThumbnailCanvasContainer";
            public const string CurrentPageInputId = "CurrentPage";
            public const string LoadingModalId = "LoadingModal";
            public const string NavigationControlsId = "NavigationControls";
        }
    }
}