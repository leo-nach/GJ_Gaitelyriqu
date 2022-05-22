using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndChoiceScript : MonoBehaviour
{

    public static int start = 0;
    public GameObject[] choices = new GameObject[3];

    // Start is called before the first frame update
    void Start()
    {
        // StartCoroutine(waiter());
        for (int i = 0; i < choices.Length; i++)
        {
            choices[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (start == 1)
        {
            // animation
            // son
            // pop objets
            for (int i = 0; i < choices.Length; i++)
            {
                choices[i].SetActive(false);
            }
            // laps de temps
            // yield return new WaitForSeconds(4);
            int lane = GroundScript.state;
            // feedback selection
        }
    }
}
