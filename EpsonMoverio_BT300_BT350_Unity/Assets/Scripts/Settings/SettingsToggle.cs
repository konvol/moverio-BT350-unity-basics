using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
public class SettingsToggle : MonoBehaviour
{
    public Button settingsButton;
    GameObject settingsContainer;
    // Start is called before the first frame update
    void Start()
    {
        settingsButton.onClick.AddListener(toggleSettings);
        settingsContainer = GameObject.FindGameObjectsWithTag("Settings")[0];
        settingsContainer.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void toggleSettings()
    {
        settingsContainer.SetActive(!settingsContainer.active);
            
    }
}
