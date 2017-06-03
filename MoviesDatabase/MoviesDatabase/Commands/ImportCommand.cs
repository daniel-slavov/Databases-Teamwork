using System;
using System.Collections.Generic;
using System.Reflection;
using MoviesDatabase.CLI.Commands.Abstracts;
using MoviesDatabase.CLI.Providers.Contracts;
using MoviesDatabase.Models;
using MoviesDatabase.Models.Contracts;
using MoviesDatabase.Parsers.Contracts;

namespace MoviesDatabase.CLI.Commands
{
    public class ImportCommand : Command
    {
        private readonly IJSONParser JSONParser;
        private readonly IXMLParser XMLParser;
        private readonly IModelParser ModelParser;

        public ImportCommand(IMovieService service, IJSONParser jsonParser, IXMLParser xmlParser, IModelParser modelParser) : base(service)
        {
            if (jsonParser == null)
            {
                throw new ArgumentNullException("JSON parser cannnot be null.");
            }

            if (xmlParser == null)
            {
				throw new ArgumentNullException("XMl parser cannnot be null.");
			}

            if (modelParser == null)
            {
				throw new ArgumentNullException("Model parser cannnot be null.");
			}

            this.JSONParser = jsonParser;
            this.XMLParser = xmlParser;
            this.ModelParser = modelParser;
        }

        public override string Execute(IList<string> parameters)
        {
            string format = parameters[0];
            string path = parameters[2];
            //Type model = this.ModelParser.GetType(parameters[2]);

            switch (format.ToLower())
            {
                case "json":
                    service.CreateMovie(JSONParser.Parse<IModel>(path));
                    break;
				case "xml":
                    service.CreateMovie(XMlParser.Parse<IModel>(path));
					break;
                default:
                    return "Unsupported format.";
            }

            return "File imported successfully.";
        }
    }
}
