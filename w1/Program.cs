﻿public class Program
{
    public static void Main()
    {
        /*Cviko();*/
        Uloha1_2();
    }

    public static void Cviko()
    {
        System.Console.WriteLine("Hello, World!");

        System.Console.WriteLine(DateTime.Now);

        int currentHour = DateTime.Now.Hour;

        if (currentHour > 4 && currentHour <= 8)
        {
            System.Console.WriteLine("Dobre rano");
        }
        else if (currentHour > 8 && currentHour <= 18)
        {
            System.Console.WriteLine("Dobry den");
        }
        else if (currentHour > 18 && currentHour <= 22)
        {
            System.Console.WriteLine("Dobry vecer");
        }
        else if (currentHour > 22 && currentHour <= 4)
        {
            System.Console.WriteLine("Dobru noc");
        }


        int rand = Random.Shared.Next() % 100 + 1;
        int maxPokusy = 10;
        int momentalnePokusy = 0;

        System.Console.WriteLine($"\nZahrame si hru na uhadnutie cisla. Myslim na cislo od 1 do 100. Mas {maxPokusy} pokusov. Uhadnes na ake myslim?");

        var startTime = DateTime.Now;


        while (true)
        {
            System.Console.Write("Zadaj cislo: ");

            if (int.TryParse(Console.ReadLine(), out int user))
            {
                momentalnePokusy++;

                if (user == rand)
                {
                    Console.WriteLine("Gratulujem, uhadol si!");
                    break;
                }
                else
                {
                    Console.WriteLine($"Lutujem, neuhadol si... Cislo ktore hladas je {(rand > user ? "vacsie" : "mensie")}. Zostavajuci pocet pokusov: {maxPokusy - momentalnePokusy}");
                }
            }

            if (momentalnePokusy >= maxPokusy)
            {
                Console.WriteLine($"Hra sa skoncila... Cislo, ktore si hladal bolo {rand}");
                break;
            }

            /*System.Console.WriteLine("[DEBUG] " + user + ":" + rand);*/
        }

        var endTime = DateTime.Now;
        Console.WriteLine($"\nCelkovy cas hrania v sekundach: {(endTime - startTime).TotalSeconds} \nPocet pokusov: {momentalnePokusy}");
    }

    public static void Uloha1_1() { }

    public static void Uloha1_2()
    {
        int[] temperatures = { 10, 12, 14, 16, 18, 20, 22, 24, 22, 20, 18, 16 };

        for (int i = 0; i < temperatures.Length; i++)
        {

            Console.Write($"{temperatures[i]} stupnov C: ");
            for (int j = 0; j < temperatures[i]; j++)
            {
                Console.Write("*");
            }
            Console.Write("\n");
        }
    }
}
