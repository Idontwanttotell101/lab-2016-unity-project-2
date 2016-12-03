using UnityEngine;
using System.Collections;

public class TooBelowDestroy : MonoBehaviour
{
    public float limitY = -100;
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < limitY)
            Destroy(this.gameObject);
    }
}
