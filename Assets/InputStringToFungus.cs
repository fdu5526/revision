using UnityEngine;
using System.Collections;
using Fungus;

public class InputStringToFungus : MonoBehaviour {

	public string fungusVariableName;
	public string stringInput;
	public Flowchart targetFlowchart;

	public void updateString(string newString){
		targetFlowchart.SetStringVariable (fungusVariableName, newString);
	}

}
