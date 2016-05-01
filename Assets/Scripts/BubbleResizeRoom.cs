using UnityEngine;
using System.Collections;

public class BubbleResizeRoom : MonoBehaviour {

    MeshRenderer mr; 
    Vector3 speechBubbleSize;
    Transform textBubble;


    void Start(){
        mr = gameObject.GetComponent<MeshRenderer> ();
        textBubble = gameObject.transform.GetChild (0);
    }

    public void resizeBubs() { 
        if (mr.bounds.extents.x != 0) {
            speechBubbleSize = new Vector3 (mr.bounds.extents.x * 2f + 3f, 
                mr.bounds.extents.y * 2f + 2f, 
                0f);
        } else if (mr.bounds.extents.x == 0) {
            speechBubbleSize = new Vector3 (0f, 0f, 0f);
        }
        textBubble.localScale = speechBubbleSize;
    }

}
