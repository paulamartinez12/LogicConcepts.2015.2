using System;

namespace TimeAddition
{
    class Program
    {
        static void Main(string[] args)
        {
            // Datos iniciales
            int[] hours = { 0, 14, 9, 19, 23 };
            int[] minutes = { 0, 0, 34, 45, 3 };
            int[] seconds = { 0, 0, 0, 56, 45 };
            int[] milliseconds = { 0, 0, 0, 678, 678 };

            // Mostrar los datos iniciales
            for (int i = 0; i < hours.Length; i++)
            {
                Console.WriteLine($"t{i + 1} = {hours[i]}:{minutes[i]}:{seconds[i]}.{milliseconds[i]}");
            }

            // Sumar tiempos y verificar si hay cambio de día
            for (int i = 0; i < hours.Length - 1; i++)
            {
                bool isNextDay = AddTime(ref hours[i], ref minutes[i], ref seconds[i], ref milliseconds[i], hours[i + 1], minutes[i + 1], seconds[i + 1], milliseconds[i + 1]);
                Console.WriteLine($"t{i + 1} + t{i + 2} = {hours[i]}:{minutes[i]}:{seconds[i]}.{milliseconds[i]}  (Next Day: {isNextDay})");
            }

            Console.ReadLine();
        }

        // Método para sumar tiempos
        static bool AddTime(ref int hour1, ref int minute1, ref int second1, ref int millisecond1, int hour2, int minute2, int second2, int millisecond2)
        {
            bool isNextDay = false;

            // Sumar milisegundos
            millisecond1 += millisecond2;
            if (millisecond1 >= 1000)
            {
                millisecond1 -= 1000;
                second1++;
            }

            // Sumar segundos
            second1 += second2;
            if (second1 >= 60)
            {
                second1 -= 60;
                minute1++;
            }

            // Sumar minutos
            minute1 += minute2;
            if (minute1 >= 60)
            {
                minute1 -= 60;
                hour1++;
            }

            // Sumar horas
            hour1 += hour2;
            if (hour1 >= 24)
            {
                hour1 -= 24; // Pasar al siguiente día
                isNextDay = true;
            }

            return isNextDay;
        }
    }
}

