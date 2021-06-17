using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using System;
using System.Linq;

namespace DynamicPdfCoreSuite.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a PDF Document
            Document document = new Document();

            // Create a Page and add it to the document
            Page page = new Page();
            document.Pages.Add(page);

            #region Logo >>

            var PreLoadLogoImage =
                    System.IO.Path.Combine(
                        Environment.GetFolderPath(
                            Environment.SpecialFolder.MyDocuments),
                        "Preload-Logo.png");

            // Create an image
            Image image = new Image(PreLoadLogoImage, 0, 20f);

            // Add the image to the page
            page.Elements.Add(image);

            #endregion Logo <<

            #region TextArea >>

            // Create a text area
            TextArea textArea = new TextArea(
$@"4000 Tower Road
Louisville, KY 40219
Contact Us
888 - 773 - 5623", 0, 100f, 120f, 100f,
           Font.Helvetica, 12);

            TextArea textAreaLorem = new TextArea(
$@"2000 Lorem Ipsum
Lore Ipsum, LI 9999
Lorem Ipsum
123 - 456 - 7890", (page.Dimensions.Width - (page.Dimensions.RightMargin * 2f) - 140f), 100f, 120f, 100f,
           Font.Helvetica, 12);

            textArea.Align = TextAlign.Left;
            textArea.IgnoreMargins = false;
            textAreaLorem.Align = TextAlign.Right;
            textAreaLorem.IgnoreMargins = false;

            // Change the underline property to true or false
            textArea.Underline = false;
            textAreaLorem.Underline = false;

            // Add the text area to the page
            page.Elements.Add(textArea);
            page.Elements.Add(textAreaLorem);

            #endregion TextArea <<

            #region Table >>

            // Create a table 
            Table2 table = new Table2(0, 200, 600, 1000);

            //Add columns to the table0
            Column2 column1 = table.Columns.Add(40);
            column1.CellDefault.Align = TextAlign.Center;

            table.Columns.Add(180);
            table.Columns.Add(40);
            table.Columns.Add(60);
            table.Columns.Add(80);
            table.Columns.Add(80);

            // Add rows to the table and add cells to the rows
            Row2 row1 = table.Rows.Add(5);

            row1.CellDefault.Align = TextAlign.Center;
            row1.CellDefault.VAlign = VAlign.Center;

            row1.Cells.Add("Id");
            row1.Cells.Add("Name");
            row1.Cells.Add("Unit");
            row1.Cells.Add("Amount");
            row1.Cells.Add("Piece Value");
            row1.Cells.Add("Total Value");

            var itemsList = MaterialRepository.GetMaterialList();

            foreach (var item in itemsList)
            {
                Row2 row = table.Rows.Add(5);

                Cell2 cell = row.Cells.Add($@"{item.Id}", Font.HelveticaBold, 12,
                   Grayscale.Black, Grayscale.White, 1);
                cell.Align = TextAlign.Center;
                cell.VAlign = VAlign.Center;

                row.Cells.Add($@"{item.Name}");
                row.Cells.Add($@"{item.Unit}");
                row.Cells.Add($@"{item.Amount}");
                row.Cells.Add($@"{item.Value}");
                row.Cells.Add($@"{(item.Value * item.Amount)}");
            }

            Row2 totalRow = table.Rows.Add(5);

            Cell2 cellText = totalRow.Cells.Add("Total Price:", Font.HelveticaBold, 12f,
               Grayscale.Black, Grayscale.White, 5);
            cellText.Align = TextAlign.Center;
            cellText.VAlign = VAlign.Center;

            //
                totalRow.Cells.Add($@"{itemsList.Sum(x => x.Amount * x.Value)}", 
                    Font.HelveticaBold, 12f, Grayscale.Black, Grayscale.White,1,1); //>>
            //

            table.CellDefault.Padding.Value = 5f;
            table.CellSpacing = 1f;

            table.Border.Top.Color = RgbColor.Black;
            table.Border.Bottom.Color = RgbColor.Black;
            table.Border.Top.Width = 1;
            table.Border.Bottom.Width = 1;

            table.Border.Left.LineStyle = LineStyle.None;
            table.Border.Right.LineStyle = LineStyle.None;

            // Add the table to the page
            page.Elements.Add(table);

            #endregion Table <<

            // Save the PDF
            document.Draw("DynamicPDFCoreSuite_Example.pdf");
        }
    }
}