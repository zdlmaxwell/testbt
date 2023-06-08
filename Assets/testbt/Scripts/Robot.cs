using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    int battery = 10;
    float timer = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0) {
            timer = 1;
            battery -= 1;
        }

        if(battery <= 0) {
            battery = 0;
        }
    }

    public bool isBatteryLow() {
        if(battery <= 0) {
            return true;
        }
        return false;
    }

    public void chargeBattery() {
        battery = 10;
    }
}
