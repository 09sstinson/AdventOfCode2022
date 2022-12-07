using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Solutions
{
    public class Directory
    {
        public Directory(string name, Directory parent) {
            Name = name;
            ParentDirectory = parent;
        }

        public string Name { get; set; }
        public Directory ParentDirectory { get; set; }
        public List<Directory> ChildDirectories { get; set; } = new();
        public List<File> Files { get; set; } = new();

        public int GetSize()
        {
            return Files.Sum(x => x.Size) + ChildDirectories.Sum(x => x.GetSize());
        }
    }

    public class File
    {
        public File(string name, int size)
        {
            Name = name;
            Size = size;
        }

        public string Name { get; set; }
        public int Size { get; set; }
    }
}
