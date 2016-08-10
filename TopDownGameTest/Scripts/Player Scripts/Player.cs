using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed = 8f, maxVelocity = 4f;
	private Rigidbody2D playerBody;
	private Animator anim;

	// Use this for initialization
	void Awake () {
		playerBody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.timeScale == 1f){
		PlayerMoveKyeboard ();
		}
	}

	void PlayerMoveKyeboard()
	{
		float forceX = 0f;
		float vel = Mathf.Abs (playerBody.velocity.x);

		float h = Input.GetAxisRaw ("Horizontal");

		if (h > 0) {
			if (vel < maxVelocity) {
				forceX = speed; 
				Vector3 temp = transform.localScale;
				temp.x = 1.3f;
				transform.localScale = temp;

				anim.SetBool ("Walk", true);

			}
			
		} else if (h < 0) {
			if (vel < maxVelocity) {
				forceX = -speed;
				Vector3 temp = transform.localScale;
				temp.x = - 1.3f;
				transform.localScale = temp;

				anim.SetBool ("Walk", true);

			}
		} else {
			anim.SetBool ("Walk", false);
		}
		playerBody.AddForce (new Vector2 (forceX, 0));
	}
}
