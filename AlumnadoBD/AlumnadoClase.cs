using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlumnadoBD
{

    // Vamos a crear una variable para tener ahí los datos de autenticación
    // Los datos de conexión


    

    internal class AlumnadoClase
    {
    private string cadenaconexion = "Data Source=.;Initial Catalog=ciclo;Integrated Security=True";
    // Ahora hacemos un método para poder ya HACER la conexión

        // AL EJECUTAR ESTE METODO, QUEREMOS SABER SI SE CONECTA O NO
        public bool conectando()
        {
            try
            {
                SqlConnection conexion = new SqlConnection(cadenaconexion);
                conexion.Open();

            }
            catch(Exception ex)
            {
                return false;
              
            }

            return true;
            // luego de editar esto, retornamos al botón

        }


        // sobrecarga sin parámetro
        public List<Perfiles> mostrar()
        {
            

            List<Perfiles> listaperfil = new List<Perfiles>();
            string consulta = "select * from notas";
           
            using(SqlConnection conecperfil = new SqlConnection(cadenaconexion))
            {
                //todo lo relacionado con respecto a acceso a datos se hace
                //mediante un comando
                SqlCommand comando = new SqlCommand(consulta,conecperfil);
                try
                {
                    conecperfil.Open();
                    SqlDataReader lector = comando.ExecuteReader();
                    while(lector.Read())
                    {
                        Perfiles perfiluno = new Perfiles();
                        perfiluno.id = lector.GetInt32(0);
                        perfiluno.Nombre = lector[1].ToString();
                        perfiluno.Notap1 = lector.GetInt32(2);
                        perfiluno.Notap2 = lector.GetInt32(3);
                        perfiluno.Notap3 = lector.GetInt32(4);
                        perfiluno.Asistencia = lector.GetInt32(5);


                        listaperfil.Add(perfiluno);
                    }
                    lector.Close();
                    conecperfil.Close();

                }catch(Exception ex)
                {


                    throw new Exception("Hubo un error" + ex.Message);


                }
             
            }


            return listaperfil;
        }




        // Creo otro método para poder guardar los datos en la BD
       


            




        //Acá se va a generar una sobrecarga
        // sobrecarga con parámetro
        public List<Perfiles> mostrar(int id)
        {

        string consulta = "select * from notas" + " where ID=@id";
        // esa información que yo obtenga debo de guardarla en un lugar
        // para así poder retornarla
        List<Perfiles> listap = new List<Perfiles>();
        using(SqlConnection conecperfil = new SqlConnection(cadenaconexion))
        {

                SqlCommand comando = new SqlCommand( consulta, conecperfil);
                comando.Parameters.AddWithValue("@id", id);
                try
                {
                    conecperfil.Open();
                    SqlDataReader lector = comando.ExecuteReader();
                    lector.Read();
                    Perfiles perfiltemp = new Perfiles();
                    perfiltemp.id= lector.GetInt32(0);
                    perfiltemp.Nombre = lector[1].ToString();
                    perfiltemp.Notap1 = lector.GetInt32(2);
                    perfiltemp.Notap2 = lector.GetInt32(3);
                    perfiltemp.Notap3 = lector.GetInt32(4);
                    perfiltemp.Asistencia = lector.GetInt32(5);
                    lector.Close();
                    conecperfil.Close();
                    listap.Add(perfiltemp);
                    
                }catch (Exception ex) 
                { 
                
                    throw new Exception("Hay un error "+ ex.Message); 
                
                
                }




        }


        return listap;

        }





















        }









    public class Perfiles
    {

        public int id { get; set; }
        public string Nombre { get; set; }
        public int Notap1 { get; set; }

        public int Notap2 { get; set; }

        public int Notap3 { get; set; }

        public int Asistencia { get; set; }



    }










}


    




