using UnityEngine;
using System.Collections;

public class PlayerMoveJoystick : MonoBehaviour {

	public float speed = 8f, maxVelocity = 4f;
	private Rigidbody2D playerBody;
	private Animator anim;

	private bool moveLeft, moveRight;
	// Use this for initialization
	void Awake () {
		playerBody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}

	void FixedUpdate()
	{
		if (moveLeft) {
			
			MoveLeft ();
		}
		if (moveRight) {
			MoveRight ();
		}
	}

	public void SetMoveLeft(bool moveLeft)
	{
		this.moveLeft = moveLeft;
		this.moveRight = !moveLeft;
	}

	public void StopMoving()
	{
		moveLeft = moveRight = false;
		anim.SetBool ("Walk", false);
	}

	void MoveLeft ()
	{
		float forceX = 0f;
		float vel = Mathf.Abs (playerBody.velocity.x);
		if (vel < maxVelocity) {
			forceX = -speed; 
			Vector3 temp = transform.localScale;
			temp.x = -1.3f;
			transform.localScale = temp;

			anim.SetBool ("Walk", true);
			playerBody.AddForce (new Vector2 (forceX, 0));
		}
	}
	void MoveRight ()
	{
		float forceX = 0f;
		float vel = Mathf.Abs (playerBody.velocity.x);
		if (vel < maxVelocity) {
			forceX = speed; 
			Vector3 temp = transform.localScale;
			temp.x = 1.3f;
			transform.localScale = temp;

			anim.SetBool ("Walk", true);
			playerBody.AddForce (new Vector2 (forceX, 0));
		}
	}
	// Update is called once per frame

}
