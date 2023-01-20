using System.Numerics;

namespace NinjaAttack.Models
{
    public abstract class Weapon
    {
        public abstract float MinRanged { get; }
        public abstract float MaxRanged { get; }

        public virtual string Name => GetType().Name;
        public virtual bool CanHit(float distance)
            => distance >= MinRanged && distance <= MaxRanged;
    }

    public class Sword : Weapon
    {
        public override float MinRanged { get; } = 0;
        public override float MaxRanged { get; } = Vector2.Distance(Vector2.Zero, Vector2.One);
    }

    public class Shuriken : Weapon
    {
        public override float MinRanged { get; } = Vector2.Distance(Vector2.Zero, Vector2.One);
        public override float MaxRanged { get; } = 20;
    }

    public class Pistol : Weapon
    {
        public override float MinRanged { get; } = Vector2.Distance(Vector2.Zero, Vector2.One);
        public override float MaxRanged { get; } = 50;
    }

    public class Kick : Weapon
    {
        public override float MinRanged { get; } = 0;
        public override float MaxRanged { get; } = 0;
    }

    public class Cutlass : Sword { }
    public class BoardingAxe : Weapon
    {
        public override float MinRanged { get; } = 0;
        public override float MaxRanged { get; } = 5;
    }
    public class Blunderbuss : Weapon
    {
        public override float MinRanged { get; } = 3;
        public override float MaxRanged { get; } = 100;
    }


}
