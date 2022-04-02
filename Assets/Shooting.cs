using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    // This script is for GameObject RotatePoint
    public Transform agent;// agent is what the gamer is controlling.
    private Camera mainCam;// the main camera. see def in void Start()
    private Vector3 mousePositionNow;// mouse position seen by the main cam, see def in void Update()
    public bool canFire = true;// limiting fire frequency as mouse buttong is held down, default true
    private float coolDownTimer;// controls the fire frequency.
    public GameObject bullet;
    public Transform bulletTransform;
    public float firingPeriod;// in sec 
    
    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        
    }

    // Update is called once per frame
    void Update()
    {
        // get mouse location (Vector3)
        mousePositionNow = mainCam.ScreenToWorldPoint(Input.mousePosition);

        // calculate the vector from current mouse location to the location of GameObject player.
        Vector3 displacementNow = mousePositionNow - agent.transform.position;
        // Vector3 displacementNow = mousePositionNow - transform.position;// old logic updating displacementNow
        
        // calculate degrees to rotate to point to current mouse position
        float rotationDegZ = Mathf.Atan2(displacementNow.y, displacementNow.x) * Mathf.Rad2Deg;

        // rotate this object to point to the mouse cursor
        transform.rotation = Quaternion.Euler(0, 0, rotationDegZ);

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
