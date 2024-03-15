using ExamenZapatillas.Data;
using ExamenZapatillas.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace ExamenZapatillas.Repositories
{
    #region procedures
    /*CREATE PROCEDURE SP_IMAGEN_ZAPA
(@POSICION INT,
@IDZAPA INT,
@REGISTROS INT OUT)
AS
	SELECT @REGISTROS = COUNT(IDIMAGEN) FROM IMAGENESZAPASPRACTICA
	WHERE IDPRODUCTO = @IDZAPA
	SELECT IDIMAGEN, IDPRODUCTO, IMAGEN FROM 
	(SELECT CAST(
	ROW_NUMBER() OVER (ORDER BY IDIMAGEN) AS INT)
	AS POSICION,
	ISNULL(IDIMAGEN,0) AS IDIMAGEN, IDPRODUCTO, IMAGEN
	FROM IMAGENESZAPASPRACTICA
	WHERE IDPRODUCTO = @IDZAPA ) AS QUERY
	WHERE QUERY.POSICION = @POSICION

GO*/
    #endregion
    public class RepositoryZapatillas
    {
        private ZapatillasContext context;
        public RepositoryZapatillas(ZapatillasContext context)
        {
            this.context = context;
        }

        /*METODOS GENERALES GET*/
        public async Task<List<Zapatilla>> GetZapas()
        {
            return await this.context.Zapatillas.ToListAsync();
        }
        public async Task<List<ImagenZapatilla>> GetImagenes()
        {
            return await this.context.Imagenes.ToListAsync();
        }

        public async Task<Zapatilla> FindZapatilla(int idzapa)
        {
            var consulta = from datos in context.Zapatillas
                           where datos.IdZapatilla == idzapa
                           select datos;
            return await consulta.FirstOrDefaultAsync();
        }

        public async Task<ModelPaginarImagen>
            GetImagenZapaAsync
            (int posicion, int idzapa)
        {
            string sql = "SP_IMAGEN_ZAPA @POSICION, @IDZAPA, @REGISTROS OUT";
            SqlParameter pamPosicion = new SqlParameter("@POSICION", posicion);
            SqlParameter pamZapa = new SqlParameter("@IDZAPA", idzapa);
            SqlParameter pamRegistros = new SqlParameter("@REGISTROS", -1);
            pamRegistros.Direction = ParameterDirection.Output;

            var consulta = this.context.Imagenes.FromSqlRaw
                (sql, pamPosicion, pamZapa, pamRegistros);

            var datos = await consulta.ToListAsync();
            ImagenZapatilla imagen = datos.FirstOrDefault();

            int registros = (int)pamRegistros.Value;

            Zapatilla zapa = await this.FindZapatilla(idzapa);

            ModelPaginarImagen model = new ModelPaginarImagen
            {
                Imagen = imagen,
                numRegistros = registros,
                zapatilla = zapa
            };
            return model;
        }

    }
}

