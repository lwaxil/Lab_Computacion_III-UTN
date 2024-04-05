using System;

class Program
{
    static void Main()
    {
        Console.Write("Ingrese el primer número: ");
        double num1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Ingrese el segundo número: ");
        double num2 = Convert.ToDouble(Console.ReadLine());

        double suma = num1 + num2;
        double resta = num1 - num2;
        double multiplicacion = num1 * num2;
        double division = num1 / num2;

        Console.WriteLine($"La suma de {num1} y {num2} es: {suma}");
        Console.WriteLine($"La resta de {num1} y {num2} es: {resta}");
        Console.WriteLine($"La multiplicación de {num1} y {num2} es: {multiplicacion}");
        Console.WriteLine($"La división de {num1} y {num2} es: {division}");
    }
}