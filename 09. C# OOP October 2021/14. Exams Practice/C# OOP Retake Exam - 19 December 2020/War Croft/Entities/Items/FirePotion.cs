using WarCroft.Entities.Characters.Contracts;

namespace WarCroft.Entities.Items
{
    public class FirePotion : Item
    {
        private const int Default_Weight = 5;

        private const int Default_Decrease_Points = 20;

        public FirePotion()
            : base(Default_Weight)
        {
        }

        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);
            character.Health -= Default_Decrease_Points;

            if (character.Health <= 0)
            {
                character.IsAlive = false;
            }
        }
    }
}
