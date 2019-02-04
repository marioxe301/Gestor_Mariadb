using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_TB2
{
    
    class Fun_Proyecto
    {
        string Usuario;
        string Contraseña;
        string Esquema;
        string NConeccion;

        Fun_Proyecto(string u,string c,string e,string Nc)
        {
            this.Usuario = u;
            this.Contraseña = c;
            this.Esquema = e;
            this.NConeccion = Nc;
        }

        Fun_Proyecto(string u, string c)
        {
            this.Usuario = u;
            this.Contraseña = c;
        }

        Fun_Proyecto() { }






    }
}
