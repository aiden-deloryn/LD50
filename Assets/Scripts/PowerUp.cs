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
        var circleRenderer = player.GetComponent<Renderer>();
        circleRenderer.material.SetColor("_Color", Color.red);

        //this.gameObject.transform.SetParent(player.transform);
        //Object.Instantiate(gunPrefab, new Vector2(0f, 0f), Quaternion.identity);
        //GameObject player = GameObject.FindGameObjectWithTag("Player");
        //colour change

        Destroy(gameObject);

    }
    void Equip(Collider2D player)
    {
        float angleToPlayer = Vector3.Angle(this.transform.position, player.transform.position);
        Vector2 gunPosition = player.ClosestPoint(transform.position);
        //float gunRotation = Angle(gunPosition, player.transform.position);
        //float gunRotation = Vector2.eulerAngle(gunPosition, player.transform.position);
        GameObject gun = Object.Instantiate(gunPrefab, gunPosition, Quaternion.Euler(0f, 0f, angleToPlayer+45f));
        gun.gameObject.transform.SetParent(player.transform);
        print(angleToPlayer);
        print(this.transform.position);
        print(player.transform.position);
    }
}