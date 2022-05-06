using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4_zad
{
    public class ByExtension : IEnumerable<string>
    {
        public IDictionary<string, List<MyFile>> filesByExtension = new Dictionary<string, List<MyFile>>();
        public IDictionary<string, List<string>> filesByExtensionSorted = new Dictionary<string, List<string>>();

        public ByExtension(List<MyFile> myFiles)
        {
            foreach (var file in myFiles)
            {
                if (filesByExtension.ContainsKey(file.Extension))
                {
                    filesByExtension[file.Extension].Add(file);
                }
                else
                {
                    filesByExtension.Add(file.Extension, new List<MyFile> { file });
                }
            }
        }

        public IDictionary<string, List<string>> Categorize()
        {

            int count = 0;
            long? totalSize = 0;
            long? maxSize = 0;
            long? minSize = 0;
            long? averageSize = 0;
            string countString;
            string totalSizeString;
            string maxSizeString;
            string minSizeString;
            string averageSizeString;
            foreach (var extension in filesByExtension)
            {
                foreach (var file in extension.Value)
                {
                    count++;
                    totalSize += file.SizeInBytes;
                    maxSize = extension.Value.Max(x => x.SizeInBytes);
                    minSize = extension.Value.Min(x => x.SizeInBytes);
                }
                averageSize = totalSize / count;
                countString = count.ToString();
                totalSizeString = SizeNormalizer(totalSize);
                averageSizeString = SizeNormalizer(averageSize);
                minSizeString = SizeNormalizer(minSize);
                maxSizeString = SizeNormalizer(maxSize);
                filesByExtensionSorted.Add(extension.Key, new List<string> { countString, totalSizeString, averageSizeString, minSizeString, maxSizeString });
                count = 0;
                totalSize = 0;
                maxSize = 0;
                minSize = 0;
                averageSize = 0;

            }
            if (!filesByExtensionSorted.ContainsKey("other"))
            {
                filesByExtensionSorted.Add("other", new List<string> { "0", "0B", "0B", "0B", "0B" });
            }
            return filesByExtensionSorted;

        }

        public void PrintByExtension()
        {
            IDictionary<string, List<string>> sizesByExtensions = Categorize();
            Console.WriteLine();
            Console.WriteLine("By extensions:");
            Console.WriteLine("\t[Count]\t\t[Total size]\t[Average size]\t[Min size]\t[Max size]");
            foreach (var label in sizesByExtensions)
            {
                Console.Write(label.Key + ": ");
                foreach (var size in label.Value)
                {
                    Console.Write(size + "\t\t");
                }
                Console.WriteLine();
            }
        }

        public static string SizeNormalizer(long? size)
        {
            string temp;
            if (size < 1024)
            {
                temp = $"{size}B";
            }
            else if (size < 1024 * 1024)
            {
                temp = $"{size / 1024}KB";
            }
            else if (size < 1024 * 1024 * 1024)
            {
                temp = $"{size / 1024 / 1024}MB";
            }
            else
            {
                temp = $"{size / 1024 / 1024 / 1024}GB";
            }
            return temp;
        }

        public IEnumerator<string> GetEnumerator()
        {
            return filesByExtension.Keys.GetEnumerator();
        }        

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
