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
            ini.usuario();

            titulo tit = new titulo();

            
           

            Console.ReadKey();
        }
        class titulo
        {
            public void tit()
            {
                Console.WriteLine("EMPRESA LOS PATOS");
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
                tit.tit();

                StreamReader lectura;
                string user, contraseña, seguir;
                bool resultado;
                resultado = false;
                string[] información = new string[2];
                string traba = "trabajador";
                char[] separador = { ',' };
                int o = 0;
              

                while (o == 0)
                {
                  
                    Console.WriteLine("Inserte usuario: ");
                    user = (Console.ReadLine());
                    Console.WriteLine("Inserte su contraseña: ");
                    contraseña = (Console.ReadLine());
                    lectura = File.OpenText("Usuarios.txt");

                    seguir = lectura.ReadLine();

                    while (seguir != null && resultado == false)
                    {
                        información = seguir.Split(separador);

                        if (información[0].Trim().Equals(user) && información[1].Trim().Equals(contraseña))
                        {
                            if (información[2].Trim().Equals(traba))
                            {

                                Console.Clear();
                                Console.Write("Acaba de ingresar en la página del trabajador");
                                Console.WriteLine();
                                Console.WriteLine("¿Qué desea realizar?  ");
                                Console.WriteLine();
                                lectura.Close();
                                tra.tra();
                            }
                            else
                            {
                                Console.Clear();
                                Console.Write("Acaba de ingresar en la página del administrador" );
                                Console.WriteLine();
                                Console.WriteLine("¿Qué desea realizar?  ");
                                Console.WriteLine();
                                lectura.Close();
                                admin.admin();
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
                        
                        Console.WriteLine("No se encuentra el Usuario");
                        o = 0;
                    }
                    lectura.Close();
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
                Console.WriteLine();
                StreamWriter Escribir = File.AppendText("Usuarios.txt");
                string nombre, contraseña, opcion;

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
                    contraseña = ("---" + contraseña);

                    if (cargo == 1)
                    {
                        opcion = "Administrador";
                        opcion = ("---" + opcion);

                        Console.WriteLine();
                        Escribir.WriteLine(nombre + contraseña + opcion);
                        Escribir.Close();
                        o = 1;
                    }
                    if  (cargo == 2)
                    {
                        opcion = "Trabajador";
                        opcion = ("---" + opcion);

                        Console.WriteLine();
                        Escribir.WriteLine(nombre + contraseña + opcion);
                        Escribir.Close();
                        o = 1;
                    }
                    Escribir.Close();

                }
                Console.Clear();
                Console.WriteLine("Ha creado un usuario nuevo");
                Console.WriteLine();
                Console.WriteLine("¿Qué más desea realizar?");
                ado.admin();
            }
        }
        class trabajador
        {
            public void tra()
            {
                inicio ini = new inicio();
                titulo tit = new titulo();
                
                int per;
                int o = 0;

                while (o == 0)
                {
                    Console.WriteLine("1.Cargar Inventario \n2.Facturar Productos \n3.Cerrar Sesión");
                    per = int.Parse(Console.ReadLine());
                    if (per == 1)
                    {
                        o = 1;
                        administrador ado = new administrador();
                        trabajador tra = new trabajador();

                        Console.Clear();

                        Console.WriteLine();
                        StreamWriter Escribir = File.AppendText("Inventario.txt");
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
                   

                        tra.tra();



                    }
                    if (per == 2)
                    {
                        o = 1;
                        administrador ado = new administrador();
                        trabajador tra = new trabajador();

                        Console.Clear();

                        Console.WriteLine();
                        StreamWriter Escribir = File.AppendText("Factura.txt");
                        string correlativo;
                        string cliente;
                        string nit;
                        string fecha;
                        string detalle;
                        string precio;
                        string total;

                        char menu = 's';

                        while (menu != 'n')
                        {
                            Console.WriteLine("Correlativo: ");
                            correlativo= Console.ReadLine();
                          

                            Console.WriteLine("Nombre del cliente: ");
                            cliente = Console.ReadLine();
                            cliente = ("-" + cliente);

                            Console.WriteLine("Nit: ");
                           nit = Console.ReadLine();
                            nit= ("-" + nit);

                            Console.WriteLine("Fecha: ");
                            fecha = Console.ReadLine();
                            fecha = ("-" + fecha);

                            Console.WriteLine("Detalle de la compra: ");
                            detalle = Console.ReadLine();
                            detalle = ("-" + detalle);

                            Console.WriteLine("Precio: ");
                            precio = Console.ReadLine();
                            precio = ("-" + precio);


                            Console.WriteLine("Monto total a pagar: ");
                            total = Console.ReadLine();
                            total = ("-" + total);


                            Console.WriteLine("¿Desea agregar otro producto?[s/n]");
                            menu = char.Parse(Console.ReadLine());

                            Escribir.WriteLine(correlativo+cliente+nit+fecha+detalle+total);
                        }
                        Escribir.Close();
                        Console.Clear();

                        tra.tra();



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
               
                int per;
                int o = 0;

                while (o == 0)
                {
                    Console.WriteLine("1.Crear Usuario   \n2.Ver inventario\n3.Ver usuarios registrados\n4.Ver facturas\n5.Cerrar sesión");
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
                        leer = new StreamReader("Inventario.txt");
                        Console.WriteLine(leer.ReadToEnd());
                        leer.Close();


                        ado.admin();


                    }
                    if (per == 3)
                    {
                        o = 1;
                        Console.Clear();
                        TextReader leer;
                        leer = new StreamReader("Usuarios.txt");
                        Console.WriteLine(leer.ReadToEnd());
                        leer.Close();

                       
                        ado.admin();


                    }
                    if (per == 4)
                    {
                        o = 1;
                        Console.Clear();
                        TextReader leer;
                        leer = new StreamReader("Factura.txt");
                        Console.WriteLine(leer.ReadToEnd());
                        leer.Close();
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
        
       

    }

}
      