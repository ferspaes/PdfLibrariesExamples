using IText7.Example;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.Tables;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace SpirePDF.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            PdfDocument doc = new PdfDocument();
            PdfUnitConvertor unitCvtr = new PdfUnitConvertor();
            PdfMargins margin = new PdfMargins();
            PdfBrush brush = PdfBrushes.Black;
            PdfFont font = new PdfFont(PdfFontFamily.Helvetica, 8f);
            PdfStringFormat format = new PdfStringFormat(PdfTextAlignment.Center);
            PdfPageBase page = doc.Pages.Add(PdfPageSize.A4, margin);

            margin.Top = unitCvtr.ConvertUnits(2.54f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
            margin.Bottom = margin.Top;
            margin.Left = unitCvtr.ConvertUnits(3.17f, PdfGraphicsUnit.Centimeter, PdfGraphicsUnit.Point);
            margin.Right = margin.Left;

            var PreLoadLogoImage =
                    System.IO.Path.Combine(
                        Environment.GetFolderPath(
                            Environment.SpecialFolder.MyDocuments),
                        "Preload-Logo.png");

            PdfImage image = PdfImage.FromFile(PreLoadLogoImage);
            float width = 149f;
            float height = 49.75f;
            page.Canvas.DrawImage(image, 40f, 60f, width, height);

            PdfStringFormat leftAlignment = new PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Middle);
            page.Canvas.DrawString(
                $@"
                    4000 Tower Road
                    Louisville, KY 40219
                    Contact Us
                    888 - 773 - 5623", font, brush, -40f, 160f, leftAlignment);

            page.Canvas.DrawString(
                $@"
                    2000 Lorem Ipsum
                    Lore Ipsum, LI 9999
                    Lorem Ipsum
                    123 - 456 - 7890", font, brush, (page.Size.Width / 2f) /*400f*/, 160f, leftAlignment);

            float y = 235;

            string tableSummary = "Buying Summary List";

            page.Canvas.DrawString(tableSummary, font, brush, page.Canvas.ClientSize.Width / 2, y, format);

            var list = new List<string>();

            list.Add("Id;Name;Value;Unit;Price");

            List<Material> materialsList = GetItems();

            foreach (var item in materialsList)
                list.Add($"{item.Id};{item.Name};{item.Value};{item.Unit};{item.Price}");

            list.Add($@"Total Price: ;;;;{materialsList.Sum(x => x.Price * x.Value)}");
                
            String[] data = list.ToArray();

            String[][] dataSource = new String[data.Length][];
            
            for (int i = 0; i < data.Length; i++)
            {
                dataSource[i] = data[i].Split(';');
            }

            PdfTable table = new PdfTable();

            table.Style.CellPadding = 2;
            table.Style.HeaderSource = PdfHeaderSource.Rows;
            table.Style.HeaderRowCount = 1;
            table.Style.HeaderStyle.BackgroundBrush = PdfBrushes.LightGray;
            table.Style.ShowHeader = true;
            table.DataSource = dataSource;

            PdfLayoutResult result = table.Draw(page, new PointF(100, 250));
            y = y + result.Bounds.Height + 25f;
            PdfBrush tableBrush = PdfBrushes.Gray;
            var tableFont = new PdfFont(PdfFontFamily.TimesRoman, 9f);
            page.Canvas.DrawString($"* {data.Length - 2} items in the list.", tableFont, tableBrush, 40, y);

            doc.SaveToFile("Sample.pdf");
            doc.Close();
        }

        private static List<Material> GetItems()
        {
            return new List<Material>()
            {
                new Material()
                {
                    Id = 1,
                    Name = "8 CMU Wall",
                    Price = 9.99f,
                    Unit = "ft",
                    Value = 8f
                },
                new Material()
                {
                    Id = 43,
                    Name = "10 CMU Wall",
                    Price = 12.99f,
                    Unit = "ft",
                    Value = 8f
                },
                new Material()
                {
                    Id = 27,
                    Name = "12 CMU Wall",
                    Price = 14.99f,
                    Unit = "ft",
                    Value = 8f
                },
                new Material()
                {
                    Id = 18,
                    Name = "14 CMU Wall",
                    Price = 16.99f,
                    Unit = "ft",
                    Value = 8f
                },
                new Material()
                {
                    Id = 999,
                    Name = "6-1/2x8 Cast Stone WaterTable",
                    Price = 20.44f,
                    Unit = "ft",
                    Value = 8f
                },
                new Material()
                {
                    Id = 6,
                    Name = "#8 Bare Copper Wire",
                    Price = 2200.99f,
                    Unit = "lf",
                    Value = 1f
                },
                new Material()
                {
                    Id = 1237,
                    Name = "30 Mega Lug for Ductile Iron Pipe",
                    Price = 63.99f,
                    Unit = "ft",
                    Value = 20f
                }
            };
        }
    }
}