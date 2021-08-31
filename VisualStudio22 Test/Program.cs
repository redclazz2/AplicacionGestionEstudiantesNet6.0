/*Programa Para Gestionar los Alumnos de una clase, se deben inscribir como minimo 4 alumnos
 * Se debe contar con la opcion para ver las mejores 2 notas de la clase
 * Se debe tener una opcion para imprimir los detalles de un estudiante por ID
 * El programa debe mostrar si el estudiante aprueba o no el curso
 * El programa debe mostrar un informe de la cantidad de estudiantes que aprueban el curso, el porcentaje de aprobacion, la cantidad
 * que pierde y el porcentaje de perdida
*/

//Main
string nombre; int id, cantidadEstudiantes,inMenu = 1; float calificacion;
Console.WriteLine("Ingrese la cantidad de alumnos que tiene su clase: "); cantidadEstudiantes = int.Parse(Console.ReadLine());
Estudiante[] AlumnosInscritos = new Estudiante[cantidadEstudiantes];

for (int i = 0; i<cantidadEstudiantes; i++) 
{
    Console.WriteLine("Porfavor Ingrese el nombre del estudiante numero {0}: ", (i + 1)); nombre = Console.ReadLine();

    Console.WriteLine("Porfavor Ingrese el ID del estudiante: "); id = int.Parse(Console.ReadLine());

    Console.WriteLine("Porfavor Ingrese la Calificacion Final del Estudiante: "); calificacion = float.Parse(Console.ReadLine());

    AlumnosInscritos[i] = new Estudiante(nombre, id, calificacion);
}

while (inMenu == 1)
{
    Console.WriteLine("Puede seleccionar alguna de las siguientes opciones escribiendo el numero de la opcion: ");
    Console.WriteLine("1. Ver las mejores 2 notas de la clase. ");
    Console.WriteLine("2. Imprimir los detalles de un estudiante. ");
    Console.WriteLine("3. Generar informe sobre la cantidad de estudiantes que aprueban el curso y el porcentaje de aprobación. ");
    Console.WriteLine("4. Cerrar el programa.");

    var opcionSelecionada = int.Parse(Console.ReadLine());

    switch (opcionSelecionada)
    {
        case (1):

            float[] calificaciones = new float[cantidadEstudiantes];

            for (int i = 0; i < cantidadEstudiantes; i++)
            {
                calificaciones[i] = AlumnosInscritos[i].Calificacion;
            }

            Array.Sort(calificaciones);
            Array.Reverse(calificaciones, 0, calificaciones.Length);
            Console.WriteLine("******************");
            Console.WriteLine("Las dos mejores calificacionoes son: {0} y {1}", calificaciones[0], calificaciones[1]);
            Console.WriteLine("******************");

            break;

        case (2):
            Console.WriteLine("Ingrese el ID del estudiante que desee consultar: ");
            var idConsulta = int.Parse(Console.ReadLine());
            int idEncontrado = 0;

            for (int i = 0; i < cantidadEstudiantes; i++)
            {
                if (AlumnosInscritos[i].Identificador == idConsulta)
                {
                    idEncontrado = i;
                }
            }

            var nota = AlumnosInscritos[idEncontrado].Calificacion;
            Console.WriteLine("********************");
            Console.WriteLine("Nombre del estudiante: {0}", AlumnosInscritos[idEncontrado].Nombre);
            Console.WriteLine("Calificación final del estudiante: {0}", nota);
            if (nota >= 3.0) 
            {
                Console.WriteLine("El estudiante Aprueba la materia.");
            }
            else 
            {
                Console.WriteLine("El estudiante no aprobó el curso...");
            }
            Console.WriteLine("********************");
            break;

        case (3):
            int aprueba=0, pierde=0;

            for(int i = 0; i<cantidadEstudiantes; i++) 
            {
                if (AlumnosInscritos[i].Calificacion >= 3.0) 
                {
                    aprueba++;
                }
                else 
                {
                    pierde++;
                }
            }

            Console.WriteLine("********************");
            Console.WriteLine("La cantidad de estudiantes que aprobaron la materia es: {0}, " +
                "\nEl porcentaje de aprobación es: {1}%",aprueba,(aprueba/cantidadEstudiantes)*100);
            Console.WriteLine("La cantidad de estudiantes que perdieron la materia es: {0}, " +
                "\nEl porcentaje de perdida es: {1}%", pierde, (pierde / cantidadEstudiantes) * 100);
            Console.WriteLine("********************");
            break;

        case (4):
            return;
    }
}

//Clase Estudiante
public class Estudiante
{
    string nombre;
    int id;
    float calificacionFinal;

    public float Calificacion
    {
        get { return calificacionFinal; }
        set { calificacionFinal = value; }
    }

    public int Identificador 
    {
        get { return id; }
        set { id = value; }
    }

    public string Nombre 
    {
        get {  return nombre; }
        set { nombre = value; }
    }

    public Estudiante(string nombre, int id, float calificacionFinal)
    {
        this.nombre = nombre;
        this.id = id;
        this.calificacionFinal = calificacionFinal;
    }
}