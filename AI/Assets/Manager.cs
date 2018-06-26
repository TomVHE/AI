using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Manager : MonoBehaviour {

	// Different list that each contain items that primairly focus on that need/stat.
	public static List<Item_Base> energyItems = new List<Item_Base> ();
	public static List<Item_Base> fullnessItems = new List<Item_Base> ();
	public static List<Item_Base> hygieneItems = new List<Item_Base> ();
	public static List<Item_Base> emptyBladderItems = new List<Item_Base> ();
	public static List<Item_Base> funItems = new List<Item_Base> ();

	// Get the item from the list that is the closest to the AI requesting it.
	public static Item_Base GetItem (Transform _ai, List<Item_Base> _itemList) {
		float dist = 0f;
		Item_Base bestItem = null;
		for (int i = 0; i < _itemList.Count; i++) {
			if (i == 0) {
				dist = Vector3.Distance (_ai.position, _itemList[i].transform.position);
				bestItem = _itemList[i];
			}
			else {
				float _dist = Vector3.Distance (_ai.position, _itemList[i].transform.position);
				if (_dist < dist) {
					dist = _dist;
					bestItem = _itemList[i];
				}
			}
		}
		return bestItem;
	}
}