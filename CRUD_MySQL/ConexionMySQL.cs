using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace CRUD_MySQL
{
    class ConexionMySQL
    {
        MySqlConnection conexion = new MySqlConnection();
        string cadena = "server=localhost;port=3306;UID=root;password=;database=sistema_usuarios";

        public string Agregar(int id, string nombre, string apellido)
        {
            conexion.ConnectionString = cadena;
            conexion.Open();
            string comando ="INSERT INTO usuarios VALUES (@id,@nombre,@apellido)";
            MySqlCommand cmd = new MySqlCommand(comando, conexion);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@apellido", apellido);
            cmd.ExecuteNonQuery();
            conexion.Close();
            return "Agregado con éxito";
        }
        public string Editar(int id, string nombre, string apellido)
        {
            conexion.ConnectionString = cadena;
            conexion.Open();
            string comando = "UPDATE usuarios SET (nombre = @nombre,apellido=@apellido) WHERE id =@id";
            MySqlCommand cmd = new MySqlCommand(comando, conexion);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@apellido", apellido);
            cmd.ExecuteNonQuery();
            conexion.Close();
            return "Agregado con éxito";
        }

        public string Eliminar(int id)
        {
            conexion.ConnectionString = cadena;
            conexion.Open();
            string comando = "DELETE FROM usuarios WHERE id = @id";
            MySqlCommand cmd = new MySqlCommand(comando, conexion);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            conexion.Close();
            return "Eliminado con éxito";
        }
        public DataSet VerTablal()
        {
            conexion.ConnectionString = cadena;
            conexion.Open();
            string comando = "SELECT * FROM usuarios";
            MySqlCommand cmd = new MySqlCommand(comando, conexion);
            MySqlDataAdapter da = new MySqlDataAdapter(comando, conexion);
            DataSet dt = new DataSet();
            da.Fill();
            conexion.Close();
            return dt;
        }
    }

        
    }
