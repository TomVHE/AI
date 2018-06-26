using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item_Base : MonoBehaviour {

	public float useTime = 1f;
	[HideInInspector]
	public bool inUse;

	private AI aiRef;

	// A void that allows any item to get used.
	public void Use (AI _ai) {
		aiRef = _ai;
		StartCoroutine (UseItem ());
	}

	public IEnumerator UseItem () {
		inUse = true;
		yield return new WaitForSeconds (useTime);
		Effect (aiRef);
		inUse = false;
	}

	// The effect using the item has.
	public abstract void Effect (AI _ai);

	// This is abstract so the items are forced to overwrite this to add itself to the manager.
	public abstract void Start ();

	// A void any item, inhereting from this, can use to add itself to one of the lists from the manager.
	public void AddToManager (List<Item_Base> _itemList) {
		if (!_itemList.Contains (this)) {
			_itemList.Add (this);
		}
	}

}