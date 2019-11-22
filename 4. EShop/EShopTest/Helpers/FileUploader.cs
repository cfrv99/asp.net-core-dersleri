using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EShopTest.Helpers
{
    static public class FileUploader
    {
        static public string UploadFile(IFormFile formFile)
        {
            var filename = $"{Guid.NewGuid().ToString()}{formFile.FileName}";
            var path = $@"wwwroot/content/{filename}";
            using (var fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                formFile.CopyTo(fs);
            }
            return filename;
        }
    }
}
