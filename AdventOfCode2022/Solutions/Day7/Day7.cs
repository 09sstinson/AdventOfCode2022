using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

namespace AdventOfCode2022.Solutions
{
    public class Day7 : IDay
    {
        public string SolvePart1(IEnumerable<string> input)
        {
            var fileSystem = GenerateFileSystem(input);

            return fileSystem.Directories
                .Select(x => x.GetSize())
                .Where(x => x < 100000)
                .Sum()
                .ToString();
        }

        public string SolvePart2(IEnumerable<string> input)
        {
            var fileSystem = GenerateFileSystem(input);

            var currentUsed = fileSystem.GetRootSize();

            return fileSystem.Directories.Select(x => x.GetSize())
                .Where(x => currentUsed - x <= 40000000)
                .Min()
                .ToString();
        }

        private static FileSystem GenerateFileSystem(IEnumerable<string> input)
        {
            var fileSystem = new FileSystem();

            foreach (var line in input)
            {
                switch (line)
                {
                    case "$ ls":
                        break;
                    case "$ cd /":
                        fileSystem.AddRootDirectory();
                        break;
                    case "$ cd ..":
                        fileSystem.MoveUpDirectory();
                        break;
                    case string str when str.StartsWith("$ cd"):
                        fileSystem.MoveDownDirectory(line.Split(" ")[2]);
                        break;
                    case string str when str.StartsWith("dir"):
                        fileSystem.AddChildDirectory(line.Split(" ")[1]);
                        break;
                    default:
                        var split = line.Split(" ");
                        fileSystem.AddFile(new File(split[1], int.Parse(split[0])));
                        break;
                }
            }

            return fileSystem;
        }
    }
}
