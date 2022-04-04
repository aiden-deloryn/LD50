using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour {
    [SerializeField] float playerDetectionRadius;
    [SerializeField] float moveSpeed;
    [SerializeField] float maxPosX;
    [SerializeField] float maxPosY;

    private GameObject player;
    private Vector3 floatDirection;

    // Start is called before the first frame update
    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        floatDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f).normalized;
    }

    // Update is called once per frame
    void FixedUpdate() {
        print("Should Move Enemy: " + player.activeSelf);
        if (player.activeSelf)
        {
            Move();
        }
    }

    void Move() {
        float distanceToPlayer = Vector3.Distance(this.transform.position, player.transform.position);

        if (distanceToPlayer < playerDetectionRadius) {
            // Move towards player
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed * 0.01f);
            floatDirection = (player.transform.position - transform.position).normalized;
        } else {
            // Patrol mode
            Vector3 targetPosition = transform.position + floatDirection * moveSpeed;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * 0.01f);

            if (transform.position.x > maxPosX || transform.position.x < (maxPosX * -1)) {
                floatDirection = new Vector3(floatDirection.x * -1, floatDirection.y, floatDirection.z);
            }

            if (transform.position.y > maxPosY || transform.position.y < (maxPosY * -1)) {
                floatDirection = new Vector3(floatDirection.x, floatDirection.y * -1, floatDirection.z);
            }
        }
    }
}
