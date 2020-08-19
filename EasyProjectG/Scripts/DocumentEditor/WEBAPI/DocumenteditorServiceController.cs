#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using EJ2WordDocument = Syncfusion.EJ2.DocumentEditor.WordDocument;

namespace Documenteditor.Controllers
{        
    /// <summary>
    /// Controller for documenteditor
    /// </summary>    
    public class DocumenteditorController : ApiController
    { 
        /// <summary>
        /// Imports the word document and converts into Syncfusion Document Text(SFDT).
        /// </summary>
        /// <returns>HttpResponseMessage contains SFDT.</returns>
        [HttpPost]        
        public HttpResponseMessage Import()
        {
            if (HttpContext.Current.Request.Files.Count == 0)
                return null;

            HttpPostedFile file = HttpContext.Current.Request.Files[0];
            int index = file.FileName.LastIndexOf('.');
            string fileExtension = index > -1 && index < file.FileName.Length - 1 ?
                file.FileName.Substring(index) : ".docx";
            Stream stream = file.InputStream;
            stream.Position = 0;

            EJ2WordDocument document = EJ2WordDocument.Load(stream, GetFormatType(fileExtension.ToLower()));
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(document);
            document.Dispose();
            return new HttpResponseMessage() { Content = new StringContent(json) };
        }
        
        /// <summary>
        /// Gets the format type
        /// </summary>
        /// <param name="fileExtension">File extension</param>
        /// <returns>The format type</returns>
        internal static Syncfusion.EJ2.DocumentEditor.FormatType GetFormatType(string fileExtension)
        {
            if (string.IsNullOrEmpty(fileExtension))
                throw new NotSupportedException("EJ2 DocumentEditor does not support this file format.");
            switch (fileExtension.ToLower())
            {
                case ".dotx":
                case ".docx":
                case ".docm":
                case ".dotm":
                    return Syncfusion.EJ2.DocumentEditor.FormatType.Docx;
                case ".dot":
                case ".doc":
                    return Syncfusion.EJ2.DocumentEditor.FormatType.Doc;
                case ".rtf":
                    return Syncfusion.EJ2.DocumentEditor.FormatType.Rtf;
                case ".txt":
                    return Syncfusion.EJ2.DocumentEditor.FormatType.Txt;
                case ".xml":
                    return Syncfusion.EJ2.DocumentEditor.FormatType.WordML;
                default:
                    throw new NotSupportedException("EJ2 DocumentEditor does not support this file format.");
            }
        }
    }
}
