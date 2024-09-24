using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using ZPIDI_PORTAL.Models;
using ZPIDI_PORTAL.Models.DataBase;

namespace ZPIDI_PORTAL.Controllers
{
    public class SOLICITUDESController : Controller
    {
        private db_a872a9_gomotorsEntities db = new db_a872a9_gomotorsEntities();
        
        //--------------------VISTAS-------------------------------------------
        public ActionResult RegistroSolicitudRepartidor(string codigo_plataforma, string msj)
        {
            var valid_codigo = db.C_Delivery_Plataformas.Where(x => x.codigo_plataforma == codigo_plataforma).ToList();
            if (valid_codigo.Count() == 0)
            {
                ViewBag.msj = "CODIGO INEXISTENTE";
                return View("../Public_page/MODULOS/_ErrorModule");
            }
            ViewBag.Codigo_plataforma = codigo_plataforma;
            if (msj != null || msj != "") { ViewBag.msj = msj; }
            return View("../Public_Page/Registro/RegistroSolicitudRepartidor");
        }
        public ActionResult AdministradorSolicitudes(string msj)
        {
            ViewBag.msj = msj;
            return View("../Admin_Page/Solicitudes/Admin_Solicitudes");
        }
        //-------------------------------------------------------------------------


        //-------------------------------------------------------------------------
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegistrarSolicitudRepartidor()
        {
            var codigo_plataforma_catch = Request.Params["codigo_plat"];
            try
            {
                //------VALIDO EL CODIGO DE LA PLATAFORMA
                var codigo_plataforma = Request.Params["codigo_plat"];
                var valid_codigo = db.C_Delivery_Plataformas.Where(x => x.codigo_plataforma == codigo_plataforma).ToList();
                if (valid_codigo.Count() == 0)
                {
                    ViewBag.msj = "Codigo invalido. Revise bien el campo requerido";
                    return RedirectToAction("RegistroSolicitudRepartidor","solicitudes", new { msj = "Codigo invalido. Revise bien el campo requerido" });
                }
                //----------VALIDO EL CORREO QUE NO EXISTA
                var email = Request.Params["Correo"];
                var valid_correo = db.C_Delivery_Repartidores.Where(x => x.email == email.ToString()).FirstOrDefault();
                if (valid_correo != null)
                {
                    ViewBag.msj = "Ya existe un correo, por favor ingrese otro.";
                    return RedirectToAction("RegistroSolicitudRepartidor", "solicitudes", new { codigo_plataforma = codigo_plataforma, msj = "Ya existe un correo, por favor ingrese otro." });
                }

                //VALIDO EL REGISTRO DE SOLICITUDES
                var tipo_vehiculo = Request.Params["TipoVehiculo"];
                var no_placas = Request.Params["no_placas"];
                var no_licencia = Request.Params["no_licencia"];
                try
                {
                    if (Convert.ToInt32(tipo_vehiculo) != 2 && (no_placas == "" || no_licencia == "" )) //NO ES BICICLETA  (MOTO/CARRO)
                    {
                        ViewBag.msj = "Asegurese de ingresar los campos de Licencia y No. de placas";
                        return RedirectToAction("RegistroSolicitudRepartidor", "solicitudes", new { codigo_plataforma = codigo_plataforma, msj = "Asegurese de ingresar los campos de Licencia y No. de placas" });
                    }
                    else if(Convert.ToInt32(tipo_vehiculo) == 2 && (no_placas != "" || no_licencia != ""))  //BICICLETA
                    {
                        ViewBag.msj = "No se permiten los datos de placas y licencia a las Bicicletas";
                        return RedirectToAction("RegistroSolicitudRepartidor", "solicitudes", new { codigo_plataforma = codigo_plataforma, msj = "No se permiten los datos de placas y licencia a las Bicicletas" });
                        }
                }
                catch (Exception ex){string msj2 = ex.ToString();   }

                //VALIDO QUE SEA MAYOR DE 18 AÑOS
                var fecha_na = Request.Params["fecha_nat"];
                DateTime fechaNacimiento = Convert.ToDateTime(fecha_na).AddYears(18);
                DateTime hoy = DateTime.Today;
                if (fechaNacimiento > hoy)
                {
                    ViewBag.msj = "Edad no autorizada";
                    return RedirectToAction("RegistroSolicitudRepartidor", "solicitudes", new { codigo_plataforma = codigo_plataforma, msj = "Edad no autorizada" });
                }

                string token_rand = "";
                Random ran = new Random();
                string b = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
                int length = 19;
                int count = 0;
                for (int i = 0; i < length; i++)
                {
                    if ((count / 4) == 1) {
                        token_rand = token_rand + "-";
                        count = 0;
                    }
                    else
                    {
                        int a = ran.Next(36);
                        token_rand = token_rand + b.ElementAt(a);
                        count++;
                    }
                }

                var token = token_rand; //Request.Params["__RequestVerificationToken"];
                var nombre = Request.Params["nombres"];
                var apellido_p = Request.Params["Apellido_pa"];
                var apellido_m = Request.Params["Apellido_ma"];
                var sexo = Request.Params["genero"];
               
                var telefono = Request.Params["Telefono"];
                var direccion = Request.Params["Direccion"];
                var estado = Request.Params["Estado"];
                var ciudad = Request.Params["Ciudad"];

                Random rand = new Random();

                string path_foto = "";
                string path_ine = "";
                string path_licencia = "";
                string path_tarjeta = "";


                if (Request.Files.Count > 0)
                {
                    try
                    {
                        HttpFileCollectionBase files = Request.Files;
                        for (int i = 0; i < files.Count; i++)
                        {
                            HttpPostedFileBase file = files[i];
                            string fname;
                            int RandomNumber = rand.Next(1, 500);
                            var InputFileName = "";

                            if (i == 0)
                            {
                                InputFileName = RandomNumber + "_Fotografia_" + nombre + "_" + apellido_p + Path.GetFileName(file.FileName);
                            }
                            if (i == 1)
                            {
                                InputFileName = RandomNumber + "_INE_" + nombre + "_" + apellido_p + Path.GetFileName(file.FileName);
                            }
                            if (i == 2)
                            {
                                InputFileName = RandomNumber + "_Licencia_" + nombre + "_" + apellido_p + Path.GetFileName(file.FileName);
                            }
                            if (i == 3)
                            {
                                InputFileName = RandomNumber + "_Tarjeta_" + nombre + "_" + apellido_p + Path.GetFileName(file.FileName);
                            }

                            string path_db = "/Content/ImgSolicitudes/" + InputFileName;

                            if (i == 0)
                            {
                                path_foto = path_db;
                            }
                            if (i == 1)
                            {
                                path_ine = path_db;
                            }
                            if (i == 2)
                            {
                                path_licencia = path_db;
                            }
                            if (i == 3)
                            {
                                path_tarjeta = path_db;
                            }

                            // Checking for Internet Explorer  
                            if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                            {
                                string[] testfiles = file.FileName.Split(new char[] { '\\' });
                                fname = testfiles[testfiles.Length - 1];
                            }
                            else
                            {
                                fname = file.FileName;
                            }
                            var ServerSavePath = Path.Combine(Server.MapPath("~/Content/ImgSolicitudes/") + InputFileName);
                            file.SaveAs(ServerSavePath);
                        }
                    }
                    catch (Exception ex)
                    {
                        return RedirectToAction("RegistroSolicitudRepartidor", "solicitudes", new { codigo_plataforma = codigo_plataforma, msj = "Ah ocurrido un error al procesar las imagenes" });
                    }
                }



                //foreach (string str in Request.Files)
                //{
                //    try
                //    {
                //        HttpPostedFileBase file = Request.Files[cont];
                //        cont++;
                //        //Checking file is available to save.
                //        if (file.ContentLength > 0 && file.FileName != "")
                //        {
                //            string nombreArchivo = Path.GetFileName(file.FileName); //OBTENER NOMBRE DE LA IMAGEN
                //            string[] div = nombreArchivo.Split('.');
                //            string ext = "." + div[div.Length - 1];

                //            var InputFileName = nombre + "_" + apellido_p + ext;
                //            path_foto = "/Content/ImgSolicitudes/" + InputFileName;  //(PATH EN SU PROYECTO)
                //            try
                //            {
                //                var ServerSavePath = Path.Combine(Server.MapPath("~/Content/ImgSolicitudes/") + InputFileName);
                //                file.SaveAs(ServerSavePath);
                //            }
                //            catch (Exception ex)
                //            {
                //                String mensaje = ex.ToString();
                //            }
                //        }
                //    }
                //    catch (Exception ex)
                //    {
                //        ViewBag.msj = "Ah ocurrido un error al procesar la solicitud";
                //        //return View("../Public_Page/Registro/RegistroSolicitudRepartidor");
                //        return RedirectToAction("RegistroSolicitudRepartidor", "solicitudes", new { codigo_plataforma = codigo_plataforma, msj = "Ah ocurrido un error al procesar las imagenes" });
                //    }
                //}

                C_Delivery_Repartidores_Solicitud solicitud = new C_Delivery_Repartidores_Solicitud();
                solicitud.token = token;
                solicitud.nombre = nombre;
                solicitud.apellido_pat = apellido_p;
                solicitud.apellido_mat = apellido_m;
                solicitud.sexo = sexo;
                try
                {
                    solicitud.fecha_na = DateTime.ParseExact(fecha_na, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                }
                catch (Exception)
                {
                    try
                    {
                        solicitud.fecha_na = DateTime.ParseExact(fecha_na, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    }
                    catch (Exception)
                    {
                        try
                        {
                            solicitud.fecha_na = Convert.ToDateTime(fecha_na);
                        }
                        catch (Exception)
                        {
                            
                        }
                    }
                }

                solicitud.id_plataforma = valid_codigo.FirstOrDefault().id_plataforma;
                solicitud.fecha_registro = DateTime.Now;
                solicitud.email = email;
                solicitud.direccion = direccion;
                solicitud.telefono = telefono;
                solicitud.id_estado = Convert.ToInt32(estado);
                solicitud.id_ciudad = Convert.ToInt32(ciudad);
                solicitud.id_vehiculo = Convert.ToInt32(tipo_vehiculo);
                solicitud.no_placa = no_placas;
                solicitud.no_licencia = no_licencia;
                solicitud.id_status_solicitud = 1;
                solicitud.activo = true;

                solicitud.foto = path_foto;
                //solicitud.INE = path_ine;
                //solicitud.licencia_conducir = path_licencia;
                //solicitud.tarjeta_circulacion = path_tarjeta;

                db.C_Delivery_Repartidores_Solicitud.Add(solicitud);
                db.SaveChanges();

                string body = @"<h2 style='text-align:left;'>"+ nombre + " " + apellido_p + "</h2>" +
                    "<h3>Tu solicitud de SOCIO REPARTIDOR ha sido recibida con éxito! </h3>" +
                    
                    "<h4 style='text-align:left'>El equipo ZPIDI, esta revisando tu solicitud, en breve te daremos respuesta por este mismo medio.<h4><br />" +
                    "<h4>Te invitamos a visitar ZPIDI.com para mayor información acerca de los requisitos como SOCIO REPARTIDOR</h4><br />"+

                    "<h4>Agradecemos tu interes de ser parte del equipo ZPIDI.</h4><br />" +
                    "<h4>¡SUERTE!</h4><br />" +

                    "<p style='text-align:center;color:#666;font-size:14px;'>A T E N T A M E N T E</p>" +
                    "<p style='text-align:center;color:#666;font-size:14px;'>RECLUTAMIENTO ZPIDI</p>"+
                    "<p style='text-align:center;color:#666;font-size:14px;'>MEXICO</p>";

                var msj = sendMail(email, "SOLICITUD GENERADA", body);

                ViewBag.msj = "Solicitud enviada correctamente";
                //return View("../Public_Page/Registro/RegistroSolicitudRepartidor");
                return RedirectToAction("RegistroSolicitudRepartidor", "solicitudes", new { codigo_plataforma = codigo_plataforma, msj = "Solicitud enviada correctamente" });
            }
            catch (Exception ex)
            {
                string msj = ex.ToString();
                ViewBag.msj = "Ah ocurrido un error al procesar la solicitud";
                //return View("../Public_Page/Registro/RegistroSolicitudRepartidor");
                return RedirectToAction("RegistroSolicitudRepartidor", "solicitudes", new { codigo_plataforma = codigo_plataforma_catch, msj = "Ah ocurrido un error al procesar la solicitud" });
            }


        }

        public string sendMail(string to, string asunto, string body)
        {
            string msge = "Error al enviar este correo. Por favor verifique los datos o intente más tarde.";
            string from = "servicio-reparto@zpidi.com";
            string displayName = "ZPIDI | DELIVERY";
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(from, displayName);
                mail.To.Add(to);
                mail.Subject = asunto;
                mail.Body = body;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.Normal;

                using (SmtpClient MailClient = new SmtpClient("mail.zpidi.com", 25))
                {
                    MailClient.EnableSsl = true;
                    MailClient.Credentials = new System.Net.NetworkCredential("servicio-reparto@zpidi.com", "zpidi85130886$1");
                    MailClient.EnableSsl = false;
                    MailClient.Send(mail);
                }

                //SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Aquí debes sustituir tu servidor SMTP y el puerto
                //client.Credentials = new NetworkCredential(from, "85130886#1*");
                //client.EnableSsl = true;//En caso de que tu servidor de correo no utilice cifrado SSL,poner en false
                //client.Send(mail); 

                msge = "¡Correo enviado exitosamente! Pronto te contactaremos.";

            }
            catch (Exception ex)
            {
                msge = ex.Message + ". Por favor verifica tu conexión a internet y que tus datos sean correctos e intenta nuevamente.";
            }

            return msge;
        }


        public PartialViewResult ConsultarSolicitudes(int tipo, int[] status)
        {
            if (tipo == 1) //SOLICITUDES
            {
                int len = status.Length;
                //if ( status.Contains(1)) { status[status.Length+1] = 4; } //LEIDAS
                var solicitudes = db.C_Delivery_Repartidores_Solicitud.Where(x => status.Contains((int)x.id_status_solicitud) ).ToList();
                return PartialView("../Admin_Page/SOLICITUDES/_SolicitudesTable", solicitudes);
            }
            else  //REPARTIDORES
            {
                //var repas = db.C_Delivery_Repartidores.Where(x => status.Contains((int)x.status) ).ToList();

                var repas = from repa in db.C_Delivery_Repartidores
                            join repa_sol in db.C_Delivery_Repartidores_Solicitudes
                            on repa.id_repartidor equals repa_sol.id_repartidor
                            join soli in db.C_Delivery_Repartidores_Solicitud
                            on repa_sol.id_solicitud equals soli.id_solicitud_repartidor
                            where status.Contains((int)repa.status)
                            select repa;
                return PartialView("../Admin_Page/SOLICITUDES/_RepartidoresTable", repas);
            }

        }

        public PartialViewResult VerSolicitudDetalle(int id_solicitud)
        {
            var solicitud = db.C_Delivery_Repartidores_Solicitud.Where(x => x.id_solicitud_repartidor == id_solicitud).ToList();
            if (solicitud.Count() == 0)
            {
                return null;
            }
            else
            {
                if (solicitud.FirstOrDefault().id_status_solicitud == 2) { return null; }

                if (solicitud.FirstOrDefault().id_status_solicitud == 1 || solicitud.FirstOrDefault().id_status_solicitud == 3) //PENDIENTE
                {
                    return PartialView("../Admin_Page/SOLICITUDES/_Solicitud_Detalle", solicitud);
                }

                if (solicitud.FirstOrDefault().id_status_solicitud == 4) //LEIDA
                {
                    return PartialView("../Admin_Page/SOLICITUDES/_Solicitud_DetalleLeida", solicitud);
                }
                

                else { return null; }
            }



            
        }

        public int CambiarStatusSolicitud(int id_solicitud, int status)
        {
            try
            {
                var solicitud = db.C_Delivery_Repartidores_Solicitud.Find(id_solicitud);
                if (solicitud == null) { return 0; }  //NO EXISTE LA SOLICITUD CONSULTADA
                solicitud.id_status_solicitud = status;
                db.SaveChanges();

                if (status == 3) {      //SOLICITUD RECHAZADA
                    string email = db.C_Delivery_Repartidores_Solicitud.Find(id_solicitud).email;

                    string body = @"<h2 style='text-align:left;'>"+ solicitud.nombre + " " + solicitud.apellido_pat +"</h2>" +
                       "<h4>Lamentamos informarte que tu solicitud no tuvo exito, es probable que tu papeleria no este completa o no alcanzaste los puntos necesarios para cubrir el 100 % de los requisitos.</h4>" +
                       "<h4>Te invitamos a visitar ZPIDI.com y revisar los Requisitos como SOCIO REPARTIDOR, si consideras que hubo alguna omisión, te invitamos a intentarlo nuevamente.</h4>"+
                       "<h4>¡SUERTE!</h4><br />"+

                       "<p style='text-align:center;color:#666;font-size:14px;'>A T E N T A M E N T E</p>" +
                       "<p style='text-align:center;color:#666;font-size:14px;'>RECLUTAMIENTO ZPIDI</p>" +
                       "<p style='text-align:center;color:#666;font-size:14px;'>MEXICO</p>";

                    var msj = sendMail(email, "SOLICITUD DENEGADA", body);
                }

                return id_solicitud;
            }
            catch (Exception ex)
            {
                string msj = ex.ToString();
                return -1;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AfiliarRepartidor()
        {
            var characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            Random rand = new Random();
            string cve_repa = characters[rand.Next(characters.Length)] + rand.Next(999).ToString();
            var validCve = db.C_Delivery_Repartidores.Where(x => x.cve_repartidor == cve_repa).FirstOrDefault();
            if (validCve != null)
            {
                while (db.C_Delivery_Repartidores.Where(x => x.cve_repartidor == cve_repa).FirstOrDefault() != null)
                {
                    cve_repa = characters[rand.Next(characters.Length)] + rand.Next(999).ToString();
                }
            }

            string token_rand = "";
            Random ran = new Random();
            string b = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            int length = 19;
            int count = 0;
            for (int i = 0; i < length; i++)
            {
                if ((count / 4) == 1)
                {
                    token_rand = token_rand + "-";
                    count = 0;
                }
                else
                {
                    int a = ran.Next(36);
                    token_rand = token_rand + b.ElementAt(a);
                    count++;
                }
            }

            var id_solicitud = Request.Params["id_solicitud"];
            //var token = Request.Params["__RequestVerificationToken"];
            var nombre = Request.Params["nombres"];
            var apellido_p = Request.Params["Apellido_pa"];
            var apellido_m = Request.Params["Apellido_ma"];
            var fecha_na = Request.Params["fecha_nat"];
            var email = Request.Params["Correo"];
            var password = Request.Params["Password"];
            var no_cuenta = Request.Params["no_cuenta"];
            var direccion = Request.Params["Direccion"];
            var telefono = Request.Params["telefono"];
            var tipo_vehiculo = Request.Params["TipoVehiculo"];
            var no_placas = Request.Params["no_placas"];
            var no_licencia = Request.Params["no_licencia"];
            string path_foto = "";

            int id_usuario_imagen = 0;
            int cont = 0;
            foreach (string str in Request.Files)
            {
                try
                {
                    HttpPostedFileBase file = Request.Files[cont];
                    cont++;
                    //Checking file is available to save.
                    if (file.ContentLength > 0 && file.FileName != "")
                    {
                        string nombreArchivo = Path.GetFileName(file.FileName); //OBTENER NOMBRE DE LA IMAGEN
                        string[] div = nombreArchivo.Split('.');
                        string ext = "." + div[div.Length - 1];

                        var InputFileName = "REPA_" + nombre + "_" + apellido_p + ext;
                        path_foto = "/Content/ImgSolicitudes/" + InputFileName;  //(PATH EN SU PROYECTO)
                        try
                        {
                            var ServerSavePath = Path.Combine(Server.MapPath("~/Content/ImgSolicitudes/") + InputFileName);
                            file.SaveAs(ServerSavePath);
                            //GUARDO EN C_Delivery_Usuarios_Imagen y recato su ID
                            C_Delivery_Usuarios_Imagen usuarioImagen = new C_Delivery_Usuarios_Imagen();
                            usuarioImagen.imagen = path_foto;
                            db.C_Delivery_Usuarios_Imagen.Add(usuarioImagen);
                            db.SaveChanges();
                            id_usuario_imagen = usuarioImagen.id_usuario_imagen;
                        }
                        catch (Exception ex)
                        {
                            ViewBag.msj = "Ah ocurrido un error al procesar la solicitud";
                            return View("../Public_Page/Registro/RegistroSolicitudRepartidor");
                        }
                    }
                    else
                    {
                        var solicitud = db.C_Delivery_Repartidores_Solicitud.Find(Convert.ToInt32(id_solicitud));
                        if (solicitud != null)
                        {
                            C_Delivery_Usuarios_Imagen usuarioImagen = new C_Delivery_Usuarios_Imagen();
                            usuarioImagen.imagen = solicitud.foto;
                            db.C_Delivery_Usuarios_Imagen.Add(usuarioImagen);
                            db.SaveChanges();
                            id_usuario_imagen = usuarioImagen.id_usuario_imagen;
                        }
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.msj = "Ah ocurrido un error al procesar la solicitud";
                    return View("../Admin_Page/Solicitudes/Admin_Solicitudes");
                }
            }
            
            C_Delivery_Repartidores repa = new C_Delivery_Repartidores();
            repa.nombre = nombre;
            repa.apellido = apellido_p + " " + apellido_m;
            repa.fecha_registro = DateTime.Now;
            repa.no_licencia = no_licencia;
            repa.id_zona = 1;
            repa.status = 4;
            repa.cve_repartidor = cve_repa;
            repa.token = token_rand;
            repa.id_perfil = 2;
            repa.password = password;
            repa.logeado = false;
            repa.telefono = telefono;
            repa.email = email;
            if (id_usuario_imagen > 0) { repa.id_usuario_imagen = id_usuario_imagen; }

            db.C_Delivery_Repartidores.Add(repa);
            db.SaveChanges();

            try
            {
                C_Delivery_Repartidores_Solicitudes repaSol = new C_Delivery_Repartidores_Solicitudes();
                repaSol.id_repartidor = repa.id_repartidor;
                repaSol.id_solicitud = Convert.ToInt32(id_solicitud);
                repaSol.activo = true;
                db.C_Delivery_Repartidores_Solicitudes.Add(repaSol);
                db.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }

            string body = @"<h2>"+ nombre + " " + apellido_p + ",</h2"+
                    "<h4 style='text-align:left';>Felicidades ! Tu solicitud ha sido ACEPTADA</h4>" +
                    "<h4>BIENVENIDO a la familia ZPIDI!</h4></ br>" +
                    "<h4>A continuación te proporcionamos tus accesos a la plataforma:</h4>" +
                    "<h4 style='font-weight: 800;'>Usuario: " + email + "</h4>" +
                    "<h4 style='font-weight: 800;'>Contraseña: " + password + "</h4>" +
                    "<h4 style='font-weight: 800;'>Clave para asignacion de pedidos: " + cve_repa + "</h4>" +

                    "<h4 style='text-align:center'>Te invitamos a ingresar a APP ZPIDI y podrás consultar la sección de TERMINOS y CONDICIONES de reparto.</h4>" +
                    "<h4>GRACIAS POR SER PARTE DEL EQUIPO ZPIDI</h4><br />"+
                    "<p style='text-align:center;color:#666;font-size:12px;'>A T E N T A M E N T E</p>" +
                    "<p style='text-align:center;color:#666;font-size:12px;'>RECLUTAMIENTO ZPIDI</p>"+
                    "<p style='text-align:center;color:#666;font-size:12px;'>MEXICO</p>";
            var msj = sendMail(email, "Bienvenido a la familia ZPIDI", body);

            CambiarStatusSolicitud(Convert.ToInt32(id_solicitud), 2);

            ViewBag.msj = "Repartidor registrado correctamente";
            return RedirectToAction("AdministradorSolicitudes", "SOLICITUDES", new { msj = "Repartidor registrado correctamente" });
        }

        




    }
}