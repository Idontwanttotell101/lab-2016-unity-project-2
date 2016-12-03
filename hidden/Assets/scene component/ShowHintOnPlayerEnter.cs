using UnityEngine;
using System.Collections;

public class ShowHintOnPlayerEnter : MonoBehaviour
{
    public FadeText hint;
    public string text;
    // Update is called once per frame
    void OnTriggerEnter(Collider c)
    {
        if (c.tag == "Player")
        {
            hint.Text = text;
            hint.Show();
        }
    }

    void OnTriggerExit(Collider c)
    {
        if (c.tag == "Player")
        {
            hint.Hide();
        }
    }
}
