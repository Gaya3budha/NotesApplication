using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NotesApplication.Models
{
    public class Notes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NotesId { get; set; }

        public string NotesDescription { get; set; }

        public char Priority { get; set; }

        public DateTime lastModifiedDate { get; set; } = DateTime.Now;
    }
}
