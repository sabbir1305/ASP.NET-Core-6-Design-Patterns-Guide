using NinjaAttack.Contracts;
using System.Numerics;

namespace NinjaAttack.Models;
public class Ninja : IAttackable, IAttacker
{
    private readonly Weapon _mele ;
    private readonly Weapon _ranged;

    public string Name { get; }
    public Vector2 Position { get; set; }

    public Ninja(string name,Weapon mele, Weapon ranged, Vector2? position = null)
    {
        Name = name;
        Position = position ?? Vector2.Zero;
        this._mele = mele;
        this._ranged = ranged;
    }

    public AttackResult Attack(IAttackable target)
    {
        var distance = this.DistanceFrom(target);
        if (_mele.CanHit(distance))
        {
            return new AttackResult(_mele, this, target);
        }
        else
        {
            return new AttackResult(_ranged, this, target);
        }
    }
}