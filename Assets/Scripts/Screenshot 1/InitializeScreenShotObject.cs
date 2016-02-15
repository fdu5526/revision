using UnityEngine;
using System.Collections;

public class InitializeScreenShotObject : MonoBehaviour {

	public void InitializeScreenShot(Material newMaterial) {
        GetComponent<Renderer>().material = newMaterial;
    }
}
