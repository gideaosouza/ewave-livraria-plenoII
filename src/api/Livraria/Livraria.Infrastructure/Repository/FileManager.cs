using Livraria.Infrastructure.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Livraria.Infrastructure.Repository
{
    public class FileManager : IFileManager
    {
        public bool DeleteFile(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
                return true;
            }
            return false;
        }

        /// <summary>
        /// A forma de salvamente em disco é rudimentar não se pega um caminho exato, se a aplicação for usada diretamente do repositorio irá funcionar. 
        /// </summary>
        /// <param name="fileStream"></param>
        /// <param name="folder"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public string SaveFile(MemoryStream fileStream, string folder, string format)
        {
            if (fileStream == null)
            {
                throw new ArgumentNullException(nameof(fileStream));
            }
            var fileName = string.Format("{0}.{1}", Guid.NewGuid().ToString(), format);
            var directoryName = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

            DirectoryInfo networkDir = new DirectoryInfo(@directoryName);
            var newDirectory = networkDir.Parent.Parent.Parent.Parent.Parent.Parent.FullName + "\\client\\livraria-app\\src\\assets\\upload";

            if (!Directory.Exists(Path.Combine(newDirectory, folder)))
                Directory.CreateDirectory(Path.Combine(newDirectory, folder));

            using (var _fileStream = File.Create(Path.Combine(newDirectory, folder, fileName)))
            {
                fileStream.WriteTo(_fileStream);
                fileStream.Close();
            }
            return fileName;
        }
    }
}
