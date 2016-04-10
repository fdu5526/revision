using UnityEngine;
using System.Collections;
using Giverspace; // Needed to get access to logging

public enum AfterAction {instantiate, activate, deactivate, destroy, noted};

[System.Serializable]
public class interactionType{

	public GameObject targetObject;
	public AfterAction actionType;
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
		Debug.Log("Has tag of: "+triggerTag);
	if(other.tag == triggerTag){
			Log.Metrics.Message("Trigger-" + this.gameObject.name);
			Debug.Log("Has tag of: "+triggerTag);
			for(int i=0; i<interactions.Length; i++){
                AfterAction myAction = interactions[i].actionType;

				switch(myAction)
				{
				case AfterAction.instantiate:
					GameObject tempGO = Instantiate(interactions[i].targetObject) as GameObject;
					break;
				case AfterAction.activate:
					interactions[i].targetObject.SetActive(true);
					break;
				case AfterAction.deactivate:
					interactions[i].targetObject.SetActive(false);
					break;
				case AfterAction.destroy:
					GameObject.Destroy(interactions[i].targetObject);
					break;
				case AfterAction.noted:
					noteProgress noteTracker = GameObject.FindObjectOfType<noteProgress>();
					if(noteTracker !=null){
						noteTracker.addNote();
					}
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
