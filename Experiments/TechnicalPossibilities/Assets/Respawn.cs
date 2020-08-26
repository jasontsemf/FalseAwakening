using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Respawn : MonoBehaviour {

	public GameObject blackImg;
	public Image img;


	// Use this for initialization
	void Start () {
		img = blackImg.GetComponent<Image>();
		Debug.Log (img.color.a);
		
	}

	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider other) {
		Debug.Log ("on trigger enter");
		int spawnPointX = Random.Range (4, -4);
		int spawnPointY = Random.Range (4, -4);
		GameObject person = other.gameObject;
		person.transform.position = new Vector3 (spawnPointX, 5, spawnPointY);
		StartCoroutine ("FadeOut");
	}

	IEnumerator FadeOut (){
		for (float f = 0f; f <= 1; f += 0.1f) {
			Color c = img.color;
			c.a = f;
			img.color = c;
			yield return new WaitForSeconds(.01f);
		}
		StartCoroutine ("FadeIn");
	}

	IEnumerator FadeIn () {
		for (float f = 1f; f >= -1; f -= 0.1f) {
			Color c = img.color;
			c.a = f;
			img.color = c;
			yield return new WaitForSeconds(.01f);
		}
	}


}
