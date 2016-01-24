/*
 * Written by Dave Yan and Thomas Lu
 * captures screenshot, save it into a folder
 *
 * attach this to planes in the scene that displays screenshots
 * make sure to set the public int levelNumber in unity editor
 * level number corresponds to the the level this is displaying
 *
 */
 using UnityEngine;
using System.Collections;

public class ScreenshotDisplay : MonoBehaviour {

	public int levelNumber;
	string folderPath;


	// Use this for initialization
	void Start () {
		folderPath = Application.dataPath + "/Resources/Screenshots/";
		LoadScreenshot();
	}


	void LoadScreenshot () {
		byte[] pngBytes;
		Texture2D tex = new Texture2D(2, 2);

		string pathName = folderPath + "level" + levelNumber + ".png";
		Resources.Load(pathName);

    if (System.IO.File.Exists(pathName))
    {
    	byte[] bytes = System.IO.File.ReadAllBytes(pathName);
      tex.LoadImage(bytes);
      GetComponent<Renderer>().material.mainTexture = tex;
    }
	}
}
