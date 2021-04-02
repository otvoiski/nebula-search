using UnityEngine;

namespace Assets.Data.Model
{
    [CreateAssetMenu(fileName = "Machine", menuName = "Items/Machine")]
    public class MachineModel : CategoryItemModel
    {
        public int maxBuffer;
        public int powerConsume;
        public int maxProcessTime;
    }
}