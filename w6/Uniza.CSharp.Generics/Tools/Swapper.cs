using System.Reflection;

namespace Uniza.CSharp.Generics.Tools;

public class Swapper
{
    //public static void Swap(ref int number1, ref int number2)
    //{
    //    (number2, number1) = (number1, number2);
    //}

    //public static void Swap(ref double number1, ref double number2)
    //{
    //    (number2, number1) = (number1, number2);
    //}

    //public static void Swap(ref string str1, ref string str2)   
    //{
    //    (str2, str1) = (str1, str2);
    //}

    // TODO: Úloha 1.2 - Pridajte generickú metódu na prehodenie hodnôt a použite ju v programe.
    public static void Swap<T>(ref T value1, ref T value2)
    {
        (value2, value1) = (value1, value2);
    } 

}
