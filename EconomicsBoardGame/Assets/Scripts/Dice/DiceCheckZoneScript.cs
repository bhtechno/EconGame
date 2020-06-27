using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceCheckZoneScript : MonoBehaviour {


	// 0: holds dice1 velocity, 1: dice2 velocity
	private Vector3[] diceVelocities;
	public DiceScript dice1;
	public DiceScript dice2;

	private DiceManager diceManager;

	private void Awake() {
		diceManager = this.GetComponentInParent<DiceManager>();
		diceVelocities = new Vector3[2];
	}

	// Update is called once per frame
	void FixedUpdate () {
		diceVelocities[0] = dice1.diceVelocity;
		diceVelocities[1] = dice2.diceVelocity;
	}

	/* if we the collision between the spheres around the dice collide with the
	*	area beow the board for several frames, we enter this function.
	*	I check for both dices if they are the ones who are colliding
	*
	*/
	void OnTriggerStay(Collider col)
	{
		DiceValue(0, col);
		DiceValue(1, col);
	}

	/* Thus function receives the dice number to check its velocity, and recieves the
	*	collision object to determine what is collided with.
	*	it will find what dice value based on that, and set it for the dice manager
	*/
	public void DiceValue(byte diceNumber, Collider col) {
		if (diceVelocities[diceNumber].x == 0f && diceVelocities[diceNumber].y == 0f
			&& diceVelocities[diceNumber].z == 0f && col.enabled)
		{
			switch (col.gameObject.name) {
			case "Side1":
				DiceManager.setDice(6);
				break;
			case "Side2":
				DiceManager.setDice(5);
				break;
			case "Side3":
				DiceManager.setDice(4);
				break;
			case "Side4":
				DiceManager.setDice(3);
				break;
			case "Side5":
				DiceManager.setDice(2);
				break;
			case "Side6":
				DiceManager.setDice(1);
				break;
			}
			col.enabled = false;
		}
	}


}
