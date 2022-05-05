using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4_zad
{
    public class BySizes 
    {
        public IDictionary<string, List<string>> bySizes = new Dictionary<string, List<string>>();       
        
        public BySizes(List<MyFile> myFiles)
        {
            AddingToBySize(myFiles);
        }

        public IDictionary<string, List<string>> AddingToBySize(List<MyFile> myFiles)
        {
            string key1 = "      . <= 1KB";
            string key2 = "1KB < . <= 1MB";
            string key3 = "1MB < . <= 1GB";
            string key4 = "1GB < .       ";
            long? totalSize = 0;
            int count = 0;
            long? maxSize = 0;
            long? minSize = 0;
            long? averageSize = 0;
            string countString;
            string totalSizeString;
            string maxSizeString;
            string minSizeString;
            string averageSizeString;
            List<string> tempList = new();

            foreach (var file in myFiles)
            {
                if (file.SizeInBytes <= 1024)
                {
                    count++;
                    totalSize += file.SizeInBytes;
                    maxSize = myFiles.Max(x => x.SizeInBytes);
                    minSize = myFiles.Min(x => x.SizeInBytes);
                }
            }
            if (count > 0)
            {
                averageSize = totalSize / count;
                countString = count.ToString();
                totalSizeString = SizeNormalizer(totalSize);
                averageSizeString = SizeNormalizer(averageSize);
                minSizeString = SizeNormalizer(minSize);
                maxSizeString = SizeNormalizer(maxSize);
                tempList = new List<string> { countString, totalSizeString, averageSizeString, minSizeString, maxSizeString };
                bySizes.Add(key1, tempList);
                count = 0;
                totalSize = 0;
                maxSize = 0;
                minSize = 0;
                averageSize = 0;
            }
            else
            {
                tempList = new List<string> { "0", "0B", "0B", "0B", "0B" };
                bySizes.Add(key1, tempList);
            }
            foreach (var file in myFiles)
            {
                if (file.SizeInBytes <= 1048576 && file.SizeInBytes > 1024)
                {
                    count++;
                    totalSize += file.SizeInBytes;
                    maxSize = myFiles.Max(x => x.SizeInBytes);
                    minSize = myFiles.Min(x => x.SizeInBytes);
                }
            }
            if (count > 0)
            {
                averageSize = totalSize / count;
                countString = count.ToString();
                totalSizeString = SizeNormalizer(totalSize);
                averageSizeString = SizeNormalizer(averageSize);
                minSizeString = SizeNormalizer(minSize);
                maxSizeString = SizeNormalizer(maxSize);
                tempList = new List<string> { countString, totalSizeString, averageSizeString, minSizeString, maxSizeString };
                bySizes.Add(key2, tempList);
                count = 0;
                totalSize = 0;
                maxSize = 0;
                minSize = 0;
                averageSize = 0;
            }
            else
            {
                tempList = new List<string> { "0", "0B", "0B", "0B", "0B" };
                bySizes.Add(key2, tempList);
            }
            foreach (var file in myFiles)
            {
                if (file.SizeInBytes <= 1073741824 && file.SizeInBytes > 1048576)
                {
                    count++;
                    totalSize += file.SizeInBytes;
                    maxSize = myFiles.Max(x => x.SizeInBytes);
                    minSize = myFiles.Min(x => x.SizeInBytes);
                }
            }
            if (count > 0)
            {
                averageSize = totalSize / count;
                countString = count.ToString();
                totalSizeString = SizeNormalizer(totalSize);
                averageSizeString = SizeNormalizer(averageSize);
                minSizeString = SizeNormalizer(minSize);
                maxSizeString = SizeNormalizer(maxSize);
                tempList = new List<string> { countString, totalSizeString, averageSizeString, minSizeString, maxSizeString };
                bySizes.Add(key3, tempList);
                count = 0;
                totalSize = 0;
                maxSize = 0;
                minSize = 0;
                averageSize = 0;
            }
            else
            {
                tempList = new List<string> { "0", "0B", "0B", "0B", "0B" };
                bySizes.Add(key3, tempList);
            }
            foreach (var file in myFiles)
            {
                if (file.SizeInBytes > 1073741824)
                {
                    count++;
                    totalSize += file.SizeInBytes;
                    maxSize = myFiles.Max(x => x.SizeInBytes);
                    minSize = myFiles.Min(x => x.SizeInBytes);
                }
            }
            if (count > 0)
            {
                averageSize = totalSize / count;
                countString = count.ToString();
                totalSizeString = SizeNormalizer(totalSize);
                averageSizeString = SizeNormalizer(averageSize);
                minSizeString = SizeNormalizer(minSize);
                maxSizeString = SizeNormalizer(maxSize);
                tempList = new List<string> { countString, totalSizeString, averageSizeString, minSizeString, maxSizeString };
                bySizes.Add(key4, tempList);
                count = 0;
                totalSize = 0;
                maxSize = 0;
                minSize = 0;
                averageSize = 0;
            }
            else
            {
                tempList = new List<string> { "0", "0B", "0B", "0B", "0B" };
                bySizes.Add(key4, tempList);
            }
            return bySizes;
        }

        public void PrintBySizes()
        {
            Console.WriteLine();
            Console.WriteLine("By size:");
            Console.WriteLine("\t[Count]\t\t[Total size]\t[Average size]\t[Min size]\t[Max size]");
            foreach (var key in bySizes)
            {
                Console.Write(key.Key + ": ");
                foreach (var value in key.Value)
                {
                    Console.Write(value + "\t\t");
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

    }
}
