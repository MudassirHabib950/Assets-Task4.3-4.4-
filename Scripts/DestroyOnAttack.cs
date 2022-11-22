using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnAttack : MonoBehaviour
{
 public void OnCollisionEnter(Collision collision)
 {
    // whwn enemy collide with player it destroy but when spawn enemies collide it does not  destroy i failed to make logic of spawn enemies destroy
    if(collision.collider.CompareTag("Player"))
    {
        Destroy(collision.gameObject);
        Debug.Log("Score is 25");
    }
   
 }
}
