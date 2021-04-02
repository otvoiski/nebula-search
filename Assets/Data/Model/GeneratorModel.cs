using UnityEngine;

namespace Assets.Data.Model
{
    [CreateAssetMenu(fileName = "Generator", menuName = "Items/Generator")]
    public class GeneratorModel : CategoryItemModel
    {
        public int powerGenerator;
        public int maxBuffer;
        public int maxProcessTime;
    }
}