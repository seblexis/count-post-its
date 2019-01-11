using System.IO;

namespace CountPostIts.ConsoleUI.Services.Impl
{
    class FileWrapper : IFileWrapper
    {
        public bool CallFileExists(string filename)
        {
            return File.Exists(filename);
        }
    }
}
