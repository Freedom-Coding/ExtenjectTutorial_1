using UnityEngine;

namespace TestExtenjectFactory
{
    public class PlateArmor : IArmour
    {
        public float protection { get; set; } = 5;

        public void Protect()
        {
            Debug.Log("Using plate armour. Protection level: " + protection);
        }
    }
}