using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj
{
    public bool catched = false;
    public GameObject unity_obj;
    public int lane;
    Vector3 final_pos;

    public Obj (GameObject unity_object, int lane_number, Vector3 final_position)
    {
        unity_obj = unity_object;
        lane = lane_number;
        final_pos = final_position;
        if (lane_number == 0)
            unity_obj.transform.position += new Vector3(-0.8f, 0, 0);
        else if (lane_number == 2)
            unity_obj.transform.position += new Vector3(0.8f, 0, 0);
        unity_obj.SetActive(false);
    }

    public void move()
    {
        int speed = 4;
        unity_obj.transform.position += Vector3.back * speed * Time.deltaTime;
    }
}

public class ObjectsScript : MonoBehaviour
{
    public GameObject[] unity_objects = new GameObject[8];
    public GameObject[] Lanes;
    int[] lanes_order = new int[] {1, 0, 2, 1, 2, 0, 2, 1};
    Vector3[] positionArray = new [] { new Vector3(0,0,0), 
                                        new Vector3(0,0,0),
                                        new Vector3(0,0,0),
                                        new Vector3(0,0,0),
                                        new Vector3(0,0,0),
                                        new Vector3(0,0,0),
                                        new Vector3(0,0,0),
                                        new Vector3(0,0,0)};

    Obj[] objects = new Obj[8];

    static int current = 0;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < unity_objects.Length; i++)
        {
            objects[i] = new Obj(unity_objects[i], lanes_order[i], positionArray[i]);
        }
        objects[0].unity_obj.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (current < objects.Length)
        {
             objects[current].move();
        
            // COLLISION => ON A L'OBJET
            if (objects[current].unity_obj.transform.position.z < -5 && GroundScript.state == objects[current].lane + 1)
            {
                objects[current].catched = true;
                Debug.Log("GOT OBJECT");
                // PLAY SOUND HERE OR ANIMATION
                objects[current].unity_obj.SetActive(false);
                current++;
                objects[current].unity_obj.SetActive(true);
            }
            // value is point where it disappear from screen - 15 from collectible object position
            else if (objects[current].unity_obj.transform.position.z < -7)
            {
                objects[current].unity_obj.SetActive(false);
                current++;
                objects[current].unity_obj.SetActive(true);
            }
        }
        // ELSE, on a fait tous les objets du coup fin et affichage ?
    }
}
