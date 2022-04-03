using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable {
    void InflictDamage(int damage);
    void ResetDamage();
    bool IsVulnerable();
    void SetVulnerable(bool vulnerable);
    void Die();
}
