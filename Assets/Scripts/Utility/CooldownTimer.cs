using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CooldownTimer {
	public float cooldownDuration = 0f;

	private float lastActivationTime = 0f;

	public CooldownTimer(float cooldownDuration) {
		this.cooldownDuration = cooldownDuration;
		this.lastActivationTime = cooldownDuration * -1;
	}

	public bool CanBeTriggered() {
		return (Time.time - lastActivationTime) >= cooldownDuration;
	}

	public void Trigger() {
		lastActivationTime = Time.time;
	}

	public float ElapsedPercentage() {
		return Mathf.Clamp((Time.time - lastActivationTime) / cooldownDuration, 0f, 1f);
	}
}