namespace Core.Entities.Settings.Uploader
{
    public class Uploader
    {
        public int File_Id { get; set; }
        public int UploaderId { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
