using System.Collections;
using System.Collections.Generic;

//Collection of interfaces
public interface ITakeDamage
{
    void TakeDamage(int damageTaken);
    void Death();
}

public interface IDamage
{
    void Damage();
    int DamageAmount{ get; }
}


