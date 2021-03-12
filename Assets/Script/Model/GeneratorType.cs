using UnityEngine;

[CreateAssetMenu(fileName = "Generator", menuName = "Itens/Generator")]
public class GeneratorType : ScriptableObject
{
    public string title = "Generator";
    public int powerGenerator;
    public int maxBuffer;
    public int processTime;
    public Material[] inputs;
    public Material output;
}