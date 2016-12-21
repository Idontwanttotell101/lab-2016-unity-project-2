using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class finish : MonoBehaviour {

    public GameObject Player;
    public GameObject secret;
    public GameObject text;
    // Use this for initialization

    void Awake() {
        text.gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.tag == "Player")
        {
            if (secret != null)
            {
                if (Player.GetComponent<status>().gotSecret == true)
                {
                    text.gameObject.SetActive(true);
                }
            }
            else {
                if (Player.GetComponent<status>().gotSecret == true)
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
