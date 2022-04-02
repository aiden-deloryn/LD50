using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletImpl : MonoBehaviour
{
    private Vector3 mousePositionNow;
    private Camera mainCam;
    private Rigidbody2D rb;
    public float force;// gives the bullet some velocity

    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePositionNow = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePositionNow - transform.position;
        Vector3 rotation = transform.position - mousePositionNow;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);//why + 90?
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
