using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickerEffect : MonoBehaviour {
    public bool includeChildObjects;
    public float flickerInterval;

    private CooldownTimer toggleTimer;
    private CooldownTimer durationTimer;
    private SpriteRenderer spriteRenderer;
    private SpriteRenderer[] childSpriteRenderers;
    private bool activated = false;
    private float alphaValueLow = 0.1f;
    private float alphaValueHigh = 0.5f;

    // Use this for initialization
    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        childSpriteRenderers = GetComponentsInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update() {
        if (!activated)
            return;

        if (!durationTimer.CanBeTriggered()) {
            if (toggleTimer.CanBeTriggered()) {
                toggleTimer.Trigger();

                if (includeChildObjects) {
                    // childSpriteRenderers includes the parent object
                    foreach (SpriteRenderer childSpriteRenderer in childSpriteRenderers) {
                        ToggleAlpha(childSpriteRenderer);
                    }
                } else {
                    ToggleAlpha(spriteRenderer);
                }
            }
        } else {
            if (spriteRenderer != null) {
                spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 1f);
            }

            if (includeChildObjects) {
                foreach (SpriteRenderer childSpriteRenderer in childSpriteRenderers) {
                    childSpriteRenderer.color = new Color(childSpriteRenderer.color.r, childSpriteRenderer.color.g, childSpriteRenderer.color.b, 1f);
                }
            }

            activated = false;
        }
    }

    public void Activate(float effectDuration) {
        toggleTimer = new CooldownTimer(flickerInterval);
        durationTimer = new CooldownTimer(effectDuration);
        durationTimer.Trigger();
        activated = true;
    }

    private void ToggleAlpha(SpriteRenderer targetRenderer) {
        float currentAlpha = spriteRenderer.color.a;
        float newAlpha = Mathf.Approximately(currentAlpha, alphaValueLow) ? alphaValueHigh : alphaValueLow;
        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, newAlpha);
    }
}
