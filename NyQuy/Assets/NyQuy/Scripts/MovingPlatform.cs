using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
	[SerializeField]
	private Waypoints platformPath;

	[SerializeField]
	private float speed;

	private int targetWaypointIndex;
	private Transform previousWaypoint;
	private Transform targetWaypoint;
	private float timeToWaypoint;
	private float timeElapsed;

    // Start is called before the first frame update
    void Start()
    {
        TargetNextWaypoint();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timeElapsed += Time.deltaTime;
        float elapsedPercentage = timeElapsed / timeToWaypoint;
        elapsedPercentage = Mathf.SmoothStep(0, 1, elapsedPercentage);
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

    private void OnTriggerEnter(Collider other)
    {
    	other.transform.parent = transform;
    }

    private void OnTriggerExit(Collider other)
    {
    	other.transform.parent = null;
    }
}
