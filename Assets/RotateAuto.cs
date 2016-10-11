using UnityEngine;
using System.Collections;

public class RotateAuto : MonoBehaviour {

	public float rotateSpeed = 3f;
	float rotSpeed = 20;
	bool isMouseDragging = false;
	public float timeToWaitForAutoRotate = 1.5f;
	bool isAutoRotating = false;
	float timeToWaitForRotation = 2f;
	float timeStamp;
	bool isBackToOriginalRotation;
	void Start(){
		timeStamp = timeToWaitForAutoRotate + Time.time;
	}
	void OnMouseDown(){
		isMouseDragging = true;


	}
	void OnMouseDrag()
	{
		isBackToOriginalRotation = false;
		float rotX = Input.GetAxis("Mouse X")*rotSpeed*Mathf.Deg2Rad;
		float rotY = Input.GetAxis("Mouse Y")*rotSpeed*Mathf.Deg2Rad;

		transform.RotateAround(Vector3.up, -rotX);
		transform.RotateAround(Vector3.right, rotY);
	}
	void OnMouseUp(){
		isMouseDragging = false;
		timeStamp = timeToWaitForRotation + Time.time;
	}
	void Update(){

		if (!isMouseDragging && timeStamp <= Time.time) {
			
				
				transform.Rotate (Vector3.up * Time.deltaTime * rotateSpeed);


		}

	}




}
