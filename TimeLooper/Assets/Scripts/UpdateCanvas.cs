using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateCanvas : MonoBehaviour {

    private float levelStartTime;
    private Text textField;
    private static int resetCount = 0;
	
    // Use this for initialization
	void Start () {
        levelStartTime = Time.time;
        textField = gameObject.GetComponent<Text>();
	}

    public void Update()
    {
        textField.text = "Time: " + (Time.time - levelStartTime).ToString("0.00") + "   Resets: " + resetCount.ToString();
    }

    public void IncrementResets()
    {
        resetCount++;
    }

    public void ResetResets()
    {
        resetCount = 0;
    }
}
