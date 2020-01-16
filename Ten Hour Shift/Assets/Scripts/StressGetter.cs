using UnityEngine;
using UnityEngine.UI;


public class StressGetter : MonoBehaviour
{
    // Start is called before the first frame update
    public Text stress;

    // Update is called once per frame
    void Update()
    {
        stress.text = "Stress: " + Globals.stress + "%";
    }
}
