using UnityEngine;
using System.Collections;

public class TranslateMaster : MonoBehaviour {
	public GameObject panel;
	public Dictionary myDictionary;
	public static bool pause = false;
	public static int counter = 0;

	void Start(){
	}

	public void activatePanel(string WordToTranslate){
		panel.SetActive(true);
		translatedWord tempWORD = null;
		for(int i =0; i < myDictionary.word.Length; i++){
			if(myDictionary.word[i].english == WordToTranslate){
				tempWORD = myDictionary.word[i];
			}
		}
		panel.GetComponent<PanelSetup>().ArrangePanel(tempWORD);
	}

    public void activatePanel_ENGtoKR(string WordToTranslate)
    {
        panel.SetActive(true);
        translatedWord tempWORD = null;
        for (int i = 0; i < myDictionary.word.Length; i++)
        {
            if (myDictionary.word[i].english == WordToTranslate)
            {
                tempWORD = myDictionary.word[i];
            }
        }
        panel.GetComponent<PanelSetup>().ArrangePanel_ENGtoKR(tempWORD);
    }

    public static void upCounter(){
		if (counter < 9) {
			counter++;
		}
	}

}
