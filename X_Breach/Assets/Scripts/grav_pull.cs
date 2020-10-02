using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class grav_pull : MonoBehaviour
{
    const float grav_const = 1.6740f, mass = 60f;

    Scene currScene;
    GameObject[] allObjs;

    List<GameObject> attractableObjs;

    void Start()
    {
        attractableObjs = new List<GameObject>();

        currScene = SceneManager.GetActiveScene();
        allObjs = currScene.GetRootGameObjects();

        for(int i = 0; i < allObjs.Length; i++)
        {
            if (allObjs[i].tag == "Moveable")
                attractableObjs.Add(allObjs[i]);
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.S))
            for (int i = 0; i < attractableObjs.Count; i++)
                Pull(attractableObjs[i]);
            
    }

    void Pull(GameObject obj)
    {
        float dist = Vector2.Distance(transform.position, obj.transform.position);
        float objMass = obj.GetComponent<MoveableObj>().mass;

        float force = grav_const * (mass - objMass) / (dist * dist);

        Vector2 dir = transform.position - obj.transform.position;
        obj.GetComponent<Rigidbody2D>().velocity = dir * force;
    }
}
