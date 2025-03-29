namespace Uniza.CSharp.Generics.DataStructures;

/// <summary>
/// Vrchol obojsmerne zretazeného zoznamu.
/// </summary>
/// <typeparam name="T">Typ prvku, ktorého hodnotu bude vrchol obsahovať v <see cref="Data"/>.</typeparam>
//class DoublyLinkedNode
class GenericDoublyLinkedNode<T>
{
    /// <summary>
    /// Odkaz na predchádzajúci vrchol.
    /// </summary>
    public GenericDoublyLinkedNode<T> Previous { get; set; }
    
    /// <summary>
    /// Odkaz na nasledujúci vrchol.
    /// </summary>
    public GenericDoublyLinkedNode<T> Next { get; set; }

    /// <summary>
    /// Obsahuje hodnotu prvku.
    /// </summary>
    public T Data { get; set; }

    /// <summary>
    /// Vytvorí vrchol pre obojsmerne zreťazený zoznam.
    /// </summary>
    /// <param name="data">Hodnota prvku, ktorý bude vrchol obsahovať.</param>
    public GenericDoublyLinkedNode(T data)
    {
        Data = data;
        Next = this;
        Previous = this;
    }
}
