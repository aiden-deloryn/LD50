using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firing : MonoBehaviour
{
    public bool canFire = true;// limiting fire frequency as mouse buttong is held down, default true
    private float coolDownTimer;// controls the fire frequency.
    public GameObject bullet;
    public Transform bulletTransform;
    public float firingPeriod;// in sec, next feature: decrease 0.1 when same weapon picked up until 0.1 sec
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // fire when mouse left button clicked or held done
        if (!canFire)// when canFire is false, which means when cannot fire
        {
            // increment timer
            coolDownTimer += Time.deltaTime;

            // enable firing if cooled down
            if (coolDownTimer >= firingPeriod)
            {
                // enable firing
                canFire = true;

                // reset timer
                coolDownTimer = 0;
            }
        }
        if (Input.GetMouseButton(0) && canFire)
        {
            canFire = false;// enter cool down period timed by coolDownTimer
            Instantiate(bullet, bulletTransform.position, Quaternion.identity);
        }
    }
}
