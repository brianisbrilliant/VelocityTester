using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuiExample : MonoBehaviour
{
    // if you need a flexible array - use a list!
    public List<GameObject> boxes;
    public List<string> names = new List<string> {"Tom", "Jerry", "Dana", "Me-Mow"};

    public Queue<GameObject> spheres;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.B)) {
            GameObject box = GameObject.CreatePrimitive(PrimitiveType.Cube);
            box.GetComponent<Renderer>().material.color = Random.ColorHSV();
            box.AddComponent<Rigidbody>();
            box.transform.position = Vector3.up * 5;
            box.name = names[Random.Range(0,names.Count)];
            boxes.Add(box);
        }

        if(Input.GetKeyDown(KeyCode.N)) {
            foreach( GameObject box in boxes) {
                Destroy(box);
            }
            boxes = new List<GameObject>();
        }

        if(Input.GetKeyDown(KeyCode.S)) {
            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.transform.position = Vector3.up * 8;
            sphere.AddComponent<Rigidbody>();
            spheres.Enqueue(sphere);
            if(spheres.Count > 5) {
                GameObject deadBall = spheres.Dequeue();
                Destroy(deadBall);
            }

            
        }
    }
}
