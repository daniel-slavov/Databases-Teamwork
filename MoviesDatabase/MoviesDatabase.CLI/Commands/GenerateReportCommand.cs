using System;
using System.Collections.Generic;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using MoviesDatabase.CLI.Commands.Contracts;
using MoviesDatabase.Services.Contracts;

namespace MoviesDatabase.CLI.Commands
{
    public class GenerateReportCommand : ICommand
    {
        private readonly IMovieService MovieService;
        private readonly ICommand ListCommand;

        public GenerateReportCommand(IMovieService movieService)
        {
            this.MovieService = movieService;
            this.ListCommand = new ListAllCommand(movieService);
        }

        public string Execute(IList<string> parameters)
        {
            string path = Path.Combine(parameters[0], "MoviesReport.pdf");

            if (!File.Exists(path))
            {
                using (FileStream fileStream = File.Create(path))
                {
                    Document document = new Document(PageSize.A4.Rotate(), 10, 10, 10, 10);

                    PdfWriter writer = PdfWriter.GetInstance(document, fileStream);
                    document.Open();

                    Paragraph title = new Paragraph("Movies in the database:")
                    {
                        Alignment = Element.ALIGN_CENTER
                    };
                    document.Add(title);

                    string data = "";

                    try
                    {
                        data = this.ListCommand.Execute(null);
                    }
                    catch (Exception ex)
                    {
                        data = ex.Message;
                    }

                    Paragraph dataParagraph = new Paragraph(data);
                    document.Add(dataParagraph);

                    Paragraph date = new Paragraph(DateTime.Now.ToString())
                    {
                        Alignment = Element.ALIGN_RIGHT
                    };
                    document.Add(date);

                    document.Close();
                }
            }
            else
            {
                throw new IOException("File already exists.");
            }

            return "Report generated successfully.";
        }
    }
}
// Sample command:
// GenerateReport ./somepath