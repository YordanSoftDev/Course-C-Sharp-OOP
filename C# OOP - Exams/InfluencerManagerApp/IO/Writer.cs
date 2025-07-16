
using InfluencerManagerApp.IO.Contracts;
using System;
using System.IO;

namespace InfluencerManagerApp.IO
{
    public class Writer : IWriter
    {
        private readonly string filePath;

        public Writer()
        {
            string resultsPath = this.GetProjectDirectory() + @"Utilities/Results/";
            this.filePath = Path.Combine(resultsPath, "Actual.txt");

            File.WriteAllText(this.filePath, string.Empty);
        }
        public void Write(string message)
        {
            Console.Write(message);
        }

        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }

        public void WriteText(string message)
        {
            File.AppendAllText(this.filePath, message.TrimEnd() + 
                Environment.NewLine);
        }

        private string GetProjectDirectory()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var directoryName = Path.GetFileName(currentDirectory);
            var relativePath = directoryName.StartsWith("net6.0") ? @"../../../" : string.Empty;

            return relativePath;
        }
    }
}
