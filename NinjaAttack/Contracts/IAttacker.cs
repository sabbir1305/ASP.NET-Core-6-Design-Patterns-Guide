using NinjaAttack.Models;

namespace NinjaAttack.Contracts;
public interface IAttacker : IAttackable
{
    AttackResult Attack(IAttackable target);
}
