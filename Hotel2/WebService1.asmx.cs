using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Hotel2
{
    /// <summary>
    /// Descripción breve de WebService1
    /// </summary>
    [WebService(Namespace = "http://Hoteles.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola, Bienvenido a los Hoteles";
        }

        [WebMethod]
        public string Hotel(string nombreHot, string dir)
        {
            return "El nombre del Hotel es: " + nombreHot + "y la dirección es: " + dir;
        }

        [WebMethod]
        public List<String> Hoteles()
        {
            List<string> lista = new List<string>();
            using (var c = new HotelEntities())
            {
                var li = from l in c.Hoteles
                         select l;

                foreach (var i in li)
                {
                    lista.Add(i.nombre_hotel);
                }

            }

            return lista;
        }
    }
}
