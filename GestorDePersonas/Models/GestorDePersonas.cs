using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;

namespace GestorDePersonas.Models
{
    public class GestorDePersonas
    {

        private SqlConnection con;


        private void Conectar()
        {


            String constr = ConfigurationManager.ConnectionStrings["administracion"].ToString();
            con = new SqlConnection(constr);
        }



        public void Alta(Persona p)
        {
            try
            {
                Conectar();
                SqlCommand comando = new SqlCommand("insert into Personas(nombre,apellido,edad,fecha_alta) values (@nombre,@apellido,@edad,@fecha_alta)", con);

                comando.Parameters.Add("@nombre", SqlDbType.VarChar);
                comando.Parameters.Add("@apellido", SqlDbType.VarChar);
                comando.Parameters.Add("@edad", SqlDbType.Int);
                comando.Parameters.Add("@fecha_alta", SqlDbType.DateTime);

                comando.Parameters["@nombre"].Value = p.getNombre();
                comando.Parameters["@apellido"].Value = p.getApellido();
                comando.Parameters["@edad"].Value = p.getEdad();
                comando.Parameters["@fecha_alta"].Value = p.getFechaAlta();

                con.Open();
                 comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally {
                try
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
                catch { }
            }
        }
     
        public List<Persona> RecuperarTodas()
        {
            List<Persona> personas = new List<Persona>();
            try
            {
                Conectar();

                SqlCommand comando = new SqlCommand("select cod,nombre,apellido,edad,fecha_alta from Personas", con);
                con.Open();
                SqlDataReader registros = comando.ExecuteReader();


                while (registros.Read())
                {
                    Persona P = new Persona();
                    P.setCod(long.Parse(registros["cod"].ToString()));
                    P.setNombre(registros["nombre"].ToString());
                    P.setApellido(registros["apellido"].ToString());
                    P.setEdad(int.Parse(registros["edad"].ToString()));
                    P.setFechaAlta(DateTime.Parse(registros["fecha_alta"].ToString()));

                    personas.Add(P);

                }

            }
            catch(Exception ex) {  }
            finally {
                try {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
                catch(Exception ex) { }
              
            }


            return personas;

        }
        public List<Persona>Buscar(String nombre, String apellido)
        {
            

            List<Persona> personas = new List<Persona>();
            try
            {

                Conectar();
                SqlCommand comando = new SqlCommand("select cod,nombre,apellido,edad,fecha_alta from Personas where (nombre=@nombre or apellido=@apellido) ", con);
                comando.Parameters.Add("@nombre", SqlDbType.VarChar);
                comando.Parameters["@nombre"].Value = nombre;
                comando.Parameters.Add("@apellido", SqlDbType.VarChar);
                comando.Parameters["@apellido"].Value = apellido;

                con.Open();

                SqlDataReader registros = comando.ExecuteReader();

                while (registros.Read())
                {
                    Persona P = new Persona();
                    P.setCod(long.Parse(registros["cod"].ToString()));
                    P.setNombre(registros["nombre"].ToString());
                    P.setApellido(registros["apellido"].ToString());
                    P.setEdad(int.Parse(registros["edad"].ToString()));
                    P.setFechaAlta(DateTime.Parse(registros["fecha_alta"].ToString()));

                    personas.Add(P);

                }
            }
            catch (Exception ex) {  }
            finally {
                try {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
                catch (Exception ex) { }
            }
            return personas;

        }
        
        public Persona Recuperar(long cod)
        {
            Persona P = new Persona();
            try
            {

                Conectar();
                SqlCommand comando = new SqlCommand("select cod,nombre,apellido,edad,fecha_alta from personas where cod=@cod", con);

                comando.Parameters.Add("@cod", SqlDbType.BigInt);
                comando.Parameters["@cod"].Value = cod;
                con.Open();

                SqlDataReader registros = comando.ExecuteReader();


                if (registros.Read())
                {
                    P.setCod(long.Parse(registros["cod"].ToString()));
                    P.setNombre(registros["nombre"].ToString());
                    P.setApellido(registros["apellido"].ToString());
                    P.setEdad(int.Parse(registros["edad"].ToString()));
                    P.setFechaAlta(DateTime.Parse(registros["fecha_alta"].ToString()));

                }
            }
            catch (Exception ex) { }
            finally
            {
                try
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
                catch(Exception ex) { }
            }
           
            return P;
        }
    
        public void Modificar(Persona P)
        {
            try
            {
                Conectar();

                SqlCommand comando = new SqlCommand("update Personas set nombre=@nombre,apellido=@apellido,edad=@edad,fecha_alta=@fecha_alta where cod=@cod", con);

                comando.Parameters.Add("@nombre", SqlDbType.VarChar);
                comando.Parameters.Add("@apellido", SqlDbType.VarChar);
                comando.Parameters.Add("@edad", SqlDbType.Int);
                comando.Parameters.Add("@fecha_alta", SqlDbType.DateTime);
                comando.Parameters.Add("@cod", SqlDbType.BigInt);

                comando.Parameters["@nombre"].Value = P.getNombre();
                comando.Parameters["@apellido"].Value = P.getApellido();
                comando.Parameters["@edad"].Value = P.getEdad();
                comando.Parameters["@fecha_alta"].Value = P.getFechaAlta();
                comando.Parameters["@cod"].Value = P.getCod();

                con.Open();

                comando.ExecuteNonQuery();
            }
            catch (Exception ex) { }
            finally {
                try
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
                catch (Exception ex){ }
            }
      

        }

       
        public void Borrar(long cod)
        {
            try
            {
                Conectar();
                SqlCommand comando = new SqlCommand("delete from Personas where cod=@cod", con);
                comando.Parameters.Add("@cod", SqlDbType.BigInt);
                comando.Parameters["@cod"].Value = cod;
                con.Open();

                comando.ExecuteNonQuery();
            }
            catch (Exception ex) { }
            finally {
                try {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();

                    }
                }
                catch(Exception ex) { }
            }

        }


    }
}