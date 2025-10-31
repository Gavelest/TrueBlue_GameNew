using UnityEngine;
using System.Collections;

public class NavMeshRun : MonoBehaviour {

	private Transform player;
	private UnityEngine.AI.NavMeshAgent myNMagent;
	private float nextTurnTime;
	private Transform startTransform;

	public float minimumDistanceFromPlayer = 5;


	// Use this for initialization
	void Start () {

		player = GameObject.FindGameObjectWithTag ("Player").transform;
		myNMagent = this.GetComponent<UnityEngine.AI.NavMeshAgent> ();

		RunFrom ();
	}
	
	// Update is called once per frame
	void Update () {

		// used for testing - can be ignored
		if(Time.time > nextTurnTime)
			RunFrom ();
	
	}

	public void WanderRandomly()
	{


	}

	public void RunFrom()
	{

		// store the starting transform
		startTransform = transform;
		
		//temporarily point the object to look away from the player
		transform.rotation = Quaternion.LookRotation(transform.position - player.position);
		Vector3 desiredMoveDirection = (transform.position - player.position).normalized;

		float currentDesiredDistance = Mathf.Max(minimumDistanceFromPlayer, Vector3.Distance(transform.position, player.position));

		//Then we'll get the position on that rotation that's multiplyBy down the path (you could set a Random.range
		// for this if you want variable results) and store it in a new Vector3 called runTo
		Vector3 runTo = player.position + desiredMoveDirection * currentDesiredDistance;
		//Debug.Log("runTo = " + runTo);
		
		//So now we've got a Vector3 to run to and we can transfer that to a location on the NavMesh with samplePosition.
		
		UnityEngine.AI.NavMeshHit hit;	// stores the output in a variable called hit

		// 5 is the distance to check, assumes you use default for the NavMesh Layer name
		UnityEngine.AI.NavMesh.SamplePosition(runTo, out hit, 5, 1 << UnityEngine.AI.NavMesh.GetNavMeshLayerFromName("Walkable")); 
		//Debug.Log("hit = " + hit + " hit.position = " + hit.position);

		// just used for testing - safe to ignore
		nextTurnTime = Time.time + 1;

		// reset the transform back to our start transform
		transform.position = startTransform.position;
		transform.rotation = startTransform.rotation;

		// And get it to head towards the found NavMesh position
		if(!myNMagent.isOnNavMesh) return;
		myNMagent.SetDestination(hit.position);

	}
}