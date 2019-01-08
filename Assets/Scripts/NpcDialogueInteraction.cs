using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcDialogueInteraction : MonoBehaviour {

	DialogueTrigger dTrigger;

	public bool talking;

	[SerializeField]
	KeyCode interact;

	void Start(){
		dTrigger = GetComponent<DialogueTrigger> ();
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (!talking && Input.GetKeyDown(interact)) {
			dTrigger.TriggerDialogue ();
			talking = true;
		}
	}

	void OnTriggerStay2D(Collider2D col)
	{
		if (!talking && Input.GetKeyDown(interact)) {
			dTrigger.TriggerDialogue ();
			talking = true;
		}
	}
}
