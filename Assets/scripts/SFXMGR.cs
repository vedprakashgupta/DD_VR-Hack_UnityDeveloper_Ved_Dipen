using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SFXMGR : MonoBehaviour
{
	public static SFXMGR instance;
	public AudioSource _playerFire;
	// Use this for initialization
	void Awake ()
	{
		instance = this;

	}

	//Below Code iS For Firing BY Player
	public void PlayPlayerFire ()
	{
		_playerFire.Play ();
	}
}
