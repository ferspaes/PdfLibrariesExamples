using iText.IO.Font.Constants;
using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Events;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IText7.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            GeneratePDF();
        }

        private static void GeneratePDF()
        {
            string pdfFullFilePath = "iText7_Example.pdf";

            using (var pdfWriter = new PdfWriter(pdfFullFilePath, new WriterProperties().SetPdfVersion(PdfVersion.PDF_2_0)))
            {
                var pdfDocument = new PdfDocument(pdfWriter);

                var document = new Document(pdfDocument, PageSize.A4);
                document.SetMargins(75, 50, 50, 50);

                pdfDocument.AddEventHandler(PdfDocumentEvent.END_PAGE, new EndPageEventHandler(document, pdfDocument));

                #region == Logo Creation == >>

                var PreLoadLogoImage =
                    System.IO.Path.Combine(
                        Environment.GetFolderPath(
                            Environment.SpecialFolder.MyDocuments),
                        "Preload-Logo.png");

                var image = new Image(ImageDataFactory.Create(PreLoadLogoImage));

                image.ScaleAbsolute(149f, 49.75f);
                image.SetFixedPosition(50f, 750f);

                document.Add(image);

                #endregion == Logo Creation == <<

                #region == Header Creation == >>

                var headerParagraph = new Paragraph();
                document.Add(headerParagraph);

                #endregion == Header Creation == <<

                #region == Address Creation == >>

                var addressParagraph = new Paragraph();

                addressParagraph.Add($@"
                    4000 Tower Road
                    Louisville, KY 40219
                    Contact Us
                    888-773-5623");

                addressParagraph.SetPaddingTop(40f);
                addressParagraph.SetPaddingBottom(40f);

                document.Add(addressParagraph);

                #endregion == Address Creation == <<

                #region == Table Creation == >>

                float[] columnsWidth = { 10, 40, 5, 15 };
                var table = new Table(UnitValue.CreatePercentArray(columnsWidth));

                var font = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

                table.AddHeaderCell(
                    CreateCell(1, 4, "Prices Summary", font, 18f, 10f, ColorConstants.WHITE, ColorConstants.GRAY, TextAlignment.CENTER));
                table.AddHeaderCell(
                    CreateCell(1, 1, "Quantity", font, 14f, 10f, ColorConstants.WHITE, ColorConstants.LIGHT_GRAY, TextAlignment.CENTER));
                table.AddHeaderCell(
                    CreateCell(1, 1, "Item Name", font, 14f, 10f, ColorConstants.WHITE, ColorConstants.LIGHT_GRAY, TextAlignment.CENTER));
                table.AddHeaderCell(
                    CreateCell(1, 1, "Unit", font, 14f, 10f, ColorConstants.WHITE, ColorConstants.LIGHT_GRAY, TextAlignment.CENTER));
                table.AddHeaderCell(
                    CreateCell(1, 1, "Unit Price", font, 14f, 10f, ColorConstants.WHITE, ColorConstants.LIGHT_GRAY, TextAlignment.CENTER));

                var items = GetItems();

                table.SetSkipFirstHeader(false);

                foreach (var item in items)
                {
                    table.AddCell(
                        CreateCell(1, 1, $"{item.Value}", font, 12f, 10f, ColorConstants.BLACK, ColorConstants.WHITE, TextAlignment.CENTER));
                    table.AddCell(
                        CreateCell(1, 1, item.Name, font, 12f, 10f, ColorConstants.BLACK, ColorConstants.WHITE, TextAlignment.CENTER));
                    table.AddCell(
                        CreateCell(1, 1, item.Unit, font, 12f, 10f, ColorConstants.BLACK, ColorConstants.WHITE, TextAlignment.CENTER));
                    table.AddCell(
                        CreateCell(1, 1, $"{item.Price}", font, 12f, 10f, ColorConstants.BLACK, ColorConstants.WHITE, TextAlignment.CENTER));
                }

                table.AddFooterCell(
                    CreateCell(1, 3, "Total:", font, 14f, 10f, ColorConstants.BLACK, ColorConstants.WHITE, TextAlignment.LEFT));

                table.AddFooterCell(
                    CreateCell(1, 3, $"{items.Sum(x => x.Value * x.Price)}", font, 14f, 10f, ColorConstants.BLACK, ColorConstants.WHITE, TextAlignment.LEFT));

                table.AddFooterCell(
                    CreateCell(1, 4, $"PreLoad Copyright All Rights Reserved {DateTime.Now.Year}", font, 8f, 10f, ColorConstants.BLACK, ColorConstants.WHITE, TextAlignment.CENTER));

                document.Add(table);

                var tableParagraph = new Paragraph();
                document.Add(tableParagraph);

                #endregion == Table Creation == <<

                #region == Footer Creation >>

                var footerParagraph = new Paragraph();
                document.Add(footerParagraph);

                #endregion == Footer Creation <<

                pdfDocument.Close();
            }
        }

        private static Cell CreateCell(int rowSpan, int columnSpan, string headerText, PdfFont font, float fontSize, float padding, Color fontColor, Color backGroundColor, TextAlignment textAligment)
        {
            var cell = new Cell(rowSpan, columnSpan).Add(new Paragraph(headerText));
            cell.SetFont(font);
            cell.SetFontSize(fontSize);
            cell.SetPadding(padding);
            cell.SetFontColor(fontColor);
            cell.SetBackgroundColor(backGroundColor);
            cell.SetTextAlignment(textAligment);

            return cell;
        }

        private static List<Material> GetItems()
        {
            return new List<Material>()
            {
                new Material()
                {
                    Id = 1,
                    Name = "8"+'"'+ " CMU Wall",
                    Price = 9.99f,
                    Unit = "ft",
                    Value = 8f
                },
                new Material()
                {
                    Id = 1,
                    Name = "10"+'"'+ " CMU Wall",
                    Price = 12.99f,
                    Unit = "ft",
                    Value = 8f
                },
                new Material()
                {
                    Id = 1,
                    Name = "12"+'"'+ " CMU Wall",
                    Price = 14.99f,
                    Unit = "ft",
                    Value = 8f
                },
                new Material()
                {
                    Id = 1,
                    Name = "14"+'"'+ " CMU Wall",
                    Price = 16.99f,
                    Unit = "ft",
                    Value = 8f
                },
                new Material()
                {
                    Id = 1,
                    Name = "6-1/2"+'"'+"x8"+'"'+" Cast Stone WaterTable",
                    Price = 20.44f,
                    Unit = "ft",
                    Value = 8f
                },
                new Material()
                {
                    Id = 1,
                    Name = "#8 Bare Copper Wire",
                    Price = 2200.99f,
                    Unit = "lf",
                    Value = 1f
                },
                new Material()
                {
                    Id = 1,
                    Name = "30"+'"'+" Mega Lug for Ductile Iron Pipe",
                    Price = 63.99f,
                    Unit = "ft",
                    Value = 20f
                }
            };
        }
    }
}