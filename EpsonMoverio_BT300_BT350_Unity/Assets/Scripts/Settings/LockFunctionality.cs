using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockFunctionality : MonoBehaviour
{
    public Sprite locked; 
    public Sprite unlocked;
    public Button lockButton;

    // Start is called before the first frame update
    void Start()
    {
        lockButton.onClick.AddListener(toggleLock);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void toggleLock()
    {
        
        if (lockButton.image.sprite == locked)
        {
            lockButton.image.sprite = unlocked;
        }
        else
        {
            lockButton.image.sprite = locked;
        }   
    }
}
