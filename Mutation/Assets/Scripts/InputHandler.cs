using UnityEngine;
using System.Collections;

public class InputHandler : MonoBehaviour {
    GameObject avatar;
    GameObject avatarPanel;
    float avatarWidth;
    float rotationSpeed = 2;
    bool avatarZoomed = false;
	// Use this for initialization
	void Start () {
        avatar = GameObject.Find("Avatar");
        avatarPanel = GameObject.Find("AvatarPanel");
        avatarWidth = Screen.width / 3;
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("Screen: " + Screen.width + ", " + Screen.height);
        if (Input.touchCount > 0)
        {
            for(int i = 0; i < Input.touchCount; i++)
            {
                Touch currentTouch = Input.GetTouch(i);
                //Avatar rotation and zooming
                if (currentTouch.position.x <= avatarWidth)
                {
                    switch (currentTouch.phase)
                    {
                        case TouchPhase.Moved:
                            avatar.transform.Rotate(currentTouch.deltaPosition.y * rotationSpeed, -currentTouch.deltaPosition.x * rotationSpeed, 0, Space.World);
                            break;
                        case TouchPhase.Ended:
                            if (currentTouch.tapCount > 1)
                            {
                                if (avatarZoomed)
                                    avatar.transform.position += new Vector3(0, 0, 2);
                                else
                                    avatar.transform.position += new Vector3(0, 0, -2);
                                avatarZoomed = !avatarZoomed;
                            }
                            break;
                    }
                }
            }
        }
	
	}
}
