namespace Core.Entities.Settings.Uploader
{
    public class FileUploaderPath
    {
        public int OrderFormId { get; set; }
        public int FileId { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
