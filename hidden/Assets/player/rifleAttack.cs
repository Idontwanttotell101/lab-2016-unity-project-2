using UnityEngine;
using System.Collections;

public class attack : MonoBehaviour {

    public GameObject firePoint;
    float shootRayLength = 100;

    void Start ()
    {
	
	}
	
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit shootHit;
        Ray shootRay = new Ray();
        shootRay.origin = firePoint.transform.position;
        shootRay.direction = firePoint.transform.forward;
        //Debug.DrawLine(firePoint.transform.position, shootRay.direction*10000 + firePoint.transform.position, Color.cyan);
        if (Physics.Raycast(shootRay, out shootHit, shootRayLength))
        {
            Debug.Log("bang!");
            //Debug.DrawLine(firePoint.transform.position, shootRay.direction+firePoint.transform.position, Color.cyan,float.PositiveInfinity);
        }

        //Effect();
    }
}