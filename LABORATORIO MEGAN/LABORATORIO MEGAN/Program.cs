using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LABORATORIO_MEGAN
{
    class Program
    {
        static void Main(string[] args)
        {
            inicio ini = new inicio();
            titulo tit = new titulo();

            tit.mecorp();
            ini.usuario();

            Console.ReadKey();
        }
        class titulo
        {
            public void mecorp()
            {
                Console.WriteLine("Tienda Patos");
            }
        }

        class inicio
        {
            public void usuario()
            {
                titulo tit = new titulo();
                administrador admin = new administrador();
                trabajador tra = new trabajador();
                creacion cre = new creacion();
                Console.Clear();
                tit.mecorp();

                StreamReader lectura;
                string user, contraseña, seguir;
                bool resultado;
                resultado = false;
                string[] información = new string[2];
                char[] separador = { '-' };
                int o = 0;
                string adm = "administrador";

                while (o == 0)
                {
                    lectura = File.OpenText("ArUsuarios.txt");

                    Console.WriteLine("Inserte usuario: ");
                    user = (Console.ReadLine());
                    Console.WriteLine("Inserte su contraseña: ");
                    contraseña = (Console.ReadLine());

                    seguir = lectura.ReadLine();

                    while (seguir != null && resultado == false)
                    {
                        información = seguir.Split(separador);

                        if (información[0].Trim().Equals(user) && información[1].Trim().Equals(contraseña))
                        {
                            if (información[2].Trim().Equals(adm))
                            {
                                Console.Clear();
                                tit.mecorp();

                                Console.Write("Acaba de ingresar en la página de: " + información[0].Trim());
                                Console.WriteLine("(administrador)");
                                lectura.Close();
                                admin.admin();
                            }
                            else
                            {
                                Console.Clear();
                                tit.mecorp();

                                Console.Write("Acaba de ingresar en la página de: " + información[0].Trim());
                                Console.WriteLine("(trabajador)");
                                lectura.Close();
                                tra.tra();
                            }
                            o = 1;
                            resultado = true;
                        }
                        else
                        {
                            seguir = lectura.ReadLine();
                        }

                    }
                    if (resultado == false)
                    {
                        Console.Clear();
                        tit.mecorp();
                        Console.WriteLine("No se encuentra el User");
                        o = 0;
                    }
                    lectura.Close();
                }
            }

        }
        class trabajador
        {
            public void tra()
            {
                inicio ini = new inicio();
                titulo tit = new titulo();
                creacioninventario crei = new creacioninventario();
                int per;
                int o = 0;

                while (o == 0)
                {
                    Console.WriteLine("1.Cargar Inventario \n2.Facturar Productos \n3.Cerrar Sesión");
                    per = int.Parse(Console.ReadLine());
                    if (per == 1)
                    {
                        o = 1;
                        crei.inventario();

                    }
                    if (per == 3)
                    {
                        o = 1;
                        ini.usuario();
                    }
                }
            }
        }

        class administrador
        {
            public void admin()
            {

                inicio ini = new inicio();
                titulo tit = new titulo();
                administrador ado = new administrador();
                creacion cre = new creacion();
                creacioninventario crei = new creacioninventario();

                int per;
                int o = 0;

                while (o == 0)
                {
                    Console.WriteLine("1.Crear Usuario   \n2.Ver inventario\n4.Ver Facturas\n5.Cerrar Sesión");
                    per = int.Parse(Console.ReadLine());
                    if (per == 1)
                    {
                        o = 1;
                        cre.agregar();

                    }
                    if (per == 2)
                    {
                        o = 1;

                        Console.Clear();
                        TextReader leer;
                        leer = new StreamReader("ArInventario.txt");
                        Console.WriteLine(leer.ReadToEnd());
                        leer.Close();

                        tit.mecorp();
                        ado.admin();


                    }
                    if (per == 5)
                    {
                        o = 1;
                        ini.usuario();
                    }
                }
            }
        }
        class creacion
        {
            public void agregar()
            {
                titulo tit = new titulo();
                administrador ado = new administrador();
                Console.Clear();
                tit.mecorp();
                Console.WriteLine();
                StreamWriter Escribir = File.AppendText("ArUsuarios.txt");
                string nombre;
                string contraseña;
                string opcion;
                int cargo;
                int o = 0;
                while (o == 0)
                {
                    Console.WriteLine("El usuario será : \n1.Administrador \n2.Trabajador ");
                    cargo = int.Parse(Console.ReadLine());
                    Console.WriteLine();
                    Console.WriteLine("Usuario: ");
                    nombre = Console.ReadLine();

                    Console.WriteLine("Contraseña: ");
                    contraseña = Console.ReadLine();
                    contraseña = ("-" + contraseña);

                    if (cargo == 1)
                    {
                        opcion = "Administrador";
                        opcion = ("-" + opcion);

                        Console.WriteLine();
                        Escribir.WriteLine(nombre + contraseña + opcion);
                        Escribir.Close();
                        o = 1;
                    }
                    if (cargo == 2)
                    {
                        opcion = "Trabajador";
                        opcion = ("-" + opcion);

                        Console.WriteLine();
                        Escribir.WriteLine(nombre + contraseña + opcion);
                        Escribir.Close();
                        o = 1;
                    }
                    Escribir.Close();

                }
                Console.Clear();
                tit.mecorp();

                Console.WriteLine("Ha creado un usuario nuevo");
                ado.admin();
            }
        }
        class creacioninventario
        {
            public void inventario()
            {
                titulo tit = new titulo();
                administrador ado = new administrador();
                trabajador tra = new trabajador();
                creacioninventario crei = new creacioninventario();

                Console.Clear();
                tit.mecorp();
                Console.WriteLine();
                StreamWriter Escribir = File.AppendText("ArInventario.txt");
                string producto;
                string precio;
                string cantidad;

                char menu = 's';

                while (menu != 'n')
                {

                    Console.WriteLine("producto: ");
                    producto = Console.ReadLine();

                    Console.WriteLine("Precio: ");
                    precio = Console.ReadLine();
                    precio = ("-" + precio);

                    Console.WriteLine("cantidad: ");
                    cantidad = Console.ReadLine();
                    cantidad = ("-" + cantidad);
                    Console.WriteLine("¿Desea agregar otro producto?[s/n]");
                    menu = char.Parse(Console.ReadLine());

                    Escribir.WriteLine(producto + precio + cantidad);
                }
                Escribir.Close();
                Console.Clear();
                tit.mecorp();

                tra.tra();


            }
        }


    }

}
      