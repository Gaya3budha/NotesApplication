namespace NotesApplication.Models
{
    public class NotesDTO
    {
        public int NotesId { get; set; }

        public string NotesDescription { get; set; }

        public char Priority { get; set; }

        public DateTime lastModifiedDate { get; set; }
    }
}
