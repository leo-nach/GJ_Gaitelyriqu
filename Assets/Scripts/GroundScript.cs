using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript : MonoBehaviour
{
    public Material red;
    public Material green;
    public Material blue;
    public Material white;

    public GameObject red_ground;
    public GameObject green_ground;
    public GameObject blue_ground;

    // state 0 = no lane, 1 = left (red), 2 = middle (green), 3 = right (blue)
    static int state = 2;

    static int[] change_state = new int[] { 0, 0 }; // to change and number

    // Invoked when a line of data is received from the serial device.
    void OnMessageArrived(string msg)
    {
        Debug.Log(msg);
        // int dist = int.Parse(msg);
        // int new_state = what_color(dist);
        // if (change_state[0] != new_state)
        // {
        //     change_state[0] = new_state;
        //     change_state[1] = 0;
        // }
        // else if (new_state != state)
        //     change_state[1] += 1;
        // if (change_state[1] > 2)
        // {
        //     change_color(new_state);
        //     state = new_state;
        // }
    }

    // Invoked when a connect/disconnect event occurs. The parameter 'success'
    // will be 'true' upon connection, and 'false' upon disconnection or
    // failure to connect.
    void OnConnectionEvent(bool success)
    {
        
    }

    int what_color(int dist)
    {
        if (dist < 60) // left red
            return 1;
        else if (dist > 61 && dist < 120) // middle green
            return 2;
        else if (dist > 121 && dist < 200) // right blue
            return 3;
        else
            return 0;
    }

    void change_color(int color)
    {
        red_ground.GetComponent<MeshRenderer> ().material = (state == 1 ? red : white);
        green_ground.GetComponent<MeshRenderer> ().material = (state == 2 ? green : white);
        blue_ground.GetComponent<MeshRenderer> ().material = (state == 3 ? blue : white);
    }
}