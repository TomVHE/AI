using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Shower : Item_Base {

	[Header ("Positive effects")]
	public float hygiene = 75f;
	public float energy = 15f;
	public float fun = 20f;

	// Add this item to the correct list in Manager.
	public override void Start () {
		AddToManager (Manager.hygieneItems);
	}

	// The effect using this item has.
	public override void Effect (AI _ai) {
		// Positive effects.
		_ai.hygiene.Reset (hygiene);
		_ai.energy.Reset (energy);
		_ai.fun.Reset (fun);
	}

}