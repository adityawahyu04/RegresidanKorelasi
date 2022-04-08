using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public InputField angka1;
    public InputField angka2;
    public Text angka3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float a;
        a = float.Parse(angka1.text) + float.Parse(angka2.text);

        angka3.text = a.ToString();
    }
}
