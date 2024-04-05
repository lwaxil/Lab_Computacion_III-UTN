using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Dictionary<string, int> daysOfWeek = new Dictionary<string, int>
        {
            {"Lunes", 1}, {"Martes", 2}, {"Miércoles", 3}, {"Jueves", 4}, {"Viernes", 5}, {"Sábado", 6}, {"Domingo", 7}
        };

        Dictionary<int, string> daysOfWeekReverse = new Dictionary<int, string>
        {
            {1, "Lunes"}, {2, "Martes"}, {3, "Miércoles"}, {4, "Jueves"}, {5, "Viernes"}, {6, "Sábado"}, {7, "Domingo"}
        };

        Console.Write("Ingrese el primer día del mes (por ejemplo, 'Lunes'): ");
        string firstDayInput = Console.ReadLine();
        int firstDay = daysOfWeek[firstDayInput];

        Console.Write("Ingrese una fecha del mes (un número del 1 al 31): ");
        int date = int.Parse(Console.ReadLine());

        int dayOfWeekNumber = ((date - 1 + firstDay - 1) % 7) + 1;
        string dayOfWeek = daysOfWeekReverse[dayOfWeekNumber];

        Console.WriteLine("El día " + date + " del mes cae en " + dayOfWeek + ".");
    }
}