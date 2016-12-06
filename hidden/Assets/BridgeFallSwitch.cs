using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(PlayerDetector))]
public class BridgeFallSwitch : MonoBehaviour
{
    public KeyCode triggerCode = KeyCode.E;
    public List<GameObject> linkedItems;
	public List<OffMeshLink> links;
	public List<GameObject> targets;

    void OnPlayerStay(Collider c)
    {
		if (Input.GetKeyDown (triggerCode)) {
			foreach (var i in links) {
				Destroy (i);
			}
			foreach (var i in targets) {
				Destroy (i);
			}
			foreach (var i in linkedItems) {
				i.AddComponent<Rigidbody> ();
				i.GetComponent<Collider> ().enabled = false;
			}
		}
    }
}
