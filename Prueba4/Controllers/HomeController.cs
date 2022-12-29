using Prueba4.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;

namespace Prueba4.Controllers {
    public class HomeController : Controller {
        // GET: Home
        public ActionResult Index() {
            //Simular base de datos y entregar una lista 
            List<Perro> losPerros = new List<Perro>();

            BaseDatos bd = new BaseDatos();

            losPerros = bd.obtenerPerros();


            return View(losPerros);
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)//falta el buscar
        {
            BaseDatos bd = new BaseDatos();

            Perro p = bd.buscarId(id);
            if (p != null)
                return View(p);
            else
                return Content("<h1> No existe </h1>");
        }

        // GET: Home/Create
        public ActionResult Create() {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection) {
            try {
                BaseDatos bd = new BaseDatos();

                Perro p = new Perro();
                //Obtener info del collection
                p.NumeroRegistro = collection["NumeroRegistro"].ToString().AsInt();
                p.Nombre = collection["Nombre"].ToString();
                p.Edad = collection["Edad"].ToString().AsInt();
                p.Raza = collection["Raza"].ToString();
                p.Tamaño = collection["Tamaño"].ToString().AsFloat();
                p.Pelaje = collection["Pelaje"].ToString();
                p.FechaNacimiento = collection["FechaNacimiento"].ToString().AsDateTime().Date;

                Perro pp = bd.buscarId(p.NumeroRegistro);

                if (pp == null) {
                    bd.agregarPerro(p);
                }
                else {
                    return Content("<h1>El perro ya se encuentra registrado</h1>");
                }

                return RedirectToAction("Index");
            }
            catch {
                return View();
            }
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id) {

            BaseDatos bd = new BaseDatos();

            Perro p = bd.buscarId(id);

            return View(p);
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection) {
            try {
                BaseDatos bd = new BaseDatos();

                Perro p = new Perro();

                Perro pp = bd.buscarId(id);

                p.NumeroRegistro = id;
                p.Nombre = collection["Nombre"].ToString();
                p.Edad = collection["Edad"].ToString().AsInt();
                p.Raza = collection["Raza"].ToString();
                p.Tamaño = collection["Tamaño"].ToString().AsFloat();
                p.Pelaje = collection["Pelaje"].ToString();
                p.FechaNacimiento = collection["FechaNacimiento"].ToString().AsDateTime().Date;

                if (pp.NumeroRegistro == p.NumeroRegistro) {
                    bd.editarPerro(p);
                }
                else {
                    return Content("<h1>Perro no encontrado</h1>");
                }

                return RedirectToAction("Index");
            }
            catch {
                return View();
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id) {
            BaseDatos bd = new BaseDatos();

            Perro p = bd.buscarId(id);

            return View(p);
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection) {
            try {
                // TODO: Add delete logic here

                BaseDatos bd = new BaseDatos();

                bd.eliminarPerro(id);

                return RedirectToAction("Index");
            }
            catch {
                return View();
            }
        }





    }
}
