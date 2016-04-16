using System;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof (NavMeshAgent))]
    [RequireComponent(typeof (ThirdPersonCharacter))]
    public class AICharacterControl : MonoBehaviour
    {
        public NavMeshAgent agent { get; private set; }             // the navmesh agent required for the path finding
        public ThirdPersonCharacter character { get; private set; } // the character we are controlling
        public Transform target;                                    // target to aim for
		public List<Transform> Waypoints;  							//cycle through waypoints

		private int waypointIndex = 0;

		public float checkpointRadius = 1f;


        private void Start()
        {
            // get the components on the object we need ( should not be null due to require component so no need to check )
            agent = GetComponentInChildren<NavMeshAgent>();
            character = GetComponent<ThirdPersonCharacter>();

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
				character.Move (agent.desiredVelocity * .7f, false, false);//@DREW changed to .7 so no run
			} else {
				//we got to the checkpoint
				character.Move (Vector3.zero, false, false);

				//we have to manually check if we are close to THIS checkpoint
				if (Vector3.Distance (target.position,agent.transform.position) <= checkpointRadius) {
					waypointIndex = (waypointIndex + 1) % Waypoints.Count;
					print("next");
					target = Waypoints[waypointIndex];
				}
			}
        }


        public void SetTarget(Transform target)
        {
            this.target = target;
        }
    }
}
