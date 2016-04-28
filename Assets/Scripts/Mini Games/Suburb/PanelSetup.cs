using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[System.Serializable]
public class colorPairs{
	public Color rightColor;
	public Color wrongColor;

	colorPairs(Color right, Color wrong){
		rightColor = right;
		wrongColor = wrong;
	}
}

public class PanelSetup : MonoBehaviour {
	public colorPairs[] colorProgression;
	public Button[] choices;
	public Image background;
	public Text mainText;


	// Use this for initialization
	void Start () {
			
	}

	// Update is called once per frame
	void Update () {
	
	}

	public void ArrangePanel(translatedWord theWord){
	//setup main panel
		background.color = colorProgression[TranslateMaster.counter].rightColor;
		mainText.text = theWord.english;

		// decide which button is the right one
		int rightButton = (int)Random.Range(0, choices.Length);
		for(int i =0; i < choices.Length; i++){
			if(i==rightButton){
				choices[i].image.color = colorProgression[TranslateMaster.counter].rightColor;
				choices[i].GetComponentInChildren<Text>().text = theWord.korean;
				choices[i].GetComponentInChildren<TranslationChoice>().correct = true;
		
			}
			else{
				choices[i].image.color = colorProgression[TranslateMaster.counter].wrongColor;
				choices[i].GetComponentInChildren<Text>().text = theWord.wrongTranslation[i];
				choices[i].GetComponentInChildren<TranslationChoice>().correct = false;

			}
		}
	}
}
