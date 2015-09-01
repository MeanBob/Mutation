using UnityEngine;
using System.Collections;

public class ButtonFeedback : MonoBehaviour {
	//Vector3 scale = new Vector3(.1,0,.1);
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ButtonPress()
	{
		StartCoroutine (UpAndDown());
		//transform.localScale += new Vector3(0.1f, 0.1f, 1);
	}
	IEnumerator UpAndDown ()
	{
		transform.localScale = Vector3.Lerp (transform.localScale, new Vector3(0.5f, 0.5f, 1), 0.2f);
		yield return new WaitForSeconds (0.2f);
		transform.localScale = Vector3.Lerp (transform.localScale, new Vector3(1f, 1f, 1), 2f);

	}

}

//aliveArea.transform.localScale = Vector3.Lerp (aliveArea.Transform.localScale, scale, Time.deltaTime);