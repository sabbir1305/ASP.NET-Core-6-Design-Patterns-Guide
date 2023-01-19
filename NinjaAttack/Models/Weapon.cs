using System.Numerics;

namespace NinjaAttack.Models
{
    public abstract class Weapon
    {
        public abstract double MinRanged { get; }
        public abstract double MaxRanged { get; }

        public virtual string Name => GetType().Name;
        public virtual bool CanHit(double distance)
            => distance >= MinRanged && distance <= MaxRanged;
    }

    public class Sword : Weapon
    {
        public override double MinRanged { get; } = 0;
        public override double MaxRanged { get; } = Vector2.Distance(Vector2.Zero, Vector2.One);
    }

    public class Shuriken : Weapon
    {
        public override double MinRanged { get; } = Vector2.Distance(Vector2.Zero, Vector2.One);
        public override double MaxRanged { get; } = 20;
    }

    public class Pistol : Weapon
    {
        public override double MinRanged { get; } = Vector2.Distance(Vector2.Zero, Vector2.One);
        public override double MaxRanged { get; } = 50;
    }
}
