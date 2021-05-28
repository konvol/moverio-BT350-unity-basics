using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValueTracking : MonoBehaviour
{
    private Text m_Text;
    public RoundSlider roundSlider;

    // Start is called before the first frame update
    void Start()
    {
        m_Text = GetComponent<Text>(); 
    }

    // Update is called once per frame
    void Update()
    {
        float value = roundSlider._value;
        m_Text.text = ((int)value).ToString() + "%";
    }
}
