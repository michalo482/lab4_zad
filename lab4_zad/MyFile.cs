namespace lab4_zad
{
    public class MyFile
    {
        public string? Name { get; set; }
        public string? Path { get; set; }
        public string? Extension { get; set; }
        public string? Size { get; set; }
        public long? SizeInBytes { get; set; }
        public string? Label { get; set; }

        
        public MyFile(string name, string path, string extension, long size)
        {
            Name = name;
            Path = path;
            Extension = extension;           
            Size = SizeNormalizer(size);
            SizeInBytes = size;
            Label = Labeling(extension);
        }       

        public static string SizeNormalizer(long size)
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

        public static string Labeling(string extension)
        {
            Dictionary<string, List<string>> labels = new Dictionary<string, List<string>>();
            labels.Add("image", new List<string>() { ".jpg", ".jpeg", ".png", ".gif" });
            labels.Add("audio", new List<string>() { ".mp3", ".wav", ".aac", ".flac" });
            labels.Add("video", new List<string>() { ".mp4", ".avi", ".mkv", ".flv" });
            labels.Add("document", new List<string>() { ".txt", ".doc", ".docx", ".pdf" });
            labels.Add("compressed", new List<string>() { ".zip", ".rar", ".7z", ".tar", ".gz" });
            string temp = "other";
            foreach (var label in labels)
            {
                foreach (var ext in label.Value)
                {
                    if (extension == ext)
                    {
                        temp = label.Key;
                    }                    
                }
            }
            return temp;            
        }
    }  
}