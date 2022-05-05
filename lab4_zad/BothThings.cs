using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4_zad
{
    public class BothThings
    {
        public List<MyFile> files = new();
        public List<MyFolder> folders = new();


        public BothThings(string path)
        {
            if (File.Exists(path))
            {
                // This path is a file
                ProcessFile(path);
            }
            else if (Directory.Exists(path))
            {
                // This path is a directory
                ProcessDirectory(path);
            }
            else
            {
                Console.WriteLine("{0} is not a valid file or directory.", path);
            }
        }

        public void ProcessDirectory(string targetDirectory)
        {
            long countSize = 0;
            // Process the list of files found in the directory.
            string[] fileEntries = Directory.GetFiles(targetDirectory);
            foreach (string fileName in fileEntries)
            {                
                ProcessFile(fileName);
                countSize = new FileInfo(fileName).Length;
                //MyFolder myFolder = new(targetDirectory, countSize);
                //folders.Add(myFolder);                
            }
                

            // Recurse into subdirectories of this directory.
            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (string subdirectory in subdirectoryEntries)
            {
                ProcessDirectory(subdirectory);                
                MyFolder myFolder = new MyFolder(subdirectory, countSize);
                countSize = 0;
                folders.Add(myFolder);    
            }                
        }

        public void ProcessFile(string path)
        {
            FileInfo file = new(path);
            MyFile newFile = new(file.Name, file.FullName, file.Extension, file.Length);
            files.Add(newFile);           
        }

        public void PrintNode()
        {
            int? countDirectories = 0;
            int? countFiles = 0;
            long? sizeDirectories = 0;
            long? sizeFiles = 0;
            foreach (var item in files)
            {
                countFiles++;
                sizeFiles += item.SizeInBytes;
            }
            foreach (var item in folders)
            {
                countDirectories++;
                sizeDirectories += item.Size;
            }
            Console.WriteLine("Nodes:");
            Console.WriteLine("\t      [count]\t[total size]");
            Console.WriteLine($"Directories:\t{countDirectories}\t{sizeDirectories}");
            Console.WriteLine($"Files:\t\t{countFiles}\t{sizeFiles}");
            
        }

        
    }
}
