using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeGetter : MonoBehaviour
{

    public Text time;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int timeHour = Globals.timeHour;
        int timeMinute = Globals.timeMinute;
        string timeText = "Time: " + timeHour + ":" + timeMinute + "0";
        time.text = timeText;
    }
}
