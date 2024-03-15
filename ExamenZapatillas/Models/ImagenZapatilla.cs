using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamenZapatillas.Models
{
    [Table("IMAGENESZAPASPRACTICA")]
    public class ImagenZapatilla
    {
        [Key]
        [Column("IDIMAGEN")]
        public int IdImagen { get; set; }
        [Column("IDPRODUCTO")]
        public int IdProducto { get; set; }
        [Column("IMAGEN")]
        public string NombreImagen { get; set; }
    }
}
