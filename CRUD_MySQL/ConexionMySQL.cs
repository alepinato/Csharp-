using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace CRUD_MySQL
{
    class ConexionMySQL
    {
        MySqlConnection conexion = new MySqlConnection();
        string cadena = "server=localhost;port=3306;user id=root;password=;database=almacenbd";

        public string Agregar(int id, string nombre, string apellido)
        {
            try
            {
                conexion.ConnectionString = cadena;
                conexion.Open();
                
                string comando = "INSERT INTO clientes (idcli, nomcli, ape) VALUES (id,nombre,apellido)";
                MySqlCommand cmd = new MySqlCommand(comando, conexion);
                cmd.Parameters.AddWithValue("@idcli", id);
                cmd.Parameters.AddWithValue("@nomcli", nombre);
                cmd.Parameters.AddWithValue("@apecli", apellido);
                cmd.ExecuteNonQuery();
                conexion.Close();
                return "Agregado con éxito";
            }
            catch (MySqlException ex)
            {
                return ex.ToString();
            }
        }

        public string Editar(int id, string nombre, string apellido)
        {
            try
            {
                conexion.ConnectionString = cadena;
                conexion.Open();
                string comando = "UPDATE clientes SET nombre=@nomcli,apellido=@apecli WHERE @idcli=id";
                MySqlCommand cmd = new MySqlCommand(comando, conexion);
                //cmd.Parameters.AddWithValue("@idcli", id);
                cmd.Parameters.AddWithValue("@nomcli", nombre);
                cmd.Parameters.AddWithValue("@apecli", apellido);
                cmd.ExecuteNonQuery();
                conexion.Close();
                return "Modificado con éxito";
            }
            catch (MySqlException ex)
            {
                return ex.ToString();
            }
        }

        public string Eliminar(int id)
        {
            try
            {
                conexion.ConnectionString = cadena;
                conexion.Open();
                string comando = "DELETE FROM clientes WHERE id = @idcli";
                MySqlCommand cmd = new MySqlCommand(comando, conexion);
                cmd.Parameters.AddWithValue("@idcli", id);
                cmd.ExecuteNonQuery();
                conexion.Close();
                return "Eliminado con éxito";
            }
            catch (MySqlException ex)
            {
                return ex.ToString();
            }
        }


        public DataSet VerTabla()
        {
                conexion.ConnectionString = cadena;
                conexion.Open();
                string comando = "SELECT * FROM clientes";
                MySqlDataAdapter da = new MySqlDataAdapter(comando, conexion);
                DataSet dt = new DataSet();
                da.Fill(dt);
                conexion.Close();
                return dt;
        }
    }

        
    }
