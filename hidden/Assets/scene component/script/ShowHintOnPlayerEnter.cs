using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerDetector))]
public class ShowHintOnPlayerEnter : MonoBehaviour
{
    public FadeText hint;
    public string text;
    // Update is called once per frame
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
