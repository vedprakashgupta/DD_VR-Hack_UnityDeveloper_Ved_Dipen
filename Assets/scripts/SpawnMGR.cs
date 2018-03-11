using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
public class SpawnMGR : MonoBehaviour
{
	public static SpawnMGR instance;
	public GameObject _enemy;
	public GameObject[] _cubes;
	public float _time;
	public float minDistance;
	public GameObject _positions;
	public Text _fpsText;



	void Awake()
	{
		instance = this;
	}
	// Use this for initialization
	void Start () {
		StartCoroutine (waitandspawn());
		if (GameModeMGR.instance.CheckTheMode ())
			return;
		 Instantiate( Resources.Load<GameObject> ("terrain"));

	}



	// Update is called once per frame
	void Update () {
	//	_fpsText.text = Mathf.RoundToInt( (1 / Time.deltaTime)).ToString ();
	}

	IEnumerator waitandspawn()
	{
		while (true) {
			yield return new WaitForSeconds (_time);
			List<GameObject> temp= _cubes.Where (c => Vector3.Distance (c.transform.position, PlayerMGR.instance.transform.position) > minDistance).ToList ();
			var g = Instantiate (_enemy,temp[Random.Range(0,temp.Count)].transform.position, Quaternion.identity);
			g.SetActive (true);
			g.GetComponent< UnitySampleAssets.Characters.ThirdPerson.AICharacterControl> ().SetTarget (PlayerMGR.instance.transform);
		}
	}
}
