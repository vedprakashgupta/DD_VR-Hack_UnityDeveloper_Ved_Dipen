using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
public class PlayerMGR : MonoBehaviour {
	public static PlayerMGR instance;
	public NavMeshAgent _player;
	public Transform _goal;
	public float _speed;
	public GameObject _plrFire;
	public  UnitySampleAssets.Characters.FirstPerson.FirstPersonController _fpc; 
	// Use this for initialization
	void Awake()
	{
		instance = this;
	}

	void Start () 
	{
		//_player.SetDestination (_goal.transform.position);
	}
	
	// Update is called once per frame
	void Update () 
	{
		Controller ();
//
//		if (Input.GetKey (KeyCode.F)) {
//			//Movement ();
//			_fpc._isPressed = true;
//		} else {
//			_fpc._isPressed=false;
//		}
		if (GameModeMGR.instance.CheckTheMode())
			return;
		if (transform.position.y < 100f)
			SceneManager.LoadScene (1);

	}

	void Controller()
	{
		if (OVRInput.IsControllerConnected (OVRInput.Controller.RTrackedRemote)) 
		{
		
		}

		if (OVRInput.Get (OVRInput.Button.One) || Input.GetKey (KeyCode.F)) 
		{

			if (GameModeMGR.instance.CheckTheMode ())
				return;	

			//OVRInput.IsControllerConnected (OVRInput.Controller.RTrackedRemote)+" "+OVRInput.Get(OVRInput.Button.One)
			//
			//UnitySampleAssets.Characters.FirstPerson.FirstPersonController.in = true;

			Movement ();

			//_fpc._isPressed=true;

		} else 
		{
			//_fpc._isPressed=false;
		}


	}

	void Movement()
	{
		transform.position += Camera.main.transform.forward * Time.deltaTime * _speed;
	}
}
