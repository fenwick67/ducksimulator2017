using UnityEngine;
using System.Collections;
using System.Collections.Generic;


	[RequireComponent(typeof (NavMeshAgent))]
	[RequireComponent(typeof (BirdMove))]
	public class AIBirdControl : MonoBehaviour	{
		public NavMeshAgent agent { get; private set; }             // the navmesh agent required for the path finding
		public BirdMove character { get; private set; } // the character we are controlling
		public Transform target;                                    // target to aim for
		public List<Transform> Waypoints;  							//cycle through waypoints

		private int waypointIndex = 0;

		public float checkpointRadius = 1f;

		private void Start()
		{
			// get the components on the object we need ( should not be null due to require component so no need to check )
			agent = GetComponentInChildren<NavMeshAgent>();
			character = GetComponent<BirdMove>();

			agent.updateRotation = false;
			agent.updatePosition = true;
			target = Waypoints [0];
			waypointIndex = 0;
		}


		private void Update()
		{
			if (target != null)
				agent.SetDestination(target.position);

			if (agent.remainingDistance > agent.stoppingDistance) {
				//move toward out target
				character.AIMove (agent.desiredVelocity*.3f);
			} else {
				//we got to the checkpoint
				character.AIMove (Vector3.zero);

				//we have to manually check if we are close to THIS checkpoint
				if (Vector3.Distance (target.position,agent.transform.position) <= checkpointRadius) {
					waypointIndex = (waypointIndex + 1) % Waypoints.Count;
					target = Waypoints[waypointIndex];
				}
			}
		}


		public void SetTarget(Transform target)
		{
			this.target = target;
		}
	}