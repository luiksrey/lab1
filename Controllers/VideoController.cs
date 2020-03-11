using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using MVCPlantilla.Utilerias;

namespace MvcPlantilla.Controllers
{
    public class VideoController : Controller
    {
        //
        // GET: /Video/

        public ActionResult Index()
        {
            ViewData["video"]=BaseHelper.ejecutarConsulta("Select *From video", CommandType.Text);
            return View();
        }

        public ActionResult Insertar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Insertar(int idVideo,string titulo,int repro,string url)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@idVideo", idVideo));
            parametros.Add(new SqlParameter("@titulo", titulo));
            parametros.Add(new SqlParameter("@repro", repro));
            parametros.Add(new SqlParameter("@url", url));

         BaseHelper.ejecutarSentencia("Insert into video values (@idVideo,@titulo,@repro,@url)",CommandType.Text,parametros);
            return RedirectToAction("Index", "Video");
          
        }


        public ActionResult Eliminar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Eliminar(int idVideo)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@idVideo", idVideo));
            BaseHelper.ejecutarConsulta("Delete from video where idVideo=@idVideo", CommandType.Text, parametros);
            return RedirectToAction("Index", "Video");
        }

        public ActionResult Modificar()
        {
            return View();
        }
       

        [HttpPost]
        public ActionResult Modificar(int idVideo, string titulo, int repro, string url)
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@idVideo", idVideo));
            parametros.Add(new SqlParameter("@titulo", titulo));
            parametros.Add(new SqlParameter("@repro", repro));
            parametros.Add(new SqlParameter("@url", url));
            BaseHelper.ejecutarSentencia("Update video set titulo=@titulo,repro=@repro,url=@url where idVideo=@idVideo", CommandType.Text, parametros);
            return RedirectToAction("Index", "Video");
        }
        
       

    }
}
