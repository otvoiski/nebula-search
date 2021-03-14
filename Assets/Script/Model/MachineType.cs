using UnityEngine;

[CreateAssetMenu(fileName = "Machine", menuName = "Itens/Machine")]
public class MachineType : ScriptableObject
{
    public string title;
    public int maxBuffer;
    public int powerConsume;
    public int maxProcessTime;
    public Material[] inputs;
    public Material[] outputs;
}