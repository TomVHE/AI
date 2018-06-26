using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Pizza : Item_Base {

	[Header ("Positive effects")]
	public float fullness = 20f;
	public float energy = 10f;

	[Header ("Negative effect")]
	public float dirtiness = 5f;

	// Add this item to the correct list in Manager.
	public override void Start () {
		AddToManager (Manager.fullnessItems);
	}

	// The effect using this item has.
	public override void Effect (AI _ai) {
		// Positive effects.
		_ai.fullness.Reset (fullness);
		_ai.energy.Reset (energy);

		// Negative effect.
		_ai.hygiene.Reset (dirtiness);
	}

}