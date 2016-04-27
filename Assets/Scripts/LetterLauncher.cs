using UnityEngine;
using System.Collections;

public class LetterLauncher : MonoBehaviour {

    [SerializeField]
    private GameObject _letterPrefab;
    [SerializeField]
    private int _numberOfLines;
    private int _counter = 0;

    [SerializeField]
    private string _wordDisplayed;

    [SerializeField]
    private float _launchDelay;

	// Use this for initialization
	void Start () {
        StartCoroutine(LaunchWords());
    }
	
	// Update is called once per frame
	void Update () {

	}

    IEnumerator LaunchWords() {
        yield return new WaitForSeconds(_launchDelay);
        
        while(true) { 
            GameObject newWord = (GameObject)Instantiate(_letterPrefab, transform.position, Quaternion.identity);
            newWord.GetComponent<GenerateLineOfLetters>().preterminedWord = _wordDisplayed;

            yield return new WaitForSeconds(0.2f);
        }
    }
}
