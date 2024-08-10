using UnityEngine;
using System;
using Zenject;

namespace TestExtenjectFactory
{
    public class Enemy : MonoBehaviour
    {
        [Inject] private IFactory<ArmourType, IArmour> armourFactory;
        private IArmour armour;

        private void Start()
        {
            Array values = typeof(ArmourType).GetEnumValues();
            System.Random random = new System.Random();
            ArmourType randomArmourType = (ArmourType)values.GetValue(random.Next(values.Length));

            armour = armourFactory.Create(randomArmourType);
            ReceiveDamage();
        }

        public void ReceiveDamage()
        {
            armour.Protect();
        }
    }
}