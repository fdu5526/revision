using UnityEngine;
using UnityEngine.UI;
using System.Collections;
	
public class speechSubject : MonoBehaviour {
	GameObject uiElement;
	Text uiText;
	MeshRenderer mr; 
	TextMesh tm;
	Vector3 speechBubbleSize;
	Transform textBubble;


	// Use this for initialization
	void Start () {
		uiElement = GameObject.Find("StoryText");
		uiText = uiElement.GetComponent<Text> ();

		mr = gameObject.GetComponent<MeshRenderer> ();
		textBubble = gameObject.transform.GetChild (0);
		tm = gameObject.GetComponent<TextMesh> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (uiText.IsActive()) {
			tm.text = uiText.text;
			resizeBubs ();
		} else {
			tm.text = "";
			resizeBubs ();
		}
	}
		
	public void resizeBubs() { 
		if (mr.bounds.extents.x != 0) {
			speechBubbleSize = new Vector3 (mr.bounds.extents.x * 2f + 5f, 
				mr.bounds.extents.y * 2f + 1f, 
				0f);
		} else if (mr.bounds.extents.x == 0) {
			speechBubbleSize = new Vector3 (0f, 0f, 0f);
		}
		textBubble.localScale = speechBubbleSize;
	}
}
