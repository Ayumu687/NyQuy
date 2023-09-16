using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
	[SerializeField]
	private Waypoints platformPath;

	[SerializeField]
	private float speed;

    AudioSource sound;
	private int targetWaypointIndex;
	private Transform previousWaypoint;
	private Transform targetWaypoint;
	private float timeToWaypoint;
	private float timeElapsed;

    // Start is called before the first frame update
    void Start()
    {
        TargetNextWaypoint();
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
     	timeElapsed += Time.deltaTime;
        float elapsedPercentage = timeElapsed / timeToWaypoint;
        transform.position = Vector3.Lerp(previousWaypoint.position, targetWaypoint.position, elapsedPercentage);

        if(elapsedPercentage >= 1)
        {
        	TargetNextWaypoint();
        }   
    }

    private void TargetNextWaypoint()
    {
    	previousWaypoint = platformPath.GetWaypoint(targetWaypointIndex);
    	targetWaypointIndex = platformPath.GetNextWaypointIndex(targetWaypointIndex);
    	targetWaypoint = platformPath.GetWaypoint(targetWaypointIndex);

    	timeElapsed = 0;

    	float distanceToWaypoint = Vector3.Distance(previousWaypoint.position, targetWaypoint.position);
    	timeToWaypoint = distanceToWaypoint / speed;
    }

    private void OnCollisionEnter(Collision collision)
    { 
       if (collision.collider.tag == "Player")
       {
            sound.Play();
       }
    }
}
