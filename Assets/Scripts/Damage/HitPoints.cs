using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPoints : MonoBehaviour, IDamageable {
    [SerializeField] int baseHitPoints;
    [SerializeField] AudioClip deathSound;
    [SerializeField] float deathSoundVolume;
    [SerializeField] GameObject explosionPrefab;

    private int currentHitPoints;
    private bool vulnerable = true;
    public GameObject particleDeath;

    // Start is called before the first frame update
    protected void Start() {
        ResetDamage();
    }

    public int GetCurrentHitPoints() {
        return currentHitPoints;
    }

    public virtual void InflictDamage(int damage) {
        currentHitPoints = Mathf.Clamp(currentHitPoints - damage, 0, baseHitPoints);
        AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, deathSoundVolume);
        print("Damage inflicted! Current HP/Lives: " + currentHitPoints);

        if (currentHitPoints <= 0) {
            Die();
        }
    }

    public void ResetDamage() {
        currentHitPoints = baseHitPoints;
    }

    public bool IsVulnerable() {
        return vulnerable;
    }

    public void SetVulnerable(bool vulnerable) {
        this.vulnerable = vulnerable;
    }

    public void Die() {
        AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, deathSoundVolume);
        //Instantiate(explosionPrefab, transform.position, transform.rotation);
        Instantiate(particleDeath, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
