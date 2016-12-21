using UnityEngine;
using System.Collections;

public class pistolShoot : MonoBehaviour {

    public GameObject Player;
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
		if(Player.GetComponent<statement>().ammo > 0){
            Player.GetComponent<statement>().ammo--;
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