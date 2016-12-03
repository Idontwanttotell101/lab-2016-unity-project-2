using UnityEngine;
using System.Collections;

public class blink : MonoBehaviour
{

    private new Renderer renderer;

    void Start()
    {
        renderer = this.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        var c = renderer.material.color;
        c.a = Mathf.Sin(Time.time) / 3 + 0.5f;
        renderer.material.color = c;
    }
}
