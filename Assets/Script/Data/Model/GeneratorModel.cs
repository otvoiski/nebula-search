using Assets.Script.Data.Model;
using UnityEngine;

[CreateAssetMenu(fileName = "Generator", menuName = "Itens/Generator")]
public class GeneratorModel : CategoryItenModel
{
    public int powerGenerator;
    public int maxBuffer;
    public int maxProcessTime;
}