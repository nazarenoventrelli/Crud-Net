using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestorDePersonas.Models
{
    public class Persona
    {
        private long cod;
        private String nombre;
        private String apellido;
        private int edad;
        private DateTime fechaAlta;
        
        public Persona(long cod, String nombre, String apellido, int edad, DateTime fechaAlta)
        {
            this.cod = cod;
            this.nombre = nombre;
            this.apellido = apellido;
            this.edad = edad;
            this.fechaAlta = fechaAlta;
        }

        public Persona()
        {
        }

        public long getCod()
        {
            return cod;
        }

        public void setCod(long cod)
        {
            this.cod = cod;
        }

        public String getNombre()
        {
            return nombre;
        }
        
        public void setNombre(String nombre)
        {
            this.nombre = nombre;
        }
      
        public String getApellido()
        {
            return apellido;
        }

        public void setApellido(String apellido)
        {
            this.apellido = apellido;
        }

        public int getEdad()
        {
            return edad;
        }
        
        public void setEdad(int edad)
        {
            this.edad = edad;
        }

        public DateTime getFechaAlta()
        {
            return fechaAlta;
        }
     
        public void setFechaAlta(DateTime fechaAlta)
        {
            this.fechaAlta = fechaAlta;
        }
    }
    
}