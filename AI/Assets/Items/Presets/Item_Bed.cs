using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Bed : Item_Base {

	[Header ("Positive effects")]
	public float energy = 50f;
	public float fun = 20f;

	[Header ("Negative effects")]
	public float hunger = 10f;
	public float bladder = 10f;
	public float dirtiness = 10f;

	// Add this item to the correct list in Manager.
	public override void Start () {
		AddToManager (Manager.energyItems);
	}

	// The effect using this item has.
	public override void Effect (AI _ai) {
		// Positive effects.
		_ai.energy.Reset (energy);
		_ai.fun.Reset (fun);

		// Negative effects.
		_ai.fullness.Reset (hunger);
		_ai.emptyBladder.Reset (bladder);
		_ai.hygiene.Reset (dirtiness);
	}

}