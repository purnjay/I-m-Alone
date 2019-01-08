using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

	//Text
	public Text nametext;
	public Text dialogueText;

	//Boolean
	public bool interacting;

	//Queue
	public Queue<string> sentences;

	//Components
	[Header("Player")]
	[SerializeField]
	GameObject player;

	// Use this for initialization
	void Start () {
		sentences = new Queue<string> ();
		interacting = false;
	}

	void Update(){

		if (interacting) {
			player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;

		} else {
			player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;

		}

	}

	public void StartDialogue(Dialogue dialogue)
	{
		    interacting = true;

			nametext.text = dialogue.name;

			sentences.Clear ();

			foreach (string sentence in dialogue.sentences) {
				sentences.Enqueue (sentence);
			}

			DisplayNextSentence ();
	}

	public void DisplayNextSentence()
	{
			if (sentences.Count == 0) {
				EndDialogue ();
				return;
			}

			string sentence = sentences.Dequeue ();
			StopAllCoroutines ();
			StartCoroutine (TypeSentence (sentence));

	}

	IEnumerator TypeSentence(string sentence)
	{
		dialogueText.text = "";
		foreach(char letter in sentence.ToCharArray())
		{
			dialogueText.text += letter;
			yield return null;
		}
	}

	public void EndDialogue()
	{
		interacting = false;
		FindObjectOfType<NpcDialogueInteraction> ().talking = false;

	}


}
