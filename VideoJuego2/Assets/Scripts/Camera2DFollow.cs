using UnityEngine;
using System.Collections;

public class Camera2DFollow : MonoBehaviour {
	
	public GameObject target;
	private Transform t;

	
	// Use this for initialization
	void Start () {
		t = target.transform;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (t.position.x, t.position.y, transform.position.z);

	}
}
