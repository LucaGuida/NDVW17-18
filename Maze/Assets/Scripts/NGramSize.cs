using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NGramSize : MonoBehaviour {

		public PlayerScript playerScript;
		Vector3 originalScale;

		// Use this for initialization
		int windowSize = 3;

		void Start () {
			originalScale=transform.localScale;
			setText();
		}

		// Update is called once per frame
		void Update () {

		}
		// Swicth between bi - and trigram
		void OnMouseUp() {
		if (windowSize == 3)
			windowSize -= 1;
		else
			windowSize += 1;
			setText();
		}
		void OnMouseOver (){
			transform.localScale = originalScale*1.1f;	
		}
		void OnMouseExit (){
			transform.localScale = originalScale;	
		}

	// set the text for game feedback regarding the n-gram
	void setText ()
		{
		string AI = "";
		if (windowSize==2) AI = "Standard AI (2-gram ON)";
		else AI = "Advanced AI (3-gram ON)";
			transform.GetComponentInChildren<TextMesh>().text = AI;
		}
	}
