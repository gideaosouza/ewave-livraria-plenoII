using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Livraria.Infrastructure.Repository.Interfaces
{
    public interface IFileManager
    {
        string SaveFile(MemoryStream fileStream, string folder, string format);
        bool DeleteFile(string path);
    }
}
