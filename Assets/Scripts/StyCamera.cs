using UnityEngine;
using System.Collections;

public class StyCamera : MonoBehaviour
{
	public float smooth = 2.0f;
	public float tiltAngle = 10.0f;

	private float _rotDefaultX = 0f;
	private float _rotDefaultY = 0f;
	private float _rotDefaultZ = 0f;
	private float _inputDefaultX = 0f;
	private float _inputDefaultY = 0f;
	private float _inputDefaultZ = 0f;
	private Quaternion _targetRot = Quaternion.identity;

	// Use this for initialization
	void Start ()
	{
		_rotDefaultX = transform.eulerAngles.x;
		_rotDefaultY = transform.eulerAngles.y;
		_rotDefaultZ = transform.eulerAngles.z;

		//ResetTilt ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		float accX = Input.acceleration.x;
		float accY = Input.acceleration.y;
		Debug.Log (Screen.orientation+"x: "+accX + "y: "+accY + "z: "+Input.acceleration.z);
		float tiltAroundY = -(accX - _inputDefaultX) * tiltAngle;//Input.GetAxis("Horizontal") * tiltAngle;
		float tiltAroundX = (accY - _inputDefaultY) * tiltAngle;//Input.GetAxis("Vertical") * tiltAngle;
		_targetRot = Quaternion.Euler(tiltAroundX + _rotDefaultX, tiltAroundY + _rotDefaultY, _rotDefaultZ);
	}

	void LateUpdate(){
		transform.rotation = Quaternion.Slerp(transform.rotation, _targetRot, Time.deltaTime * smooth);
	}

	void ResetTilt(){
		_inputDefaultX = Input.acceleration.x;
		_inputDefaultY = Input.acceleration.y;
		_inputDefaultZ = Input.acceleration.z;
	}
}
