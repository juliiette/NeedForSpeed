using System.ComponentModel.DataAnnotations;

namespace Data.Entity
{
    public abstract class BaseEntity<TKey>
    {
        [Key]
        public TKey Id { get; set; }
    }
}