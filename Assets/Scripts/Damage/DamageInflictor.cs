using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageInflictor : MonoBehaviour {
    [SerializeField] protected int damage;
    [SerializeField] protected bool destroyOnDamage = true;

    // Update is called once per frame
    protected void Update() {
        
    }

    private void OnTriggerEnter2D(Collider2D otherCollider) {
        IDamageable hitPoints = otherCollider.gameObject.GetComponent<IDamageable>();

        if (hitPoints != null && hitPoints.IsVulnerable()) {
            hitPoints.InflictDamage(damage);

            if (destroyOnDamage) {
                Destroy(this.gameObject);
            }
        }
    }
}