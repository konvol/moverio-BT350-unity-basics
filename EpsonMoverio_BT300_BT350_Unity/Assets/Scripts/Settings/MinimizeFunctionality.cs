using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinimizeFunctionality : MonoBehaviour
{
    public Sprite minimize;
    public Sprite maximize;
    public Button minimizeButton;

    // Start is called before the first frame update
    void Start()
    {
        minimizeButton.onClick.AddListener(toggleMinimize);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void toggleMinimize()
    {

        if (minimizeButton.image.sprite == minimize)
        {
            minimizeButton.image.sprite = maximize;
        }
        else
        {
            minimizeButton.image.sprite = minimize;
        }
    }
}
