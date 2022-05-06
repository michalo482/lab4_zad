using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4_zad
{
    public class ByTypes : IEnumerable<string>
    {        
        public IDictionary<string, List<string>> sizesByLabels = new Dictionary<string, List<string>>();
        private readonly IDictionary<string, List<MyFile>> filesByLabels = new Dictionary<string, List<MyFile>>();

        public ByTypes(List<MyFile> myFile)
        {
            
            foreach (var label in myFile)
            {
                if (filesByLabels.ContainsKey(label.Label))
                {
                    filesByLabels[label.Label].Add(label);
                }
                else
                {
                    filesByLabels.Add(label.Label, new List<MyFile> { label });
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
            foreach (var label in filesByLabels)
            {                
                foreach (var file in label.Value)
                {
                    count++;
                    totalSize += file.SizeInBytes;
                    maxSize = label.Value.Max(x => x.SizeInBytes);
                    minSize = label.Value.Min(x => x.SizeInBytes);                    
                }
                averageSize = totalSize / count;
                countString = count.ToString();
                totalSizeString = SizeNormalizer(totalSize);
                averageSizeString = SizeNormalizer(averageSize);
                minSizeString = SizeNormalizer(minSize);
                maxSizeString = SizeNormalizer(maxSize);
                sizesByLabels.Add(label.Key, new List<string> {countString, totalSizeString, averageSizeString, minSizeString, maxSizeString });
                count = 0;
                totalSize = 0;
                maxSize = 0;
                minSize = 0;
                averageSize = 0;
                
            }
            if (!sizesByLabels.ContainsKey("other"))
            {
                sizesByLabels.Add("other", new List<string> { "0", "0B", "0B", "0B", "0B" });
            }
            return sizesByLabels;

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
        public void Print()
        {
            IDictionary<string, List<string>> sizesByLabels = Categorize();
            Console.WriteLine();
            Console.WriteLine("By types:");
            Console.WriteLine("\t[Count]\t\t[Total size]\t[Average size]\t[Min size]\t[Max size]");
            foreach (var label in sizesByLabels)
            {
                Console.Write(label.Key + ": ");
                foreach (var size in label.Value)
                {
                    Console.Write(size + "\t\t");
                }
                Console.WriteLine();
            }
        }
        
        public IEnumerator<string> GetEnumerator()
        {
            return sizesByLabels.Keys.GetEnumerator();
        }
        

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
