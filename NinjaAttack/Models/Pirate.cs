using NinjaAttack.Contracts;
using System.Numerics;

namespace NinjaAttack.Models
{
    public class Pirate : IAttackable, IAttacker
    {
        public string Name { get; }
        public Vector2 Position { get; set; }
        private readonly List<Weapon> _weapons;
        public Pirate(string name, params Weapon[] weapons)
        {
            _weapons = new(weapons);
            Name = name;
        }


        public AttackResult Attack(IAttackable target)
        {
            var distance = this.DistanceFrom(target);
            foreach (var weapon in _weapons)
            {
                if (weapon.CanHit(distance))
                {
                    return new AttackResult(weapon, this, target);
                }
            }
            return new(new NoWeapon(), this, target);
        }

        private class NoWeapon : Weapon
        {
            public override float MinRanged => 0;
            public override float MaxRanged => 0;
            public override string Name { get; } = "Nothing";
            public override bool CanHit(float distance) => false;
        }
    }
}
