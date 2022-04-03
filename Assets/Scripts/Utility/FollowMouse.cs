using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePositionNow;
    private SpriteRenderer sprite;
    private Color mouseReleased = new Color(1f,1f,1f,153/255f);
    private Color mouseHeldDown = new Color(65/255f, 65/255f, 65/255f, 153/255f);
    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePositionNow = mainCam.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePositionNow.x, mousePositionNow.y, 0);
        if (Input.GetMouseButton(0))
        {
            sprite.color = mouseHeldDown;
        }
        else
        {
            sprite.color = mouseReleased;
        }
    }
}
