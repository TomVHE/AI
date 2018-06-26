using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_TV : Item_Base {

	[Header ("Positive effect")]
	public float fun = 50f;

	[Header ("Negative effects")]
	public float hunger = 10f;
	public float bladder = 10f;
	public float dirtiness = 10f;
	public float energy = 10f;

	// Add this item to the correct list in Manager.
	public override void Start () {
		AddToManager (Manager.funItems);
	}

	// The effect using this item has.
	public override void Effect (AI _ai) {
		// Positive effect.
		_ai.fun.Reset (fun);

		// Negative effects.
		_ai.fullness.Reset (hunger);
		_ai.emptyBladder.Reset (bladder);
		_ai.hygiene.Reset (dirtiness);
		_ai.energy.Reset (energy);
	}

}