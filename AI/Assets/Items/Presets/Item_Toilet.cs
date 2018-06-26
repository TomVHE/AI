using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Toilet : Item_Base {

	[Header ("Positive effects")]
	public float emptyBladder = 50f;
	public float hygiene = 15f;

	[Header ("Negative effect")]
	public float energy;

	// Add this item to the correct list in Manager.
	public override void Start () {
		AddToManager (Manager.emptyBladderItems);
	}

	// The effect using this item has.
	public override void Effect (AI _ai) {
		// Positive effects.
		_ai.emptyBladder.Reset (emptyBladder);
		_ai.hygiene.Reset (hygiene);

		// Negative effect.
		_ai.energy.Reset (energy);
	}

}