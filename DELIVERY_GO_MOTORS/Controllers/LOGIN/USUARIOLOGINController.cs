using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using ZPIDI_PORTAL.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using ZPIDI_PORTAL.Models.DataBase;
using System.Configuration;

namespace ZPIDI_PORTAL.Controllers.LOGIN
{
    public class USUARIOLOGINController : Controller
    {
        private db_a872a9_gomotorsEntities db = new db_a872a9_gomotorsEntities();
        List<PermisosUsuario> permisos;
        List<SubmodulosUsuario> submodulos;
        List<ModulosUsuario> modulos;

        public ActionResult Login(string msj)
        {
            ViewBag.msj = msj;
            return View("../Admin_page/Login/Login");
        }
        
        [HttpPost]
        public ActionResult UsuarioLoginAsync()
        {
            try
            {
                string url = Request.Params["module"];
                string usuario = Request.Params["user"];
                string pass = Request.Params["pwd"];
                string PathAPI = ConfigurationManager.AppSettings["PathAPI"];
                var endpoint = PathAPI+"api/[Delivery_01_Login_ClientController]/Find";
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("user",  Request.Params["user"]),
                    new KeyValuePair<string, string>("pwd",  Request.Params["pwd"])
                });

                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    httpClient.DefaultRequestHeaders.Add("Host", "gomosystem-001-site2.etempurl.com");

                    var response = httpClient.PostAsync(endpoint, content).Result;
                    var json = response.Content.ReadAsStringAsync().Result;
                    var ResponseJson = JsonConvert.DeserializeObject<Login_Client>(json);

                    if (ResponseJson.Activo == "0"){
                        return RedirectToAction("Login","USUARIOLOGIN", new { msj = "Usuario o contraseña incorrectos" });
                    }

                    var UserData = ResponseJson.data.First().ToString();
                    var ResponseUser = JsonConvert.DeserializeObject<DataUser>(UserData);

                    //VARIABLES DE SESION-----------------------------------
                    SetVariablesSession(ResponseUser);
                    //-------------------------------------------------------
                    //MODULOS ASIGNADOS---------------------------------------------------------------------------------------------------------------
                    int id_perfil = ResponseUser.id_perfil;
                    List<int> permisosLista = new List<int>();
                    var permisosServicioModulo = from p in db.C_Delivery_Menuappbar_SubModules_Permisos
                                                 where p.id_rol == id_perfil && p.activo == true
                                                 select p;

                    if (permisosServicioModulo.Count() > 0)
                    {
                        permisos = new List<PermisosUsuario>();
                        submodulos = new List<SubmodulosUsuario>();
                        modulos = new List<ModulosUsuario>();

                        foreach (var n in permisosServicioModulo)
                        {
                            try
                            {
                                permisosLista.Add((int)n.id_modulo_sub);
                                permisosLista.Add((int)n.C_Delivery_Menuappbar_SubModules.id_modulo);
                                //permisosLista.Add((int)n.id_permiso);
                                permisos.Add(new PermisosUsuario(
                                    (int)n.C_Delivery_Menuappbar_SubModules.id_modulo, n.C_Delivery_Menuappbar_SubModules.C_Delivery_Menuappbar_ModulesWeb.nombre, 
                                    (int)n.id_modulo_sub 
                                    /*(int)n.id_permiso*/));
                            }
                            catch (Exception)
                            {

                            }
                        }

                        foreach (var item in permisosServicioModulo.Select(m => new { m.C_Delivery_Menuappbar_SubModules.id_modulo,
                            m.id_modulo_sub, m.C_Delivery_Menuappbar_SubModules.nombre,
                            m.C_Delivery_Menuappbar_SubModules.metodo,
                            m.C_Delivery_Menuappbar_SubModules.controlador }).Distinct())
                        {
                            try
                            {
                                submodulos.Add(new SubmodulosUsuario((int)item.id_modulo, 
                                    (int)item.id_modulo_sub, 
                                    item.nombre, item.metodo, 
                                    item.controlador));
                            }
                            catch (Exception) { }
                        }

                        foreach (var item in permisosServicioModulo.Select(m => new { m.C_Delivery_Menuappbar_SubModules.id_modulo,
                            m.C_Delivery_Menuappbar_SubModules.C_Delivery_Menuappbar_ModulesWeb.nombre,
                            m.C_Delivery_Menuappbar_SubModules.C_Delivery_Menuappbar_ModulesWeb.icono,
                            m.C_Delivery_Menuappbar_SubModules.C_Delivery_Menuappbar_ModulesWeb.color}).Distinct())
                        {
                            try
                            {
                                modulos.Add(new ModulosUsuario((int)item.id_modulo, item.nombre, item.icono, item.color));
                            }
                            catch (Exception) { }
                        }
                    }

