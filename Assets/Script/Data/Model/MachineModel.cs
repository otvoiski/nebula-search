using Assets.Script.Data.Model;
using UnityEngine;

[CreateAssetMenu(fileName = "Machine", menuName = "Itens/Machine")]
public class MachineModel : CategoryItemModel
{
    public int maxBuffer;
    public int powerConsume;
    public int maxProcessTime;
}