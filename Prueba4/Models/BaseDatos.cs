using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.WebPages;

namespace Prueba4.Models {
    public class BaseDatos {

        //Obtener los datos de la bbdd
        public List<Perro> obtenerPerros() {
            List<Perro> losPerros = new List<Perro>();
            String cnnStr = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;

            using (SqlConnection cnn = new SqlConnection(cnnStr)) {
                cnn.Open();

                SqlCommand cmdSql = new SqlCommand("Select * from Perro order by NombrePerro", cnn);

                SqlDataReader dr = cmdSql.ExecuteReader();

                while (dr.Read()) {
                    losPerros.Add(new Perro(dr["NumPerro"].ToString().AsInt(), dr["NombrePerro"].ToString(), dr["Edad"].ToString().AsInt(),
                        dr["Raza"].ToString(), dr["Tamaño"].ToString().AsFloat(), dr["Pelaje"].ToString(), dr["FechaNac"].ToString().AsDateTime().Date));
                }

                cnn.Close();
                cnn.Dispose();
            }

            return losPerros;
        }


        //Buscar los perros individuales por id
        public Perro buscarId(int id) {
            Perro perro = null;
            String cnnStr = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;

            using (SqlConnection cnn = new SqlConnection(cnnStr)) {
                cnn.Open();

                SqlCommand cmdSql = new SqlCommand("Select * from Perro where numPerro = @id", cnn);
                cmdSql.Parameters.AddWithValue("@id", id);

                SqlDataReader dr = cmdSql.ExecuteReader();

                if (dr.Read()) {
                    perro = new Perro(dr["NumPerro"].ToString().AsInt(), dr["NombrePerro"].ToString(), dr["Edad"].ToString().AsInt(),
                         dr["Raza"].ToString(), dr["Tamaño"].ToString().AsFloat(), dr["Pelaje"].ToString(), dr["FechaNac"].ToString().AsDateTime().Date);
                }


                cnn.Close();
                cnn.Dispose();
            }

            return perro;
        }

        //Eliminar Perros de la BBDD
        public int eliminarPerro(int id) {
            String cnnStr = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;

            using (SqlConnection cnn = new SqlConnection(cnnStr)) {
                cnn.Open();

                SqlCommand cmdSql = new SqlCommand("delete from Perro where numPerro = @id", cnn);
                cmdSql.Parameters.AddWithValue("@id", id);

                return cmdSql.ExecuteNonQuery();
            }
        }


        //Agregar Perros

        public int agregarPerro(Perro perrop) {
            String cnnStr = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(cnnStr)) {
                cnn.Open();

                SqlCommand cmdSql = new SqlCommand("insert into Perro (NumPerro, NombrePerro, Edad, Raza, Tamaño, Pelaje, FechaNac)" +
                    "values (@NumPerro, @NombrePerro, @Edad, @Raza, @Tamaño, @Pelaje, @FechaNac)", cnn);
                cmdSql.Parameters.AddWithValue("@NumPerro", perrop.NumeroRegistro);
                cmdSql.Parameters.AddWithValue("@NombrePerro", perrop.Nombre);
                cmdSql.Parameters.AddWithValue("@Edad", perrop.Edad);
                cmdSql.Parameters.AddWithValue("@Raza", perrop.Raza);
                cmdSql.Parameters.AddWithValue("@Tamaño", perrop.Tamaño);
                cmdSql.Parameters.AddWithValue("@Pelaje", perrop.Pelaje);
                cmdSql.Parameters.AddWithValue("@FechaNac", perrop.FechaNacimiento);

                return cmdSql.ExecuteNonQuery();
            }
        }

        //Editar perros
        public int editarPerro(Perro perrop) {
            String cnnStr = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
            using (SqlConnection cnn = new SqlConnection(cnnStr)) {
                cnn.Open();

                SqlCommand cmdSql = new SqlCommand("update Perro set NumPerro = @NumPerro, NombrePerro = @NombrePerro, Edad = @Edad," +
                    "Raza = @Raza, Tamaño = @Tamaño, Pelaje = @Pelaje, FechaNac = @FechaNac WHERE NumPerro = @NumPerro", cnn);

                cmdSql.Parameters.AddWithValue("@NumPerro", perrop.NumeroRegistro);
                cmdSql.Parameters.AddWithValue("@NombrePerro", perrop.Nombre);
                cmdSql.Parameters.AddWithValue("@Edad", perrop.Edad);
                cmdSql.Parameters.AddWithValue("@Raza", perrop.Raza);
                cmdSql.Parameters.AddWithValue("@Tamaño", perrop.Tamaño);
                cmdSql.Parameters.AddWithValue("@Pelaje", perrop.Pelaje);
                cmdSql.Parameters.AddWithValue("@FechaNac", perrop.FechaNacimiento);

                return cmdSql.ExecuteNonQuery();
            }

        }

    }
}