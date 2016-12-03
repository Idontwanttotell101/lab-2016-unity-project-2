using UnityEngine;
using System.Collections;
using System;
using UnityEngine.EventSystems;

public class ShowHintOnMouseOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public FadeText Hint;
    public bool UseOverriteText = false;
    public string OverwriteText;

    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        if (UseOverriteText)
            Hint.Text = OverwriteText;
        Hint.Show();
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        Hint.Hide();
    }
}
