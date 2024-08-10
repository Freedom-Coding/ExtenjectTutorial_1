using UnityEngine;

namespace TestExtenjectFactory
{
    public class LeatherArmour : IArmour
    {
        public float protection { get; set; } = 2;

        public void Protect()
        {
            Debug.Log("Using leather armour. Protection level: " + protection);
        }
    }
}