using System.ComponentModel.DataAnnotations;

namespace App.Domain.Abstraction.Models
{
    public interface IChangedBySupport
    {
        [Required]
        int WorkerChangedBy { get; set; }
    }
}
