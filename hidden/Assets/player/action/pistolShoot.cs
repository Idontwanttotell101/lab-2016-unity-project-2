using UnityEngine;
using System.Collections;

public class pistolShoot : MonoBehaviour {

    status GM;
    public GameObject firePoint;
    float shootRayLength = 100;

    void Awake() {
        GM = GameObject.FindObjectOfType<status>();
    }
	
	void Update ()
    {
        if (Input.GetMouseButtonDown(0) && GM.GetComponent<status>().cankill)
        {
            Shoot();
        }
    }

    void Shoot()
    {
		if(GM.ammo > 0){
            GM.ammo--;
	        RaycastHit shootHit;
	        Ray shootRay = new Ray();
	        shootRay.origin = firePoint.transform.position;
	        shootRay.direction = firePoint.transform.forward;
			Debug.DrawLine(firePoint.transform.position, shootRay.direction*1000 + firePoint.transform.position, Color.cyan);
	        if (Physics.Raycast(shootRay, out shootHit, shootRayLength))
	        {
				if (shootHit.transform.tag == "Enemy") {
					Destroy (shootHit.transform.gameObject);
				}
	        }

	        //Effect();
		}
    }
}