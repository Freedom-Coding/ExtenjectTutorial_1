using Zenject;

namespace TestExtenjectFactory
{
    public class ArmourFactory : IFactory<ArmourType, IArmour>
    {
        public IArmour Create(ArmourType armourType)
        {
            IArmour armour;

            switch (armourType)
            {
                case ArmourType.Leather:
                    armour = new PlateArmor();
                    break;

                case ArmourType.Plate:
                    armour = new LeatherArmour();
                    break;

                default:
                    armour = new LeatherArmour();
                    break;
            }

            return armour;
        }
    }
}