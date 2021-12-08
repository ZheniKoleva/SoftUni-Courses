using WarCroft.Entities.Characters.Contracts;

namespace WarCroft.Entities.Items
{
    public class HealthPotion : Item
    {
        private const int Default_Weight = 5;

        private const int Default_Heal_Points = 20;

        public HealthPotion() 
            : base(Default_Weight)
        {
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);
            character.Health += Default_Heal_Points;
        }
    }
}
