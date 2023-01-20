using NinjaAttack.Contracts;
using System.Numerics;

namespace NinjaAttack.Models
{
    public class Barrel : IAttackable
    {
        public string Name => nameof(Barrel);
        public Vector2 Position { get; set; }
    }
}
