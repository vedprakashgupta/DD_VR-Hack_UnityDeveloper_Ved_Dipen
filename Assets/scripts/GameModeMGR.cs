using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameModeMGR : MonoBehaviour
{
	public static GameModeMGR instance;
	// Use this for initialization
	public bool _trainingMode;

	void Awake ()
	{
		instance = this;
	}

	// Update is called once per frame
	void Update ()
	{
		if (OVRInput.GetDown (OVRInput.Button.One) || Input.GetKeyDown (KeyCode.N)) {
			if (_trainingMode)
				SceneManager.LoadScene ("1");
		}
	}

	public bool CheckTheMode ()
	{
		return _trainingMode;
	}
}
