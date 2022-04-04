using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageInflictor : MonoBehaviour {
    [SerializeField] protected int damage;
    [SerializeField] protected bool destroyOnDamage = true;
    [SerializeField] AudioClip deathSound;
    [SerializeField] float deathSoundVolume;
    public GameObject particleHit;

    // Update is called once per frame
    protected void Update() {
        
    }

    private void OnTriggerEnter2D(Collider2D otherCollider) {
        IDamageable hitPoints = otherCollider.gameObject.GetComponent<IDamageable>();

        if (hitPoints != null && hitPoints.IsVulnerable()) {
            hitPoints.InflictDamage(damage);
            Instantiate(particleHit, transform.position, Quaternion.AngleAxis(90, transform.position));
            if (destroyOnDamage) {
                Destroy(this.gameObject);
                AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, deathSoundVolume);
            }
        }
    }
}
