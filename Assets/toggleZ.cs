using UnityEngine;
using System.Collections;

public class toggleZ : MonoBehaviour {

    public float originalPosition;
    public float originalScale;
    public float toggledPosition;
    public float toggledScale;
    public bool toggled = false;

    // Use this for initialization
    void Start () {
        originalPosition = transform.position.z;
        originalScale = transform.localScale.z;
	}
	
    public void toggleObject()
    {

        toggled = !toggled;
        StartCoroutine(changeSize());
        
    }

    IEnumerator changeSize()
    {
        Vector3 tempPosition = transform.position;
        Vector3 tempScale = transform.localScale;
        float delay = 0;

        if (toggled)
        {
            tempPosition.z = toggledPosition;
            tempScale.z = toggledScale;
        }

        else
        {
            delay = 3f;
            tempPosition.z = originalPosition;
            tempScale.z = originalScale;
        }

        yield return new WaitForSeconds(delay);
        transform.position = tempPosition;
        transform.localScale = tempScale;
    }
}
