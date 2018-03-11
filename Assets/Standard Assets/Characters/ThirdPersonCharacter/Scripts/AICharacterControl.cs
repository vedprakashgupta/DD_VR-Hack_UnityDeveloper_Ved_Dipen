using UnityEngine;
using System;
namespace UnitySampleAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof (UnityEngine.AI.NavMeshAgent))]
    [RequireComponent(typeof (ThirdPersonCharacter))]
    public class AICharacterControl : MonoBehaviour
    {

        public UnityEngine.AI.NavMeshAgent agent { get; private set; } // the navmesh agent required for the path finding
        public ThirdPersonCharacter character { get; private set; } // the character we are controlling
        public Transform target; // target to aim for
        public float targetChangeTolerance = 1; // distance to target before target can be changed

        private Vector3 targetPos;
		float _timer=0f;

		public GameObject _fireRocket;
		bool _isDied;
        // Use this for initialization
        private void Start()
        {
            // get the components on the object we need ( should not be null due to require component so no need to check )
            agent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();
            character = GetComponent<ThirdPersonCharacter>();
        }


        // Update is called once per frame
        private void Update()
        {
			//agent.stoppingDistance=
			//if (Vector3.Distance (transform.position, target.position) > 100f) 
			{
				//print (Vector3.Distance (transform.position, target.position)+"");
				if (target != null) {
					// update the progress if the character has made it to the previous target
					if ((target.position - targetPos).magnitude > targetChangeTolerance) {
						targetPos = target.position;
						agent.SetDestination (targetPos);
					}

					// update the agents posiiton 
					agent.transform.position = transform.position;

					// use the values to move the character
					character.Move (agent.desiredVelocity, false, false, targetPos);
				} else {
					// We still need to call the character's move function, but we send zeroed input as the move param.
					character.Move (Vector3.zero, false, false, transform.position + transform.forward * 100);

				}
			} 
//			else {
//				//agent.stoppingDistance= 9f;
//				print( Vector3.Distance (transform.position, target.position)+" stopped");
//				agent.isStopped = true;
//				this.GetComponent<ThirdPersonCharacter>().
//			}
			if (agent.velocity.Equals( Vector3.zero)) 
			{
				transform.LookAt (target.transform);

				if (_timer >= 3f)
				{
					Fire ();
 					_timer = 0f;
				}
				else 
				{
					_timer += Time.deltaTime;
				}
			}

			if (_isDied) 
			{
				var h = transform.position.y;
				h = Mathf.Clamp (h,227f,500f);
				transform.position = new Vector3 (transform.position.x,h,transform.position.z);
			}
        }

		public void Die()
		{
			GetComponent<Animator> ().SetTrigger ("die");
			_fireRocket.SetActive (false);
		}
		void Fire()
		{
			_fireRocket.SetActive (true);
		}

        public void SetTarget(Transform target)
        {
            this.target = target;
        }

		void OnTriggerEnter(Collider other)
		{
			if (other.tag == "playerbullet") {
				Debug.Log ("getting bullet");
				Die ();
				_isDied = true;
				transform.GetComponent<CapsuleCollider> ().height = 0f;
				transform.GetComponent<AICharacterControl> ().enabled = false;
				transform.GetComponent<Rigidbody> ().useGravity = true;
				transform.GetComponent<UnityEngine.AI.NavMeshAgent> ().enabled = false;
				Destroy (other.gameObject);
				Destroy (this.gameObject, 1.5f);
			}
		}


    }

}
