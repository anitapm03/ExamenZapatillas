using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamenZapatillas.Models
{
    [Table("V_ZAPAS_INDIVIDUAL")]
    public class VistaZapas
    {
		[Key]
		[Column("IDPRODUCTO")]
		public int IdProducto { get; set; }
		[Column("POSICION")]
		public int Posicion { get; set; }
		[Column("NOMBRE")]
		public string Nombre { get; set; }
		[Column("DESCRIPCION")]
		public string Descripcion { get; set; }
		[Column("PRECIO")]
		public int Precio { get; set; }
		[Column("IDIMAGEN")]
		public int IdImagen { get; set; }
		[Column("IMAGEN")]
		public string Imagen { get; set; }

    }
}
/*
 CREATE VIEW V_ZAPAS_INDIVIDUAL
AS
	SELECT CAST(
	ROW_NUMBER() OVER (ORDER BY Z.IDPRODUCTO) AS INT)
	AS POSICION,
	ISNULL(Z.IDPRODUCTO, 0) AS IDPRODUCTO, Z.NOMBRE,
	Z.DESCRIPCION, Z.PRECIO, I.IDIMAGEN, I.IMAGEN
	FROM ZAPASPRACTICA Z
	INNER JOIN IMAGENESZAPASPRACTICA I
	ON Z.IDPRODUCTO=I.IDPRODUCTO
GO
*/