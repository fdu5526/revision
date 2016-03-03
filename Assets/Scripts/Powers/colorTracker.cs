using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class colorTracker : Ability {

	public Color[] originalColor;
	public Color[] grayscaleColor;
	public Color specificColor;
	public Color[] currentColor;
	public bool preselectedColor = false;

	public string inputButton;

	int numberOfMaterials;

	// Use this for initialization
	void Start () {
		numberOfMaterials = GetComponent<Renderer>().materials.Length;

		originalColor = new Color[numberOfMaterials];
		grayscaleColor = new Color[numberOfMaterials];
		currentColor = new Color[numberOfMaterials];

//		Debug.Log(numberOfMaterials+" materials");
		//Set variables
		for(int i = 0; i < numberOfMaterials; i++){
		
			originalColor[i] = GetComponent<Renderer>().materials[i].color;
			if(preselectedColor == false){
				float grayscaleValue = maxValue(originalColor[i].r, originalColor[i].g, originalColor[i].b);
				grayscaleColor[i] = new Color(grayscaleValue, grayscaleValue, grayscaleValue);
			}
			if(preselectedColor == true){
				grayscaleColor[i] = specificColor;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	}

	float maxValue(float a, float b, float c){
		float highestValue = a;

		if (a < b && b > c){
			highestValue = b;
		}

		if (c>b && c>a){
			highestValue = c;
		}

		return highestValue;

	}

	public IEnumerator switchColors(bool grayscaleOn){
		
		float elapsedTime = 0.0f;
		float totalTime = 3.0f;
		Color[] targetColors = new Color[numberOfMaterials];

		if(grayscaleOn == true){
			for(int i=0; i < numberOfMaterials; i++){
				targetColors[i] = grayscaleColor[i];
			}
		}
		if(grayscaleOn == false){
			for(int i=0; i < numberOfMaterials; i++){
				targetColors[i] = originalColor[i];
			}
		}

		//yield return null;
//		Color current = GetComponent<Renderer>().material.color;

		while(elapsedTime<totalTime){
			GameButtonMaster.ready = false;
			//			Debug.Log("going");
			for(int j = 0; j < numberOfMaterials; j++){
				Color current = GetComponent<Renderer>().materials[j].color;
				current = Color.Lerp(current, targetColors[j], (elapsedTime / (totalTime*4f)));
				GetComponent<Renderer>().materials[j].color = current;
			}

			elapsedTime+=Time.deltaTime;
			
			if(elapsedTime>totalTime){
				//Debug.Log("done");
				for(int j = 0; j < numberOfMaterials; j++){
				GetComponent<Renderer>().materials[j].color = targetColors[j];
				}
				GameButtonMaster.ready = true;
			}
		
			yield return null;
		}

	}

    public void orderedToChange(bool grayscaleOn)
    {
        StartCoroutine(switchColors(grayscaleOn));
		}
}
