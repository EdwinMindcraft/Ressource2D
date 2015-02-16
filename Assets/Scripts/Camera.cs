using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (this.gameObject.transform.position.x < player.transform.position.x) {
			float camx = player.transform.position.x;
			float camy = transform.position.y;
			float camz = transform.position.z;
			Vector3 newPos = new Vector3(camx,camy,camz);
			transform.position = newPos;
		}
	}
}
