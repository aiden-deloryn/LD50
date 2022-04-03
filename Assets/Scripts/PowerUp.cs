using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] GameObject gunPrefab;

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {

            //public Vector2 other.ClosestPoint(Vector2 gunPosition);
            Pickup(other.gameObject);
            Equip(other);
        }
    }

    void Pickup(GameObject player)
    {
        //var circleRenderer = player.GetComponent<Renderer>();
        //circleRenderer.material.SetColor("_Color", Color.red);

        //this.gameObject.transform.SetParent(player.transform);
        //Object.Instantiate(gunPrefab, new Vector2(0f, 0f), Quaternion.identity);
        //GameObject player = GameObject.FindGameObjectWithTag("Player");
        //colour change

        Destroy(gameObject);

    }
    void Equip(Collider2D player)
    {
        Vector2 gunPosition = player.ClosestPoint(transform.position);
        // calculate degrees to rotate to point to current mouse position
        float rotationDegZ = Mathf.Atan2(gunPosition.y, gunPosition.x) * Mathf.Rad2Deg;

        // rotate this object to point to the mouse cursor
        transform.rotation = Quaternion.Euler(0, 0, rotationDegZ);


        //float angleToPlayer = Vector3.SignedAngle(player.transform.position, gunPosition, Vector3.right);

        //float gunRotation = Angle(gunPosition, player.transform.position);
        //float gunRotation = Vector2.eulerAngle(gunPosition, player.transform.position);
        GameObject gun = Object.Instantiate(gunPrefab, gunPosition, Quaternion.Euler(0f, 0f, rotationDegZ));
        gun.gameObject.transform.SetParent(player.transform);
        print(rotationDegZ);
        print(this.transform.position);
        print(gunPosition);

    }
}