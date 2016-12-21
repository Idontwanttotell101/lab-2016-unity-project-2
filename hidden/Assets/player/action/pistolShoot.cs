using UnityEngine;
using System.Collections;

public class pistolShoot : MonoBehaviour {

    public GameObject GM;
    public GameObject firePoint;
    float shootRayLength = 100;
	
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
		if(GM.GetComponent<status>().ammo > 0){
            GM.GetComponent<status>().ammo--;
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