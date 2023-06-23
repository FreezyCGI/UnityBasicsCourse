using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public static UIScript instance;

    [SerializeField]
    Text txtCounter;

    private void Start()
    {
        instance = this;   
    }

    public void SetTxtCounterNumber(int counter)
    {
        txtCounter.text = "Hits: " + counter;
    }
}
