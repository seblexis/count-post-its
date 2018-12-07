using System.IO;

namespace CountPostIts.ConsoleUI
{
    class FileWrapper : IFileWrapper
    {
        public bool CallFileExists(string filename)
        {
            return File.Exists(filename);
        }
    }
}
