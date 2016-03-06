using UnityEngine;
using System.Collections;

public class TranslateMaster : MonoBehaviour {
	public GameObject panel;
	public Dictionary myDictionary;
	public static bool pause = false;

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

}
