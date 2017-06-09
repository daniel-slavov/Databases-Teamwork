using System;
using System.Collections.Generic;
using MoviesDatabase.CLI.Commands.Contracts;
using MoviesDatabase.CLI.Providers.Contracts;
using MoviesDatabase.Services.Contracts;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace MoviesDatabase.CLI.Commands
{
    public class GenerateReportCommand : ICommand
    {
        public GenerateReportCommand()
        {
        }

        public string Execute(IList<string> parameters)
        {
            string path = Path.Combine(parameters[0], "MoviesReport.pdf");


            if (!System.IO.File.Exists(path))
            {
                using (FileStream fileStream = File.Create(path))
                {
                    Document document = new Document(PageSize.A4, 10, 10, 10, 10);

                    PdfWriter writer = PdfWriter.GetInstance(document, fileStream);
                    document.Open();

                    Chunk chunk = new Chunk("This is from chunk. ");
                    document.Add(chunk);

                    Phrase phrase = new Phrase("This is from Phrase.");
                    document.Add(phrase);

                    Paragraph para = new Paragraph("This is from paragraph.");
                    document.Add(para);

                    string text = "you are successfully created PDF file.";
                    Paragraph paragraph = new Paragraph();
                    paragraph.SpacingBefore = 10;
                    paragraph.SpacingAfter = 10;
                    paragraph.Alignment = Element.ALIGN_LEFT;
                    paragraph.Font = FontFactory.GetFont(FontFactory.HELVETICA, 12f, BaseColor.GREEN);
                    paragraph.Add(text);
                    document.Add(paragraph);

                    document.Close();
                }
            }
            else
            {
                throw new IOException("File already exists.");
            }

            return "generateReport";
        }
    }
}
// Sample command:
// GenerateReport ./somepath