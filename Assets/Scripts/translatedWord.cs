using UnityEngine;
using System.Collections;

[System.Serializable]
public class translatedWord{
        public string korean;
        public string english;

    public translatedWord(string englishWord, string koreanWord)
    {
        korean = koreanWord;
        english = englishWord;
    }
}
