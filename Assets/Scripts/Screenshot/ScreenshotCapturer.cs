/*
 * Written by Dave Yan and Thomas Lu
 * captures screenshot, save it into a folder
 *
 * attach this to some gameObject in each scene that needs to have screenshot capability
 * make sure to set the public int levelNumber in unity editor
 *
 */
using UnityEngine;
using System.Collections;


public class ScreenshotCapturer : MonoBehaviour {

	public int levelNumber;
	string folderPath;

	void Start () {
		folderPath = Application.dataPath + "/Resources/Screenshots/";
	}

	public void TakeScreenshot () {
		System.IO.Directory.CreateDirectory(folderPath);
		string pathName = folderPath + "level" + levelNumber + ".png";
    	Application.CaptureScreenshot(pathName);
	}
	
	// Update is called once per frame
	void Update () {
//		if (Input.GetKeyDown("space")) {
//			TakeScreenshot();
//		}
	}
}
