using UnityEngine;
using System.Collections;

public class BackgroundScroller : MonoBehaviour {

	public Vector2 speed;
	private Vector2 offset;

	private Material waterMaterial;

	// Use this for initialization
	void Start () {
		waterMaterial = GetComponent<Renderer> ().material;
		offset = waterMaterial.GetTextureOffset ("_MainTex");
	}

	// Update is called once per frame
	void Update () {
		offset += speed * Time.deltaTime;
		waterMaterial.SetTextureOffset ("_MainTex",offset);
	}
}
