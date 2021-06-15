using iText.IO.Font.Constants;
using iText.Kernel.Events;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Properties;
using System;

namespace IText7.Example
{
    internal class EndPageEventHandler : IEventHandler
    {
        protected Document _document;
        protected PdfDocument _pdfDocument;

        public EndPageEventHandler(Document document, PdfDocument pdfDocument)
        {
            _document = document;
            _pdfDocument = pdfDocument;
        }

        public void HandleEvent(Event @event)
        {
            PdfDocumentEvent documentEvent = (PdfDocumentEvent)@event;
            PdfPage page = documentEvent.GetPage();

            var pageSize = documentEvent.GetPage().GetPageSize();

            PdfFont font = null;

            try
            {
                font = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLDOBLIQUE);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            float leftX = pageSize.GetLeft() + _document.GetLeftMargin();
            float centerX =
                (pageSize.GetLeft() + _document.GetLeftMargin() + (pageSize.GetRight() - _document.GetRightMargin())) / 2;
            float rightX = pageSize.GetRight() - _document.GetRightMargin();
            float headerY = pageSize.GetTop() - _document.GetTopMargin() + 25f;
            float footerY = _document.GetBottomMargin() - 15f;

            var canvas = new Canvas(documentEvent.GetPage(), pageSize);

            //header
            canvas
                .SetFont(font)
                .SetFontSize(18)
                .ShowTextAligned(
                    "PreLoad",
                    centerX,
                    headerY,
                    TextAlignment.CENTER).SetFontSize(10)
                .ShowTextAligned(
                    $"Page {_pdfDocument.GetPageNumber(page)}/{_pdfDocument.GetNumberOfPages()}",
                    rightX,
                    headerY,
                    TextAlignment.RIGHT)

                .Close();

            //footer
            canvas
                .SetFont(font)
                .SetFontSize(10)
                .ShowTextAligned(
                    $"PreLoad All Rights Reserved {DateTime.Now.Year}",
                    leftX,
                    footerY,
                    TextAlignment.LEFT)
                .Close();
        }
    }
}