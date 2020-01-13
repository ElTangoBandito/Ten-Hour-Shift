﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientClass : MonoBehaviour
{
    public class Patient
    {
        public int happiness;
        public int health;
        public string patientName;
        public Dictionary<int, string> dialogue = new Dictionary<int, string>();

        public Patient(string nameIn)
        {
            happiness = 100;
            health = 100;
            patientName = nameIn;
        }

        public void printPatientName()
        {
            print(patientName);
        }
    }



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

 
}
