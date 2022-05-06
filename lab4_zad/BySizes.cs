using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4_zad
{
    public class BySizes : IEnumerable<string>
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
            string countString;
            string totalSizeString;
            string maxSizeString;
            string minSizeString;
            string averageSizeString;
            List<long?> tempB = new();
            List<long?> tempKB = new();
            List<long?> tempMB = new();
            List<long?> tempGB = new();

            foreach (var file in myFiles)
            {
                if (file.SizeInBytes <= 1024)
                {
                    tempB.Add(file.SizeInBytes);
                }
                if (file.SizeInBytes > 1024 && file.SizeInBytes <= 1048576)
                {
                    tempKB.Add(file.SizeInBytes);
                }
                if (file.SizeInBytes > 1048576 && file.SizeInBytes <= 1073741824)
                {
                    tempMB.Add(file.SizeInBytes);
                }
                if (file.SizeInBytes > 1073741824)
                {
                    tempGB.Add(file.SizeInBytes);
                }
            }

            if (tempB.Count > 0)
            {
                countString = tempB.Count.ToString();
                totalSizeString = SizeNormalizer(tempB.Sum());
                maxSizeString = SizeNormalizer(tempB.Max());
                minSizeString = SizeNormalizer(tempB.Min());
                averageSizeString = SizeNormalizer((long?)tempB.Average());
                bySizes.Add(key1, new List<string> { countString, totalSizeString, averageSizeString, minSizeString, maxSizeString });
            }
            else
            {
                bySizes.Add(key1, new List<string>() {"0", "0B", "0B", "0B", "0B" });
            }
            if (tempKB.Count > 0)
            {
                countString = tempKB.Count.ToString();
                totalSizeString = SizeNormalizer(tempKB.Sum());
                maxSizeString = SizeNormalizer(tempKB.Max());
                minSizeString = SizeNormalizer(tempKB.Min());
                averageSizeString = SizeNormalizer((long?)tempKB.Average());
                bySizes.Add(key2, new List<string> { countString, totalSizeString, averageSizeString, minSizeString, maxSizeString });
            }
            else
            {
                bySizes.Add(key2, new List<string>() { "0", "0KB", "0KB", "0KB", "0KB" });
            }
            if (tempMB.Count > 0)
            {
                countString = tempMB.Count.ToString();
                totalSizeString = SizeNormalizer(tempMB.Sum());
                maxSizeString = SizeNormalizer(tempMB.Max());
                minSizeString = SizeNormalizer(tempMB.Min());
                averageSizeString = SizeNormalizer((long?)tempMB.Average());
                bySizes.Add(key3, new List<string> { countString, totalSizeString, averageSizeString, minSizeString, maxSizeString });
            }
            else
            {
                bySizes.Add(key3, new List<string>() { "0", "0MB", "0MB", "0MB", "0MB" });
            }
            if (tempGB.Count > 0)
            {
                countString = tempGB.Count.ToString();
                totalSizeString = SizeNormalizer(tempGB.Sum());
                maxSizeString = SizeNormalizer(tempGB.Max());
                minSizeString = SizeNormalizer(tempGB.Min());
                averageSizeString = SizeNormalizer((long?)tempGB.Average());
                bySizes.Add(key4, new List<string> { countString, totalSizeString, averageSizeString, minSizeString, maxSizeString });
            }
            else
            {
                bySizes.Add(key4, new List<string>() { "0", "0GB", "0GB", "0GB", "0GB" });
            }
            return bySizes;
        }

        public void PrintBySizes()
        {
            Console.WriteLine();
            Console.WriteLine("By size:");
            Console.WriteLine("\t\t[Count]\t\t[Total size]\t[Average size]\t[Min size]\t[Max size]");
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

        public string SizeNormalizer(long? size)
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
            return bySizes.Keys.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
