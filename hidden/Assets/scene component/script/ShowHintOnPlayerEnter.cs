using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerDetector))]
public class ShowHintOnPlayerEnter : MonoBehaviour
{
    public FadeText hint;
    public string text;
    // Update is called once per frame

    void Start()
    {
        if (hint == null)
        {
            hint = FindObjectOfType<FadeText>();
        }
    }

    void OnPlayerEnter(Collider c)
    {
        hint.Text = text;
        hint.Show();
    }

    void OnPlayerExit(Collider c)
    {
        hint.Hide();
    }
}
