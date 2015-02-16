using UnityEngine;
using System.Collections;

public class PlayerMouvement : MonoBehaviour {

	public int speedMultiplier = 5;
	private Vector3 direction = Vector3.zero;
	public int maxJumpHeight = 20;
	private int jumpHeight = 0;
	public RuntimeAnimatorController walkLeftController;
	public RuntimeAnimatorController walkRightController;
	private static CharacterController controller;// = GetComponent<CharacterController>();
	private static Animator anim;
	public GameObject camera;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		controller = GetComponent<CharacterController>();
		anim = GetComponent<Animator> ();

		if (Input.GetKey ("right")) {
			anim.runtimeAnimatorController = walkRightController;
			anim.enabled = true;
			this.gameObject.transform.Translate(Vector3.right * Time.deltaTime * speedMultiplier);
		}
		else if (Input.GetKey ("left") && (gameObject.transform.position.x > (camera.transform.position.x - 7))) {
			anim.runtimeAnimatorController = walkLeftController;
			anim.enabled = true;
			this.gameObject.transform.Translate(Vector3.left * Time.deltaTime * speedMultiplier);
		}

		if (!(Input.GetKey ("right")) && !(Input.GetKey ("left"))) {
			anim.enabled = false;
		}

		if (Input.GetKey ("space") && rigidbody2D.velocity.y == 0) {
			jumpHeight = maxJumpHeight;
		}

		if (jumpHeight > 0) {
			gameObject.transform.Translate (Vector3.up * Time.deltaTime * jumpHeight);
			jumpHeight--;
		}
	}

	void OnGUI () {
		if (transform.position.y < -10) {
				GUI.Box (new Rect (Screen.width / 2 - 50, Screen.height / 2 - 10, 100, 20), "You Failed");
		}
	}
}