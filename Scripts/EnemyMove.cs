using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyMove : MonoBehaviour
{
    public float speed = 3.0f;
    public Rigidbody enemyRb;
    public GameObject player;
    public NavMeshAgent enemy;
    public Transform players;
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed);
         enemy.SetDestination(players.position);
        if(transform.position.z >10)
        {
            Destroy(gameObject);
        }
    }

}