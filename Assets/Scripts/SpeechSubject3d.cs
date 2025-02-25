﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpeechSubject3d : MonoBehaviour {
    public GameObject uiElement;
    Text uiCharacterText;
    Text uiText;
    Vector3 speechBubbleSize;
    TextMesh uiBubbleText;
//    [SerializeField] bool _isBubble;

//    [SerializeField] GameObject Bubbles;
//    [SerializeField] Image bubbleImage;
//    [SerializeField] Image bubbleTail;
//    RectTransform UIBubble;
//    RectTransform bubbleSize;
    BubbleResizeRoom speechResizeScript;
    [SerializeField] SpriteRenderer _tail;

    [SerializeField] string characterCheck;
    //  [SerializeField] GameObject uiElement;
    //    [SerializeField] Text uiCharacterText;
    //    Text uiText;
    //for disabling/enabling speech bubble

    // Use this for initialization
    void Awake () {
        _tail.enabled = false;
        if (uiElement == null) {

            uiElement = GameObject.Find ("StoryText");
        }
        uiCharacterText = GameObject.Find("NameText").GetComponent <Text>();
        uiText = uiElement.GetComponent<Text> ();

        uiBubbleText = gameObject.GetComponent<TextMesh> ();
        speechResizeScript = gameObject.GetComponentInChildren<BubbleResizeRoom> ();

//        UIBubble = Bubbles.transform.GetComponent<RectTransform> ();
//        bubbleSize = gameObject.GetComponent <RectTransform> ();
    }

    // Update is called once per frame
    void Update () {
        if (uiText.IsActive() && (uiCharacterText.text == characterCheck )) {
//            enableBubble ();
            if (uiBubbleText.text != uiText.text) {
                uiBubbleText.text = uiText.text;
                _tail.enabled = true;
                resizeSpeech ();
//                if (_isBubble) {
//                    resizeUIBubs ();
//                }
            }
        } else {
            uiBubbleText.text = "";
            _tail.enabled = false;
            resizeSpeech ();
//            disableBubble ();
        }
    }

//    void resizeUIBubs() {
//        float tempWidth = LayoutUtility.GetPreferredWidth(bubbleSize)>300 ? 300f : LayoutUtility.GetPreferredWidth(bubbleSize);
//
//        UIBubble.sizeDelta = new Vector2 (
//            tempWidth + 20f,
//            LayoutUtility.GetPreferredHeight(bubbleSize) + 20f
//        );
//        float bubbleOffset = UIBubble.sizeDelta.y / 2f + 5f;
//        UIBubble.localPosition = new Vector3 (0f, bubbleOffset, 0f);
//        bubbleSize.localPosition = new Vector3 (0f, bubbleOffset, 0f);
//    }

//    void disableBubble() {
//        uiBubbleText.enabled = false;
//        if(bubbleTail != null){
//            bubbleTail.enabled = false;
//        }
//        bubbleImage.enabled = false;
//    }
//
//    void enableBubble() {
//        uiBubbleText.enabled = true;
//        if(bubbleTail != null){
//            bubbleTail.enabled = true;
//        }
//        bubbleImage.enabled = true;
//    }
    void resizeSpeech()
    {
        if (speechResizeScript != null) {
            speechResizeScript.resizeBubs ();
        }
    }
}
