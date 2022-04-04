using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aiming : MonoBehaviour
{
    // This script is for GameObject RotatePoint
    public Transform agent;// agent is what the gamer is controlling.
    private Camera mainCam;// the main camera. see def in void Start()
    private Vector3 mousePositionNow;// mouse position seen by the main cam, see def in void Update()
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
    }
}
