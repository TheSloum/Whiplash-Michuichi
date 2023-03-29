using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouv : MonoBehaviour
{
    public float speed = 5f;
    public Transform playerBox;
    public Transform target;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

         Vector3 direction = playerBox.forward * vertical + playerBox.right * horizontal;
        direction.y = 0;
        // increment speed 
        transform.position += direction * speed * Time.deltaTime;
        
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        float minDistance = float.MaxValue;

        foreach (GameObject enemy in enemies) {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < minDistance) {
                minDistance = distance;
                target = enemy.transform;
            }
        }

        if(target != null){
             Vector3 lookDirection = target.position - transform.position;
lookDirection.y = 0;
Quaternion rotation = Quaternion.LookRotation(lookDirection);
transform.rotation = rotation;
    }
    
    }
}
