using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GlobalScore : MonoBehaviour
{
    public GameObject scoreBox;
    public static int currentScore;
    public int internalScore;


    void Update()
    {
        internalScore = currentScore;
        scoreBox.GetComponent<TMP_Text>().text = "" + internalScore;
    }
}
