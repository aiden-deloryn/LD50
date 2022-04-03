using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletImpl : MonoBehaviour
{
    private Vector3 mousePositionNow;
    private Camera mainCam;
    private Rigidbody2D rb;
    public float force;// gives the bullet some velocity
    public Transform bulletOut;
    public Transform playerAt;
    public float range;
    // Start is called before the first frame update
    void Start()
    {
        bulletOut = GameObject.Find("BulletOut").transform;
        playerAt = GameObject.Find("Player").transform;
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePositionNow = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = bulletOut.position - playerAt.position;
        //Vector3 direction = mousePositionNow - transform.position;
        Vector3 rotation = transform.position - mousePositionNow;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;


        transform.rotation = Quaternion.Euler(0, 0 , rot);//why + 90?
        transform.position = transform.position + bulletOut.position;
    }

    // Update is called once per frame
    void Update()
    {
        // if bullet goes out of a circle, it disappears
        if (Vector3.Distance(transform.position, playerAt.position) > range)
        {
            Destroy(gameObject);
        }
    }
}
