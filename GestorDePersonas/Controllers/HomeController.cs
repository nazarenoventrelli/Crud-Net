using GestorDePersonas.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace GestorDePersonas.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            return View();
        }

        public PartialViewResult Alta()
        {

            return PartialView("_alta");
        }

        public PartialViewResult VerListado()
        {
            Models.GestorDePersonas gestor = new Models.GestorDePersonas();

            List<Persona> listaPersonas = gestor.RecuperarTodas();

            return PartialView("_verListado", listaPersonas);
        }

        public PartialViewResult VerModificar(long cod)
        {
            Models.GestorDePersonas gestor = new Models.GestorDePersonas();

            Persona persona = gestor.Recuperar(cod);

        
            return PartialView("_modificar", persona);
          
           
        }
        [HttpPost]
        public PartialViewResult Alta(String nombre, String apellido, int edad)
        {
            Models.GestorDePersonas gestor = new Models.GestorDePersonas();

            Persona p = new Persona();
            p.setNombre(nombre);
            p.setApellido(apellido);
            p.setEdad(edad);
            p.setFechaAlta(DateTime.Today.Date);

            gestor.Alta(p);
           return VerListado();
        }

        [HttpPost]
        public PartialViewResult Borrar(long cod)
        {
            Models.GestorDePersonas gestor = new Models.GestorDePersonas();

            gestor.Borrar(cod);

            return VerListado();
        }
        [HttpPost]
        public PartialViewResult Modificar(long cod,String nombre,String apellido,int edad,String fecha_alta)
        {
            Models.GestorDePersonas gestor = new Models.GestorDePersonas();

            try
            {
                Persona p = new Persona(cod, nombre, apellido, edad, DateTime.Parse(fecha_alta));
                gestor.Modificar(p);
            }
            catch (Exception ex) {

                return VerModificar(cod);
                    }

            return VerListado();
        }

        public PartialViewResult Buscar(String nombre,String apellido)
        {
            
            Models.GestorDePersonas gestor = new Models.GestorDePersonas();
            List<Persona> listaPersonas;

            if (nombre == "" && apellido == "")
            {
                listaPersonas = gestor.RecuperarTodas();
            }
            else
            {
             listaPersonas = gestor.Buscar(nombre, apellido);

            }

            return PartialView("_verListado", listaPersonas);
        }
    }
       
    
}