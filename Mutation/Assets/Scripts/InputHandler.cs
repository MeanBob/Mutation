using UnityEngine;
using System.Collections;

public class InputHandler : MonoBehaviour {
    GameObject avatar;
    float rotationSpeed = 1;
	// Use this for initialization
	void Start () {
        avatar = GameObject.Find("Avatar");
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.touchCount > 0)
        {
            for(int i = 0; i < Input.touchCount; i++)
            {
                Touch currentTouch = Input.GetTouch(i);
                Debug.Log("Touch Delta: " + currentTouch.deltaPosition);
                switch (currentTouch.phase)
                {
                    case TouchPhase.Moved:
                        avatar.transform.Rotate(currentTouch.deltaPosition.y * rotationSpeed, -currentTouch.deltaPosition.x * rotationSpeed, 0, Space.World);
                        break;
                }
            }
        }
	
	}
}
