using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowWorld : MonoBehaviour
{
    public Toggle toggle;
    private GameObject world;
    // Start is called before the first frame update
    void Start()
    {
        world = GameObject.FindGameObjectsWithTag("World")[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (toggle.isOn)
        {
            world.SetActive(false);
        }
        else
        {
            world.SetActive(true);
        }
    }
}
