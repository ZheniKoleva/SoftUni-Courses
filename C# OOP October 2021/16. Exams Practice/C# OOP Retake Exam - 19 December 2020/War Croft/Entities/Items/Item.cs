using System;

using WarCroft.Constants;
using WarCroft.Entities.Characters.Contracts;

namespace WarCroft.Entities.Items
{
	// Christmas came early this year - this class is already implemented for you!
	public abstract class Item
	{
		protected Item(int weight)
		{
			this.Weight = weight;
		}

		public int Weight { get; }

		public virtual void AffectCharacter(Character character)
		{
			if (!character.IsAlive)
			{
				throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
			}
		}
	}
}
