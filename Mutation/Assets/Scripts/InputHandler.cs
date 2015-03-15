using UnityEngine;
using System.Collections;

public class InputHandler : MonoBehaviour {
    GameObject avatar;
    GameObject avatarPanel;
    Vector2 lastMousePosition;
    float avatarWidth;
    float rotationSpeed = 2;
    bool avatarZoomed = false;
	// Use this for initialization
	void Start () {
        avatar = GameObject.Find("Avatar");
        avatarPanel = GameObject.Find("AvatarPanel");
        avatarWidth = Screen.width / 3;
        lastMousePosition = Input.mousePosition;
	}
	
	// Update is called once per frame
	void Update () {

        if (Application.platform == RuntimePlatform.Android
            || Application.platform == RuntimePlatform.IPhonePlayer)
        {
            if (Input.touchCount > 0)
            {
                for (int i = 0; i < Input.touchCount; i++)
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

        else
        {
            Vector2 currentMousePosition = Input.mousePosition;
            if (Input.GetMouseButton(0))
            {
                if (Input.mousePosition.x <= avatarWidth)
                {
                    avatar.transform.Rotate((currentMousePosition.y - lastMousePosition.y) * rotationSpeed, (currentMousePosition.x - lastMousePosition.x) * rotationSpeed, 0, Space.World);
                }
            }
            lastMousePosition = currentMousePosition;
        }
	}
}
