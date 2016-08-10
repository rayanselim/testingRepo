using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{

	public static SceneFader instance;

	[SerializeField]
	private GameObject fadePanel;
	[SerializeField]
	private Animator fadeAnim;
	// Use this for initialization
	void Awake ()
	{
		MakeSingleton ();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void MakeSingleton ()
	{
		if (instance != null) {
			Destroy (gameObject);
		} else {
			instance = this;
			DontDestroyOnLoad (gameObject);
		}
	}

	public void LoadLevel (string level)
	{
		StartCoroutine (FadeInOut (level));
	}

	IEnumerator FadeInOut (string level)
	{
		
		fadePanel.SetActive (true);
		fadeAnim.Play ("FadeIn");

		yield return new WaitForSeconds (.3f);

		Time.timeScale = 1f;

		SceneManager.LoadScene (level);

	

		yield return new WaitForSeconds (.6f);

		fadePanel.SetActive (false);
	}
}
