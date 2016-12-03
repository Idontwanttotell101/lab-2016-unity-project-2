using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeText : MonoBehaviour
{
    private CanvasGroup group;
    bool running = false;
    bool visible;

    public bool Visible
    {
        get
        {
            return visible;
        }
        set
        {
            if (value)
                Show();
            else
                Hide();
        }
    }

    //Make This Visible
    public void Show()
    {
        if (visible == true)
        {
            return;
        }
        if (running && !visible)
        {
            StopCoroutine("EaseOut");
        }

        visible = true;
        StartCoroutine("EaseIn");
    }

    //Make This Invisible
    public void Hide()
    {
        if (visible == false)
        {
            return;
        }
        if (running && visible)
        {
            StopCoroutine("EaseIn");
        }

        visible = false;
        StartCoroutine("EaseOut");
    }

    private IEnumerator EaseInOut(bool show, float duration = 1)
    {
        running = true;
        float time = 0;
        AnimationCurve curve = AnimationCurve.EaseInOut(0, group.alpha, duration, show ? 1 : 0);

        while (time < duration)
        {
            group.alpha = curve.Evaluate(time);
            yield return null;
            time += Time.deltaTime;
        }
        group.alpha = show ? 1 : 0;
        running = false;
    }

    private IEnumerator EaseIn()
    {
        Debug.Log("Inside in");
        return EaseInOut(true);
    }

    private IEnumerator EaseOut()
    {
        Debug.Log("Inside out");
        return EaseInOut(false);
    }

    public string Text
    {
        get
        {
            return GetComponentInChildren<Text>().text;
        }
        set
        {
            GetComponentInChildren<Text>().text = value;
        }
    }

    public Color TextColor
    {
        get
        {
            return GetComponentInChildren<Text>().color;
        }
        set
        {
            GetComponentInChildren<Text>().color = value;
        }
    }

    public Color BackgroundColor
    {
        get
        {
            return GetComponent<Image>().color;
        }
        set
        {
            GetComponent<Image>().color = value;
        }
    }

    // Update is called once per frame
    void Start()
    {
        group = this.GetComponent<CanvasGroup>();
    }


    /// <summary>
    /// Cerate SplashText With Default Time And Color
    /// </summary>
    public static FadeText CreateSplashText(string text)
    {
        var textObject = Resources.Load("UI/SplashText");
        var obj = GameObject.Instantiate(textObject) as GameObject;
        var stext = obj.GetComponent<FadeText>();
        stext.Text = text;
        return stext;
    }
}
