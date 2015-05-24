using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Servicios;

namespace Terminal
{
  class Program
  {
    static void Main(string[] args)
    {
      string usr, pass;

      Console.WriteLine("Ingrese usuario y password");
      
      Console.Write("User -->  ");
      usr = Console.ReadLine();

      Console.Write("Password -->  ");
      Console.ForegroundColor = ConsoleColor.Black;
      pass = Console.ReadLine();
      Console.ResetColor();

      SecurityServices security = new SecurityServices();

      Sesion ses = security.Login(usr, pass);

      if (ses == null)
        Console.WriteLine("ERROR!! Verificar credenciales");
      else
      {
        Console.WriteLine("Bienvenido {0}. Su password expira el {1}", ses.FullName, ses.FechaExpiracion );
      }

      Console.WriteLine("Press any key");
      Console.ReadLine();
    }
  }
}
