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
            unity_obj.transform.position = new Vector3(-0.8f, 0, 15);
        else if (lane_number == 2)
            unity_obj.transform.position = new Vector3(0.8f, 0, 15);
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
    public GameObject[] unity_objects = new GameObject[9];
    int[] lanes_order = new int[] {1, 0, 2, 1, 2, 0, 2, 0, 1};
    Vector3[] positionArray = new [] { new Vector3(1.71000004f,1.16999996f,0), 
                                        new Vector3(1.67999995f,0.0700000003f,-1.01999998f),
                                        new Vector3(-1.38999999f,1.42999995f,-1.57000005f),
                                        new Vector3(-1.21000004f,1.41999996f,0),
                                        new Vector3(1.60000002f,1.65999997f,1.20000005f),
                                        new Vector3(-1.63999999f,0.689999998f,0),
                                        new Vector3(1.89999998f,1.51999998f,-0.519999981f),
                                        new Vector3(-1.37f,0.330000013f,-1.70000005f),
                                        new Vector3(1.75f,0.579999983f,-0.180000007f)};

    Obj[] objects = new Obj[9];

    static int current = 0;
    static int nb_catch = 0;
    int total_obj = 9;

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
            if (objects[current].catched == true)
            {
                current++;
                if (current >= objects.Length && nb_catch != total_obj)
                    current = 0;
                return ;
            }
            if (objects[current].unity_obj.activeSelf == false)
                objects[current].unity_obj.SetActive(true);
            objects[current].move();

            // COLLISION => ON A L'OBJET
            if (objects[current].unity_obj.transform.position.z < -5 && GroundScript.state == objects[current].lane + 1)
            {
                objects[current].catched = true;
                Debug.Log("GOT OBJECT");
                nb_catch += 1;
                // PLAY SOUND HERE OR ANIMATION
                objects[current].unity_obj.SetActive(false);
                current++;
                // if (current >= objects.Length && nb_catch != total_obj)
                //     current = 0;
            }
            // value is point where it disappear from screen - 15 from collectible object position
            else if (objects[current].unity_obj.transform.position.z < -7)
            {
                objects[current].unity_obj.SetActive(false);
                objects[current].unity_obj.transform.position = new Vector3(objects[current].unity_obj.transform.position.x, 0, 15);
                current++;
                // if (current >= objects.Length && nb_catch != total_obj)
                //     current = 0;
            }
        }
        else {
            for (int i = 0; i < objects.Length; i++)
            {

            }
            Debug.Log("GAME FINISHED");
            EndChoiceScript.start = 1;
        }
        // ELSE, on a fait tous les objets du coup fin et affichage ?
    }
}
