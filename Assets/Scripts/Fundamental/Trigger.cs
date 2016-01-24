using UnityEngine;
using System.Collections;

public enum Action {instantiate, activate, deactivate, destroy};

[System.Serializable]
public class interactionType{

	public GameObject targetObject;
	public Action actionType;
}

public class Trigger : MonoBehaviour {
	public string triggerTag;
	public interactionType[] interactions;
	public bool oneTimeUse=true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		Debug.Log("Entered trigger box");
	if(other.tag == triggerTag){
			Debug.Log("Has tag of: "+triggerTag);
			for(int i=0; i<interactions.Length; i++){
				Action myAction = interactions[i].actionType;

				switch(myAction)
				{
				case Action.instantiate:
					GameObject tempGO = Instantiate(interactions[i].targetObject) as GameObject;
					break;
				case  Action.activate:
					interactions[i].targetObject.SetActive(true);
					break;
				case  Action.deactivate:
					interactions[i].targetObject.SetActive(false);
					break;
				case  Action.destroy:
					GameObject.Destroy(interactions[i].targetObject);
					break;
				default:
					Debug.Log("Trigger ineffective");
					break;
				}
			}

			if(oneTimeUse){
				gameObject.SetActive(false);
			}
		}
	}
}
