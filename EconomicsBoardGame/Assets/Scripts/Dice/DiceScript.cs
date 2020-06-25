using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceScript : MonoBehaviour {

	Rigidbody rb;
	// public static Vector3 diceVelocity;
	public Vector3 diceVelocity;

	[SerializeField]
	public Vector3 DiceLocation = new Vector3 (0, 2, 0); // The location where the dice throw starts
	private SphereCollider[] diceSphereColliders; // array for the six sphere surrounding the dice to
												  // determine what dice value is received

	private void Awake() {
		diceSphereColliders = GetComponentsInChildren<SphereCollider>();
		rb = GetComponent<Rigidbody>();
	}

	// Use this for initialization
	void Start () {
	}

	/*
	 * every frame, update the dicevelocity from the rigidbody.
	 * TODO: after turn are setup, only run when the dice is being throwed
	*/
	void Update () {
		diceVelocity = rb.velocity;
		// if (Input.GetKeyDown (KeyCode.Space)) {
		// 	ThrowDice();
		// }
	}

	/* after a throw is done, enable the sphere colliders,
	* because they were disabled after getting their value
	*/
	public void ResetThisDice() {
		foreach (var item in diceSphereColliders)
		{
			item.enabled = true;
		}
	}

	/*
	 * Bring the dice to the middle of the board, and then add a random force
	 * and torque for the random effect
	*/
	public void ThrowDice() {
		// DiceNumberTextScript.diceNumber = 0;
		float dirX = Random.Range (0, 500);
		float dirY = Random.Range (0, 500);
		float dirZ = Random.Range (0, 500);
		transform.position = DiceLocation;
		transform.rotation = Quaternion.identity;
		rb.AddForce (transform.up * 500);
		rb.AddTorque (dirX, dirY, dirZ);
	}
}
