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

    public bool ENGtoKR;

    public GameObject wordPrefab;
    public Transform spawnPosition;

    public Transform target;

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

    public void ArrangePanel_ENGtoKR(translatedWord theWord)
    {
        //setup main panel
        background.color = colorProgression[TranslateMaster.counter].rightColor;
        mainText.text = theWord.korean;

        // decide which button is the right one
        int rightButton = (int)Random.Range(0, choices.Length);
        for (int i = 0; i < choices.Length; i++)
        {
            if (i == rightButton)
            {
                choices[i].image.color = colorProgression[TranslateMaster.counter].rightColor;
                choices[i].GetComponentInChildren<Text>().text = theWord.english;
                choices[i].GetComponentInChildren<TranslationChoice>().correct = true;

            }
            else
            {
                choices[i].image.color = colorProgression[TranslateMaster.counter].wrongColor;
                choices[i].GetComponentInChildren<Text>().text = theWord.wrongTranslationEnglish[i];
                choices[i].GetComponentInChildren<TranslationChoice>().correct = false;

            }
        }
    }

    public void ClickObj() {
        if (ENGtoKR) {
            GameObject newTranslatedWord = Instantiate(wordPrefab, spawnPosition.position, spawnPosition.rotation) as GameObject;
            newTranslatedWord.GetComponent<words>().SetTarget(target);
        }
    }
}
