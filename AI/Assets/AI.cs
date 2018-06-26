using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour {

	[Range (0f, 100f)]
	public float health = 100f;
	public AIStat energy;
	public AIStat fullness;
	public AIStat hygiene;
	public AIStat emptyBladder;
	public AIStat fun;

	[HideInInspector]
	public bool useItem;

	private NavMeshAgent agent;

	private enum Needs {
		Energy,
		Fullness,
		Hygiene,
		EmptyBladder,
		Fun
	}
	private Needs need;

	private Item_Base item;

	private void Start () {
		agent = GetComponent<NavMeshAgent> ();
	}

	private void Update () {
		Live ();
	}

	// The void that lowers the stats and change the need of the ai based on that.
	private void Live () {
		StatDecrease ();
		Needs _need = FindLowestNeed ();
		// Checks if the need is different, if so then change the desired item/location.
		if (need != _need) {
			need = _need;
			item = null;
			switch (need) {
				case Needs.Energy:
					item = Manager.GetItem (transform, Manager.energyItems);
					break;
				case Needs.Fullness:
					item = Manager.GetItem (transform, Manager.fullnessItems);
					break;
				case Needs.Hygiene:
					item = Manager.GetItem (transform, Manager.hygieneItems);
					break;
				case Needs.EmptyBladder:
					item = Manager.GetItem (transform, Manager.emptyBladderItems);
					break;
				case Needs.Fun:
					item = Manager.GetItem (transform, Manager.funItems);
					break;
			}
			// Tell the NavMeshAgent to move to it's desired location.
			agent.SetDestination (item.gameObject.transform.position);
		}

		// Check if the NavMeshAgent reached it's destination, and if so use the item.
		if (!agent.pathPending) {
			if (agent.remainingDistance <= agent.stoppingDistance) {
				if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f) {
					// Check if the item isn't already being used, to prevent using the item multiple times.
					if (!item.inUse) {
						item.Use (this);
					}
				}
			}
		}
	}

	// Decreases the stats and checks if they are bellow 0, if they are lower health.
	private void StatDecrease () {
		float time = Time.deltaTime * 2;
		if (energy.Decrease ()) {
			health = Mathf.Clamp (health -= time, 0f, 100f);
		}
		if (fullness.Decrease ()) {
			health = Mathf.Clamp (health -= time, 0f, 100f);
		}
		if (hygiene.Decrease ()) {
			health = Mathf.Clamp (health -= time, 0f, 100f);
		}
		if (emptyBladder.Decrease ()) {
			hygiene.timeLeftAlone += Time.deltaTime / 2;
		}
		if (fun.Decrease ()) {
			energy.timeLeftAlone += Time.deltaTime / 2;
		}
		if (health <= 0) {
			Destroy (this);
		}
	}

	// Checks what the most important need is.
	private Needs FindLowestNeed () {
		if (energy.stat <= 15f) {
			return Needs.Energy;
		}
		else if (fullness.stat <= 50f) {
			return Needs.Fullness;
		}
		else if (hygiene.stat <= 50f) {
			return Needs.Hygiene;
		}
		else if (emptyBladder.stat <= 75) {
			return Needs.EmptyBladder;
		}
		return Needs.Fun;
	}
}