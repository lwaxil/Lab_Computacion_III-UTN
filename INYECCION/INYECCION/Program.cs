using System;
namespace INYECCION
{
    interface IAnimal
    {
        String Nombre { get; set; }
        String Alimento { get; set; }
        String Especie { get; set; }
        void Comer();
        void Presentarse();
    }
    class Mamiferos : IAnimal
    {
        public String Nombre { get; set; }
        public String Alimento { get; set; }
        public String Especie { get; set; }
        public Mamiferos(String nombre, String alimento, String especie)
        {
            Nombre = nombre;
            Alimento = alimento;
            Especie = especie;
        }
        public void Comer()
        {
            Console.WriteLine("El nombre del mamifero es {0} y come {1}", Nombre, Alimento);
        }
        public void Presentarse()
        {
            Console.WriteLine("Es un {0} y puede amamantar", Especie);
        }
    }
    class Aves : IAnimal
    {
        public String Nombre { get; set; }
        public String Alimento { get; set; }
        public String Especie { get; set; }
        public Aves(String nombre, String alimento, String especie)
        {
            Nombre = nombre;
            Alimento = alimento;
            Especie = especie;
        }
        public void Comer()
        {
            Console.WriteLine("El nombre del ave es {0} y come {1}", Nombre, Alimento);
        }
        public void Presentarse()
        {
            Console.WriteLine("Es un {0} y puede volar", Especie);
        }
    }
    class Peces : IAnimal
    {
        public String Nombre { get; set; }
        public String Alimento { get; set; }
        public String Especie { get; set; }
        public Peces(String nombre, String alimento, String especie)
        {
            Nombre = nombre;
            Alimento = alimento;
            Especie = especie;
        }
        public void Comer()
        {
            Console.WriteLine("El nombre del pez es {0} y come {1}", Nombre, Alimento);
        }
        public void Presentarse()
        {
            Console.WriteLine("Es un {0} y puede nadar", Especie);
        }
    }
    class PlantaCarnivora : IAnimal
    {
        public String Nombre { get; set; }
        public String Alimento { get; set; }
        public String Especie { get; set; }
        public PlantaCarnivora(String nombre, String alimento, String especie)
        {
            Nombre = nombre;
            Alimento = alimento;
            Especie = especie;
        }
        public void Comer()
        {
            Console.WriteLine("El nombre de la planta es {0} y come {1}", Nombre, Alimento);
        }
        public void Presentarse()
        {
            Console.WriteLine("Es una {0} y puede comer insectos", Especie);
        }
    }
    class Zoologico
    {
        private List<IAnimal> animales = new List<IAnimal>();
        private List<Cuidadores> cuidadores = new List<Cuidadores>();

        public void AgregarAnimal(IAnimal animal)
        {
            animales.Add(animal);
        }
        //
        public void AgregarCuidador(String nombre, int id)
        {
            Cuidadores cuidador = new Cuidadores(); //creo un objeto
            cuidador.AgregarCuidador(nombre, id); //llamo al metodo "AgregarCuidador" de la clase "Cuidadores"
            cuidadores.Add(cuidador); //agrego el objeto a la lista "Cuidadores"
        }
        public void EditarCuidador(int id, String nombre)
        {
            foreach (Cuidadores cuidador in cuidadores)
            {
                if (cuidador.ID == id)
                {
                    cuidador.Nombre = nombre;
                }
            }
        }
        public List<IAnimal> ObtenerAnimales() //metodo que retorna la lista de animales
        {
            return animales;
        }
        public List<Cuidadores> ObtenerCuidadores() //metodo que retorna la lista de cuidadores
        {
            return cuidadores;
        }
        public void PresentarAnimal(IAnimal animal)
        {
            animal.Presentarse();
        }
        public void AlimentarAnimal(IAnimal animal)
        {
            animal.Comer();
        }
        public void MostrarAnimales()
        {
            Console.WriteLine("Animales en el zoologico: ");
            //mostrar solo los animales 
            foreach (IAnimal animal in animales)
            {
                if ((animal is IAnimal) && !(animal is PlantaCarnivora))
                {
                    Console.WriteLine(animal.Nombre);
                }
            }
            Console.WriteLine("Plantas en el zoologico: ");
            //mostrar solo las plantas 
            foreach (IAnimal animal in animales)
            {
                if (animal is PlantaCarnivora)
                {
                    Console.WriteLine(animal.Nombre);
                }
            }
        }
    }
    class Cuidadores
    {
        private IAnimal animal;
        public String Nombre { get; set; }
        public int ID { get; set; }

        public void AgregarCuidador(String nombre, int id) //metodo que agrega un cuidador
        {
            Nombre = nombre;
            ID = id;
        }

