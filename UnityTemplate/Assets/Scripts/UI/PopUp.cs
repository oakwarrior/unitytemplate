using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUp : MonoBehaviour
{

    public Button ButtonYes;
    public Button ButtonNo;
    public Button ButtonAcknowledge;
    public Text TextDescription;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void InitPopUp(UnityEngine.Events.UnityAction yes = null, UnityEngine.Events.UnityAction no = null, UnityEngine.Events.UnityAction acknowledge = null, string desc = "")
    {
        if (yes != null)
        {
            ButtonYes.onClick.AddListener(yes);
        }
        else
        {
            ButtonYes.gameObject.SetActive(false);
        }
        if (no != null)
        {
            ButtonNo.onClick.AddListener(no);
        }
        else
        {
            ButtonNo.gameObject.SetActive(false);
        }
        if (acknowledge != null)
        {
            ButtonAcknowledge.onClick.AddListener(acknowledge);
        }
        else
        {
            ButtonAcknowledge.gameObject.SetActive(false);
        }

        TextDescription.text = desc;
    }

    public void Close()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
