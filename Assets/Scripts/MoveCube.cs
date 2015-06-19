using UnityEngine;
using System.Collections;

public class MoveCube : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 dir = new Vector3(0f, 0f, 0f);
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			dir = new Vector3 (0f,  1f, 0f);
		} else if (Input.GetKeyDown (KeyCode.DownArrow)) {
			dir = new Vector3 (0f, -1f, 0f);
		} else if (Input.GetKeyDown (KeyCode.RightArrow)) {
			dir = new Vector3 ( 1f, 0f, 0f);
		} else if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			dir = new Vector3 (-1f, 0f, 0f);
		} else {
			return;
		}
		transform.position += dir;
	}
}
