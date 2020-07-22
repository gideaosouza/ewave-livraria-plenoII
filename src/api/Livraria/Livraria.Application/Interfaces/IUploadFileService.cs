using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Livraria.Application.Interfaces
{
    public interface IUploadFileService
    {
        string SaveFile(MemoryStream fileStream, string folder, string format);
        bool DeleteFile(string path);
    }
}
