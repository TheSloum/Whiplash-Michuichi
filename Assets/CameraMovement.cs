using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;
    public Transform target;
    public Vector3 offset;
    public float smoothTime = 10f;
    private Vector3 currentVelocity;
    public GameObject enemy;
    public Vector3 offsetr;
    public float threshold= 10;

    void Start()
    {
        enemy = GameObject.FindWithTag("enemy");
    }
    void LateUpdate()
{
    // calculate distance between player and enemy
    float distance = Vector3.Distance(player.position, enemy.transform.position);

    // check if distance is greater than a certain threshold
    if (distance < threshold)
    {
        offset = new Vector3(((1.75f-((distance/threshold)*1.75f))+0.25f), (1.75f-((distance/threshold)*1.75f))+0.25f, (1-((distance/threshold)*1))-4);
        offsetr = new Vector3(0, offsetr.y, -1-((distance/threshold)*-1));
    }
    else
    {

        offset = new Vector3(0.25f, 0.25f, -4);
        offsetr = new Vector3(offsetr.x, offsetr.y, 0);
    }
    // update the camera's position to follow the player with an offset in local space
    Vector3 desiredPosition = player.TransformPoint(offset);
    transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * smoothTime);
    

    // make the camera look at the enemy
    if (enemy != null)
    {
        Vector3 targetPosition = enemy.transform.position + offsetr;
        transform.LookAt(targetPosition);
    }
}

}