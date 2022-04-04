using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPoints : MonoBehaviour, IDamageable {
    [SerializeField] int baseHitPoints;
    //[SerializeField] AudioClip deathSound;
    //[SerializeField] float deathSoundVolume;
    //[SerializeField] GameObject explosionPrefab;

    private int currentHitPoints;
    private bool vulnerable = true;
    public GameObject particleDeath;
    public GameOverScreen gameOverScreen;

    private SpriteRenderer sprite;
    private float hsvColorNow_h;
    private float hsvColorNow_s;
    private float hsvColorNow_v;
    public float colorValueScaler = 0.8f;
    // Start is called before the first frame update
    protected void Start() {
        ResetDamage();
        sprite = GetComponent<SpriteRenderer>();
    }

    public int GetCurrentHitPoints() {
        return currentHitPoints;
    }

    public virtual void InflictDamage(int damage) {
        currentHitPoints = Mathf.Clamp(currentHitPoints - damage, 0, baseHitPoints);

        print("Damage inflicted! Current HP/Lives: " + currentHitPoints);
        // change color of the game object to darker
        Color.RGBToHSV(sprite.color, out hsvColorNow_h, out hsvColorNow_s, out hsvColorNow_v);
        sprite.color = Color.HSVToRGB(hsvColorNow_h, hsvColorNow_s, hsvColorNow_v * colorValueScaler);
        //
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
        //AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, deathSoundVolume);
        //Instantiate(explosionPrefab, transform.position, transform.rotation);
        Instantiate(particleDeath, transform.position, Quaternion.identity);
        if(gameObject.tag == "Player")
        {
            // deactivate player object
            gameObject.SetActive(false);
            print("Player is inactive now.");
            // show the gameover screen
            gameOverScreen.Setup();

        }
        else // gameObject is not Player, which means it is an enemy
        {
            Destroy(gameObject);
        }
        
    }
}
