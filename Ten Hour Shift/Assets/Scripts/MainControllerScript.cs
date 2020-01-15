using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainControllerScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Globals.mabel.printPatientName();
        print(Globals.mabel.dialogue[1].hasNextLine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
