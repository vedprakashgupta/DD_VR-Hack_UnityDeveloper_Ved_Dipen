using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingMechanism : MonoBehaviour 
{
	public Rigidbody _rbody;
	public GameObject _bullet;
	public float _speed;

	void Update () 
	{
		if (OVRInput.GetDown(OVRInput.Button.DpadUp)|| Input.GetKeyDown(KeyCode.D)) 
		{
			SFXMGR.instance.PlayPlayerFire ();
			Shoot ();
		}
	}

	void Shoot()
	{
		var b = (GameObject)Instantiate (_bullet, transform.position, Quaternion.identity);
		b.SetActive (true);
		b.GetComponent<Rigidbody> ().AddForce (Camera.main. transform.forward*Time.deltaTime*_speed*1000f);
		Debug.Log ("destroyed");
		Destroy (b,5f);
	}
}
