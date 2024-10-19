using System;
using System.Collections.Generic;
using System.Linq;

public class Empleado
{
    public string Cedula;
    public string Nombre;
    public string Direccion;
    public string Telefono;
    public decimal Salario;

    public Empleado(string cedula, string nombre, string direccion, string telefono, decimal salario)
    {
        Cedula = cedula;
        Nombre = nombre;
        Direccion = direccion;
        Telefono = telefono;
        Salario = salario;
    }
}
public class Menu
{
    private List<Empleado> empleados = new List<Empleado>();

    public void MostrarMenu()
    {
        int opcion;
        do
        {
            Console.WriteLine("Menú Principal:");
            Console.WriteLine("1. Agregar Empleados");
            Console.WriteLine("2. Consultar Empleados");
            Console.WriteLine("3. Modificar Empleados");
            Console.WriteLine("4. Borrar Empleados");
            Console.WriteLine("5. Inicializar Arreglos");
            Console.WriteLine("6. Reportes");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");
            opcion = Convert.ToInt32(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    AgregarEmpleado();
                    break;
                case 2:
                    ConsultarEmpleados();
                    break;
                case 3:
                    ModificarEmpleado();
                    break;
                case 4:
                    BorrarEmpleado();
                    break;
                case 5:
                    InicializarArreglos();
                    break;
                case 6:
                    MostrarReportes();
                    break;
                case 0:
                    Console.WriteLine("Saliendo...");
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        } while (opcion != 0);
    }

    private void AgregarEmpleado()
    {
        Console.Write("Cédula: ");
        string cedula = Console.ReadLine();
        Console.Write("Nombre: ");
        string nombre = Console.ReadLine();
        Console.Write("Dirección: ");
        string direccion = Console.ReadLine();
        Console.Write("Teléfono: ");
        string telefono = Console.ReadLine();
        Console.Write("Salario: ");
        decimal salario = Convert.ToDecimal(Console.ReadLine());

        empleados.Add(new Empleado(cedula, nombre, direccion, telefono, salario));
        Console.WriteLine("Empleado agregado.");
    }

    private void ConsultarEmpleados()
    {
        if (empleados.Count == 0)
        {
            Console.WriteLine("No hay empleados registrados.");
            return;
        }

        foreach (var empleado in empleados)
        {
            Console.WriteLine($"Cédula: {empleado.Cedula}, Nombre: {empleado.Nombre}, Dirección: {empleado.Direccion}, Teléfono: {empleado.Telefono}, Salario: {empleado.Salario}");
        }
    }

    private void ModificarEmpleado()
    {
        Console.Write("Ingrese la cédula del empleado a modificar: ");
        string cedula = Console.ReadLine();
        var empleado = empleados.FirstOrDefault(e => e.Cedula == cedula);

        if (empleado == null)
        {
            Console.WriteLine("Empleado no encontrado.");
            return;
        }

        Console.Write("Nuevo Nombre: ");
        empleado.Nombre = Console.ReadLine();
        Console.Write("Nueva Dirección: ");
        empleado.Direccion = Console.ReadLine();
        Console.Write("Nuevo Teléfono: ");
        empleado.Telefono = Console.ReadLine();
        Console.Write("Nuevo Salario: ");
        empleado.Salario = Convert.ToDecimal(Console.ReadLine());

        Console.WriteLine("Empleado modificado.");
    }

    private void BorrarEmpleado()
    {
        Console.Write("Ingrese la cédula del empleado a borrar: ");
        string cedula = Console.ReadLine();
        var empleado = empleados.FirstOrDefault(e => e.Cedula == cedula);

        if (empleado != null)
        {
            empleados.Remove(empleado);
            Console.WriteLine("Empleado borrado.");
        }
        else
        {
            Console.WriteLine("Empleado no encontrado.");
        }
    }

    private void InicializarArreglos()
    {
        empleados.Clear();
        Console.WriteLine("Empleados inicializados.");
    }

    private void MostrarReportes()
    {
        int opcion;
        do
        {
            Console.WriteLine("Reportes:");
            Console.WriteLine("1. Listar empleados ordenados por nombre");
            Console.WriteLine("2. Promedio de salarios");
            Console.WriteLine("0. Volver al menú principal");
            Console.Write("Seleccione una opción: ");
            opcion = Convert.ToInt32(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    ListarEmpleadosOrdenados();
                    break;
                case 2:
                    CalcularPromedioSalarios();
                    break;
                case 0:
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        } while (opcion != 0);
    }

    private void ListarEmpleadosOrdenados()
    {
        var empleadosOrdenados = empleados.OrderBy(e => e.Nombre).ToList();
        foreach (var empleado in empleadosOrdenados)
        {
            Console.WriteLine($"Cédula: {empleado.Cedula}, Nombre: {empleado.Nombre}");
        }
    }

    private void CalcularPromedioSalarios()
    {
        if (empleados.Count == 0)
        {
            Console.WriteLine("No hay empleados registrados.");
            return;
        }

        decimal promedio = empleados.Average(e => e.Salario);
        Console.WriteLine($"El salario promedio es: {promedio}");
    }
}
class Program
{
    static void Main(string[] args)
    {
        Menu menu = new Menu();
        menu.MostrarMenu();
    }
}