﻿using Kentor.AuthServices.Configuration;
using System;
using System.Collections.Generic;
using System.IdentityModel.Metadata;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Linq;

namespace Kentor.AuthServices
{
    class MetadataCommand : ICommand
    {
        public CommandResult Run(HttpRequestData request, IOptions options)
        {
            if(options == null)
            {
                throw new ArgumentNullException("options");
            }

            var urls = new AuthServicesUrls(request, options.SPOptions);

            return new CommandResult()
            {
                Content = options.SPOptions.CreateMetadata(urls).ToXmlString(),
                ContentType = "application/samlmetadata+xml"
            };
        }
    }
}
