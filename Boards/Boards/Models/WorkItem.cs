using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Boards.Models
{
    public abstract class WorkItem
    {
        public int Id { get; set; }
        public string Area { get; set; }
        public string IterationPath { get; set; }
        public int Priority { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();
        public Guid AuthorId { get; set; }
        public User Author { get; set; }
        public List<Tag> Tags { get; set; }
        public State State { get; set; }
        public int StateId { get; set; }
    }
}
