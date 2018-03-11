using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnParticleCollision(GameObject other) {
		Debug.Log ("fire_by player");
		if (other.gameObject.name.Contains ("Shooting")) {
			Debug.Log ("fire_by player");
			other.GetComponent<UnitySampleAssets.Characters.ThirdPerson.AICharacterControl> ().Die ();
		}
	}
}
