using System;
using System.Collections.Generic;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using MoviesDatabase.CLI.Commands.Contracts;
using MoviesDatabase.Services.Contracts;
using MoviesDatabase.CLI.Providers.Contracts;

namespace MoviesDatabase.CLI.Commands
{
    public class GenerateReportCommand : ICommand
    {
        private readonly IMovieService movieService;
        private readonly ITableCreator tableCreator;
        private readonly ICommand listCommand;

        public GenerateReportCommand(IMovieService movieService, ITableCreator tableCreator)
        {
            if (movieService == null)
            {
                throw new ArgumentNullException("Movie service cannot be null.");
            }

            if (tableCreator == null)
            {
                throw new ArgumentNullException("Table creator cannot be null.");
            }

            this.movieService = movieService;
            this.tableCreator = tableCreator;
            this.listCommand = new ListAllCommand(movieService, tableCreator);
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

                    string data = string.Empty;

                    try
                    {
                        data = this.listCommand.Execute(null);
                    }
                    catch (Exception ex)
                    {
                        data = ex.Message;
                    }

                    // Font tableFont = new Font(Currier, 16, Font.NORMAL);
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