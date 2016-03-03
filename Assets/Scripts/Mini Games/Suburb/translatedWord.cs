using UnityEngine;
using System.Collections;

[System.Serializable]
public class translatedWord{
        public string korean;
        public string english;
		public Color rightColor;	
		public string[] wrongTranslation;	
		public Color wrongColor;
		

	public translatedWord(string englishWord, string koreanWord, string wrongWord)
    {
        korean = koreanWord;
        english = englishWord;
    }
}
