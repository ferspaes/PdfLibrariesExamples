using ceTe.DynamicPDF.HtmlConverter;
using System;
using System.IO;
using System.Threading.Tasks;

namespace DynamicPDF.Example
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await ConvertPdf.ConvertAsync();
        }
    }

    public static class ConvertPdf
    {
        public async static Task ConvertAsync()
        {
            var html =
                File.ReadAllText(
                    Path.Combine(
                        Environment.GetFolderPath(
                            Environment.SpecialFolder.MyDocuments),
                        "PreLoadTestPage.html"));

            string outputDocumentPath = "DynamicPDFLibraryExample.pdf";
            double leftRightMarginsPts = 10;
            double topBottomMarginsPts = 10;

            ConversionOptions conversionOptions = new ConversionOptions(PageSize.Letter,
              PageOrientation.Portrait, leftRightMarginsPts, topBottomMarginsPts);
            conversionOptions.Author = "PreLoad LLC";
            conversionOptions.Creator = "Fernando Santos";
            conversionOptions.Title = "Document for PDF Test";
            conversionOptions.Subject = "Fernando Version of DynamicPDF Library Test";
            conversionOptions.Header ="";
            await Converter.ConvertAsync(html, outputDocumentPath, null, conversionOptions);
        }
    }
}