                    Session["modulos"] = modulos.OrderBy(x => x.Nombre_modulo).ToList();
                    Session["submodulos"] = submodulos.OrderBy(x => x.Nombre_submodulo).ToList();
                    //-------------------------------------------------------------------------------------------------------------------------------

                    if (id_perfil == 2)
                    {
                        return RedirectToAction("MonitorRepartidores", "MONITOR");
                    }
                    if (id_perfil == 1)  //ADMIN
                    {
                        return RedirectToAction("MonitorRepartidores", "MONITOR");
                    }

                    return RedirectToAction("AdministradorSolicitudes","SOLICITUDES");
                }
            }
            catch (Exception ex)
            {
               ViewBag.Msj = ex.InnerException.ToString();
                return View("../Admin_Page/ErrrorViewAdmin");
            }

        }
        
        public bool SetVariablesSession(DataUser usuario)
        {
            try
            {
                int id_usuario = (int)db.C_Delivery_a_new_register.Where(x => x.token == usuario.tokken).FirstOrDefault().id;
                Session["ses_id_usuario"] = id_usuario;
                Session["ses_id_perfil"] = usuario.id_perfil;
                Session["ses_nombre"] = usuario.nombre;
                Session["ses_apellido"] = usuario.apellido;
                Session["ses_token"] = usuario.tokken;

                Session["icono_mapa_rojo"] = db.C_Delivery_Parametros.Find(1004).valor_texto;
                Session["icono_mapa_amarillo"] = db.C_Delivery_Parametros.Find(1005).valor_texto;
                Session["icono_mapa_verde"] = db.C_Delivery_Parametros.Find(1006).valor_texto;

                Session["api_key"] = db.C_Delivery_Parametros.Find(1007).valor_texto;
                var suc_usuario = db.C_Delivery_Usuarios_Sucursales.Where(x => x.id_usuario == id_usuario).FirstOrDefault();
                Session["ses_codigo_sucursal"] = suc_usuario.codigo_sucursal;
                Session["ses_nombre_sucursal"] = suc_usuario.C_Delivery_sucursales_gps.nombre_suc;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public PartialViewResult GetModules(int id_rol)
        {
            var modulos = from m in db.C_Delivery_Menuappbar_SubModules_Permisos
                          where m.id_rol == id_rol && m.activo == true
                          select m;
            return PartialView("../Admin_page/_ModulosMenu", modulos);
        }

        public ActionResult Home()
        {
            try
            {
                if ( Session["ses_nombre"] != null)
                {
                    ViewBag.Title = "ZPIDI | HOME";
                    return View("../Admin_Page/Home/Index");
                }
                else
                {
                    return RedirectToAction("Login", "USUARIOLOGIN", new { msj = "Se detectó una sesión vacía. Ingrese de nuevo porfavor." });
                }
            }
            catch (Exception)
            {
                return RedirectToAction("Login", "USUARIOLOGIN", new { msj = "Se detectó una sesión vacía. Ingrese de nuevo porfavor." });
            }
        }

        public ActionResult CerrarSesion()
        {
            try
            {
                Session.Contents.RemoveAll();
                return RedirectToAction("Login","USUARIOLOGIN"); 
            }
            catch
            {
                return RedirectToAction("Login", "USUARIOLOGIN");
            }
            
        }

        public int ValidaSesion()
        {
            if (Session["ses_id_perfil"] != null)
            {
                return 1;
            }
            return 0;
        }

    }
}