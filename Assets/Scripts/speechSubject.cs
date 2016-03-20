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
	RectTransform bubbleSize;


	// Use this for initialization
	void Awake () {
		uiElement = GameObject.Find("StoryText");
		uiText = uiElement.GetComponent<Text> ();

//		mr = gameObject.GetComponent<MeshRenderer> ();
//		uiBubble = gameObject.transform.GetChild (0);
//		tm = gameObject.GetComponent<TextMesh> ();
		uiBubbleText = gameObject.GetComponent<Text> ();
		UIBubble = Bubbles.transform.GetComponent<RectTransform> ();
		bubbleSize = gameObject.GetComponent <RectTransform> ();
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
		UIBubble.sizeDelta = new Vector2 (
			LayoutUtility.GetPreferredWidth(bubbleSize) + 20f,
			LayoutUtility.GetPreferredHeight(bubbleSize) + 20f
		);
		float bubbleOffset = UIBubble.sizeDelta.y / 2f + 5f;
		UIBubble.localPosition = new Vector3 (0f, bubbleOffset, 0f);
		bubbleSize.localPosition = new Vector3 (0f, bubbleOffset, 0f);
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
