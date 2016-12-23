using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class finish : MonoBehaviour {

    status GM;
    public GameObject secret;
    public GameObject text;
    // Use this for initialization

    void Awake() {
        text.gameObject.SetActive(false);
        GM = GameObject.FindObjectOfType<status>();
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.tag == "Player")
        {
            if (secret != null)
            {
                if (GM.gotSecret == true)
                {
                    text.gameObject.SetActive(true);
                }
            }
            else {
                if (GM.gotSecret == true)
                {
                    text.gameObject.SetActive(true);
                }
                else {
                    text.gameObject.SetActive(true);
                    text.GetComponent<Text>().text = "Mission is over";
                }
                
            }
            
        }
    }
}
