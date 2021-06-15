using DocRaptor.Api;
using DocRaptor.Model;
using System;
using System.IO;

namespace DocRaptor.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            DocApi docraptor = new DocApi();
            docraptor.Configuration.Username = "YOUR_API_KEY_HERE";

            var html =
                File.ReadAllText(
                    Path.Combine(
                        Environment.GetFolderPath(
                            Environment.SpecialFolder.MyDocuments),
                        "PreLoadTestPage.html"));

            Doc doc = new Doc(
              test: true,
              documentContent: html,
              name: "docraptor-csharp.pdf",
              documentType: Doc.DocumentTypeEnum.Pdf
            );

            byte[] createResponse = docraptor.CreateDoc(doc);

            File.WriteAllBytes("DocRaptorPDFExample.pdf", createResponse);
        }
    }
}
