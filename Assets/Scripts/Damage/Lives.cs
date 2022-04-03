using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lives : HitPoints
{
    [SerializeField] float invulnerabilityTime;
    //[SerializeField] AudioClip lifeLostSound;
    //[SerializeField] float lifeLostSoundVolume;

    private CooldownTimer invulnerabilityTimer;

    private new void Start()
    {
        base.Start();
        invulnerabilityTimer = new CooldownTimer(invulnerabilityTime);
    }

    private void Update()
    {
        if (invulnerabilityTimer.CanBeTriggered())
        {
            SetVulnerable(true);
        }
    }

    public override void InflictDamage(int damage)
    {
        base.InflictDamage(Mathf.Clamp(damage, -1, 1));
        SetVulnerable(false);
        invulnerabilityTimer.Trigger();
        GetComponent<FlickerEffect>().Activate(invulnerabilityTime);
        //if (GetCurrentHitPoints() >= 1) AudioSource.PlayClipAtPoint(lifeLostSound, Camera.main.transform.position, lifeLostSoundVolume);
    }
}
