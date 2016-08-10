using UnityEngine;
using System.Collections;

public class BGSCaler : MonoBehaviour {


	private SpriteRenderer sr;

	void Start () {

		SpriteRenderer sr = GetComponent<SpriteRenderer> ();
		float height = Camera.main.orthographicSize * 2;
		float width = height * Screen.width/ Screen.height;

		Sprite s = sr.sprite;

		float unitWidth = s.textureRect.width / s.pixelsPerUnit;
		float unitHeight = s.textureRect.height / s.pixelsPerUnit;

		sr.transform.localScale = new Vector3(width / unitWidth, sr.transform.localScale.y);
		//sr.transform.localScale = new Vector3(width / unitWidth, height / unitHeight);
	
	}


	

}
