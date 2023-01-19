using System.Numerics;

namespace NinjaAttack.Contracts;

public interface IAttackable
{
    string Name { get; }
    Vector2 Position { get; set; }
}

