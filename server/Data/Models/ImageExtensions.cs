
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public partial class ImagehubImage : IIdProvider
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}
