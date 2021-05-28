using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{
    public Sprite openLocked;
    public Sprite openUnlocked;
    public Sprite close;
    public Button menuButton;
    public GameObject controlMenu;
    public Image menuPanel;
    public Text objectName;

    // Start is called before the first frame update
    void Start()
    {
        menuButton.onClick.AddListener(toggleMenu);
        controlMenu.SetActive(false);
        menuPanel.enabled = false;
        objectName.text = "Creeper";


    }

    // Update is called once per frame
    void Update()
    {

    }

    private void toggleMenu()
    {

        if (menuButton.image.sprite == close)
        {
            menuButton.image.sprite = openLocked;
        }
        else
        {
            menuButton.image.sprite = close;
        }
        controlMenu.SetActive(!controlMenu.active);
        menuPanel.enabled = !menuPanel.enabled;
    }
}