        public void AlimentarAnimales(Zoologico zoologico)
        {
            List<IAnimal> animales = zoologico.ObtenerAnimales();
            foreach (IAnimal animal in animales)
            {
                if ((animal is Mamiferos) && (ID == 1))
                {
                    Console.WriteLine("El cuidador {0} está alimentando a {1}", Nombre, animal.Nombre);
                }
                else if ((animal is Aves) && (ID == 2))
                {
                    Console.WriteLine("El cuidador {0} está alimentando a {1}", Nombre, animal.Nombre);
                }
                else if ((animal is Peces) && (ID == 3))
                {
                    Console.WriteLine("El cuidador {0} está alimentando a {1}", Nombre, animal.Nombre);
                }
                else if ((animal is PlantaCarnivora) && (ID == 4))
                {
                    Console.WriteLine("El cuidador {0} está alimentando a {1}", Nombre, animal.Nombre);
                }
            }
        }
    }
    class Program
    {
        static void Main(String[] args)
        {
            Cuidadores oCuidadores = new Cuidadores();
            Zoologico oZoologico = new Zoologico();
            IAnimal oAnimal;

            oZoologico.AgregarCuidador("Juan", 1);
            oZoologico.AgregarCuidador("Maria", 2);
            oZoologico.AgregarCuidador("Pedro", 3);
            oZoologico.AgregarCuidador("Luis", 4);
            oAnimal = new Mamiferos("Byron", "Croquetas", "Perro");
            oZoologico.AgregarAnimal(oAnimal);
            oAnimal = new Mamiferos("Mercy", "Carne", "Gato");
            oZoologico.AgregarAnimal(oAnimal);
            oAnimal = new Aves("Piolin", "Semillas", "Canario");
            oZoologico.AgregarAnimal(oAnimal);
            oAnimal = new PlantaCarnivora("Venus", "Insectos", "Dionaea muscipula");
            oZoologico.AgregarAnimal(oAnimal);

            int opcion = 0;
            while (opcion!=9)
            {
                Console.WriteLine("Ingrese la opcion que desea: ");
                Console.WriteLine("1. Agregar Mamifero");
                Console.WriteLine("2. Agregar Ave");
                Console.WriteLine("3. Agregar Pez");
                Console.WriteLine("4. Agregar Planta Carnivora");
                Console.WriteLine("5. Mostrar Animales");
                Console.WriteLine("6. Editar Cuidador");
                Console.WriteLine("7. Alimentar Animales");
                Console.WriteLine("8. Mostrar Cuidadores");
                Console.WriteLine("9. Salir");
                opcion = Convert.ToInt32(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("Ingrese el nombre del mamifero: ");
                        string nombreMamifero = Console.ReadLine();
                        Console.WriteLine("Ingrese el alimento del mamifero: ");
                        string alimentoMamifero = Console.ReadLine();
                        Console.WriteLine("Ingrese la especie del mamifero: ");
                        string especieMamifero = Console.ReadLine();
                        oAnimal = new Mamiferos(nombreMamifero, alimentoMamifero, especieMamifero);
                        oZoologico.AgregarAnimal(oAnimal);
                        break;
                    case 2:
                        Console.WriteLine("Ingrese el nombre del ave: ");
                        string nombreAve = Console.ReadLine();
                        Console.WriteLine("Ingrese el alimento del ave: ");
                        string alimentoAve = Console.ReadLine();
                        Console.WriteLine("Ingrese la especie del ave: ");
                        string especieAve = Console.ReadLine();
                        oAnimal = new Aves(nombreAve, alimentoAve, especieAve);
                        oZoologico.AgregarAnimal(oAnimal);
                        break;
                    case 3:
                        Console.WriteLine("Ingrese el nombre del pez: ");
                        string nombrePez = Console.ReadLine();
                        Console.WriteLine("Ingrese el alimento del pez: ");
                        string alimentoPez = Console.ReadLine();
                        Console.WriteLine("Ingrese la especie del pez: ");
                        string especiePez = Console.ReadLine();
                        oAnimal = new Peces(nombrePez, alimentoPez, especiePez);
                        oZoologico.AgregarAnimal(oAnimal);
                        break;
                    case 4:
                        Console.WriteLine("Ingrese el nombre de la planta carnivora: ");
                        string nombrePlanta = Console.ReadLine();
                        Console.WriteLine("Ingrese el alimento de la planta carnivora: ");
                        string alimentoPlanta = Console.ReadLine();
                        Console.WriteLine("Ingrese la especie de la planta carnivora: ");
                        string especiePlanta = Console.ReadLine();
                        oAnimal = new PlantaCarnivora(nombrePlanta, alimentoPlanta, especiePlanta);
                        oZoologico.AgregarAnimal(oAnimal);
                        break;
                    case 5:
                        oZoologico.MostrarAnimales();
                        break;
                    case 6:
                        Console.WriteLine("Ingrese el ID del cuidador que desea editar: ");
                        int idCuidador = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Ingrese el nuevo nombre del cuidador: ");
                        string nuevoNombre = Console.ReadLine();
                        oZoologico.EditarCuidador(idCuidador, nuevoNombre);
                        break;
                    case 7:
                        foreach (Cuidadores cuidador in oZoologico.ObtenerCuidadores())
                        {
                            cuidador.AlimentarAnimales(oZoologico);
                        }
                        break;
                    case 8:
                        foreach (Cuidadores cuidador in oZoologico.ObtenerCuidadores())
                        {
                            Console.WriteLine("ID: {0}, Nombre: {1}", cuidador.ID, cuidador.Nombre);
                        }
                        break;
                    case 9:
                        Console.WriteLine("Saliendo del programa...");
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Por favor, ingrese una opción válida.");
                        break;
                }

            }      
        }
    }

}