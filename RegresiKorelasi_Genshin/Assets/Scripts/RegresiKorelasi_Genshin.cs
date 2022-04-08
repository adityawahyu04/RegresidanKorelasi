using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RegresiKorelasi_Genshin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        List<float> kumpulannilaix = new List<float>();
        List<float> kumpulannilaiy = new List<float>();

        float konstanta = Konstanta(kumpulannilaix, kumpulannilaiy);
        Debug.Log("Relasi dan Korelasi antara banyak craft dengan bonus craft - Genshin Impact");
        Debug.Log("Dibuat oleh : Dzulfiqar Zahran (152018004) & Andika Budi Cahyadi (152018011)");
        Debug.Log("Berapa banyak material yang akan di craft?");
        int x = Convert.ToInt32(Console.ReadLine());
        Debug.Log("Banyak craft material : " + x);
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    float Konstanta(List<float> _dataX, List<float> _dataY)
    {
        return 0;
    }
}
