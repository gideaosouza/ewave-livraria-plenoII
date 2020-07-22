using Livraria.Application.Interfaces;
using Livraria.Infrastructure.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Livraria.Application.Services
{
    public class UploadFileService : IUploadFileService
    {
        private readonly IFileManager fileManager;
        public UploadFileService(IFileManager fileManager)
        {
            this.fileManager = fileManager;
        }
        public bool DeleteFile(string path)
        {
            return fileManager.DeleteFile(path);
        }

        public string SaveFile(MemoryStream fileStream, string folder, string format)
        {
            return  fileManager.SaveFile(fileStream, folder, format);
        }
    }
}
