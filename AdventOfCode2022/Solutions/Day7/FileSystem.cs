using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Solutions
{
    internal class FileSystem
    {
        public List<Directory> Directories { get; set; } = new();

        public Directory CurrentDirectory { get; set; }

        public void MoveUpDirectory()
        {
            CurrentDirectory = CurrentDirectory.ParentDirectory;
        }

        public void MoveDownDirectory(string directoryName)
        {
            CurrentDirectory = CurrentDirectory.ChildDirectories.Single(x => x.Name == directoryName);
        }

        public void AddChildDirectory(string directoryName)
        {
            var newDirectory = new Directory(directoryName, CurrentDirectory);

            CurrentDirectory.ChildDirectories.Add(newDirectory);
            Directories.Add(newDirectory);
        }

        public void AddRootDirectory()
        {
            var newDirectory = new Directory("root", null);
            CurrentDirectory = newDirectory;
            Directories.Add(newDirectory);
        }
        public int GetRootSize()
        {
            return Directories.Single(x => x.ParentDirectory is null).GetSize();
        }

        public void AddFile(File file)
        {
            CurrentDirectory.Files.Add(file);
        }
    }
}
