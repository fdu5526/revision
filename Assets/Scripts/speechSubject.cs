using UnityEngine;
using UnityEngine.UI;
using System.Collections;
	
public class speechSubject : MonoBehaviour {
	GameObject uiElement;
	Text uiText;
//	MeshRenderer mr; 
//	TextMesh tm;
	Vector3 speechBubbleSize;
//	Transform uiBubble;
	Text uiBubbleText;
	[SerializeField] GameObject Bubbles;
	RectTransform UIBubble;


	// Use this for initialization
	void Awake () {
		uiElement = GameObject.Find("StoryText");
		uiText = uiElement.GetComponent<Text> ();

//		mr = gameObject.GetComponent<MeshRenderer> ();
//		uiBubble = gameObject.transform.GetChild (0);
//		tm = gameObject.GetComponent<TextMesh> ();
		uiBubbleText = gameObject.GetComponent<Text> ();
		UIBubble = Bubbles.transform.GetComponent<RectTransform> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (uiText.IsActive()) {
//			tm.text = uiText.text;
			//UI TEXT
			if (uiBubbleText.text != uiText.text) {
				uiBubbleText.text = uiText.text;
				resizeUIBubs ();
			}

		} else {
//			tm.text = "";

			//UI TEXT
			uiBubbleText.text = "";
			gameObject.transform.parent.gameObject.SetActive (false);

//			resizeBubs ();
		}
	}
		
	void resizeUIBubs() {
		Bubbles.GetComponent <RectTransform>().sizeDelta = new Vector2 (300, LayoutUtility.GetPreferredHeight(gameObject.GetComponent <RectTransform>()));

	}
//	public void resizeBubs() { 
//		if (mr.bounds.extents.x != 0) {
//			speechBubbleSize = new Vector3 (mr.bounds.extents.x * 2f + 5f, 
//				mr.bounds.extents.y * 2f + 1f, 
//				0f);
//		} else if (mr.bounds.extents.x == 0) {
//			speechBubbleSize = new Vector3 (0f, 0f, 0f);
//		}
//		uiBubble.localScale = speechBubbleSize;
//	}
}
