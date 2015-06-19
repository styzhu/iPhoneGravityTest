using UnityEngine;
using System.Collections;

public class StyCamera : MonoBehaviour
{
	public float smooth = 2.0f;
	public float tiltAngle = 20.0f;

	private float _rotDefaultX = 0f;
	private float _rotDefaultY = 0f;
	private float _rotDefaultZ = 0f;

	private float _inputDefaultX = 0f;
	private float _inputDefaultY = 0f;
	private float _inputDefaultZ = 0f;

	// Use this for initialization
	void Start ()
	{
		_rotDefaultX = transform.eulerAngles.x;
		_rotDefaultY = transform.eulerAngles.y;
		_rotDefaultZ = transform.eulerAngles.z;

	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.touchCount > 0) {
			ResetTilt();
		}

		float tiltAroundY = -(Input.acceleration.x - _inputDefaultX) * tiltAngle;//Input.GetAxis("Horizontal") * tiltAngle;
		float tiltAroundX = (Input.acceleration.y - _inputDefaultY) * tiltAngle;//Input.GetAxis("Vertical") * tiltAngle;
		Debug.Log("x: "+tiltAroundX+" y: "+tiltAroundY);
		Quaternion target = Quaternion.Euler(tiltAroundX + _rotDefaultX, tiltAroundY + _rotDefaultY, _rotDefaultZ);
		transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
	}

	void ResetTilt(){
		_inputDefaultX = Input.acceleration.x;
		_inputDefaultY = Input.acceleration.y;
		_inputDefaultZ = Input.acceleration.z;
	}
}
