using UnityEngine;
using System.Collections;

public class alertcolor : MonoBehaviour {

    public Color lerpedColor = Color.green;
    void Update()
    {
        lerpedColor = Color.Lerp(Color.white, Color.black, Mathf.PingPong(Time.time, 1));
    }
}
