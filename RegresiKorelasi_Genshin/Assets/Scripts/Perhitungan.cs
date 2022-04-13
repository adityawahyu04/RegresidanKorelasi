using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

public class Perhitungan : MonoBehaviour
{
    public InputField craft1;
    public InputField craft2;
    public InputField craft3;
    public InputField craft4;
    public InputField craft5;

    public InputField bonus1;
    public InputField bonus2;
    public InputField bonus3;
    public InputField bonus4;
    public InputField bonus5;

    public Text ModelReg;
    public Text Korelasi;
    public Text Kontribusi;
    string filename = "";
    string text = "";
    string text2 = "";
    void Start()
    {
        filename = Application.dataPath + "/output.csv";
    }

    // Update is called once per frame
    void Update()
    {
        double xsig;
        double ysig;
        double xy1; double xy2; double xy3; double xy4; double xy5; double xysig;
        double xkuad1; double xkuad2; double xkuad3; double xkuad4; double xkuad5;
        double ykuad1; double ykuad2; double ykuad3; double ykuad4; double ykuad5;
        double xkuadsig;
        double ykuadsig;
        double a; double b; double r;
        double atas1; double atas2; double atas3 ;
        double bawah1; double bawah2; double bawah3; double bawah31;
        //double korelasi;
        double det;
        //------------------------------------------------------------------------------------------------------------------------------------------------------
        xsig = double.Parse(craft1.text) + double.Parse(craft2.text) + double.Parse(craft3.text) + double.Parse(craft4.text) + double.Parse(craft5.text);
        ysig = double.Parse(bonus1.text) + double.Parse(bonus2.text) + double.Parse(bonus3.text) + double.Parse(bonus4.text) + double.Parse(bonus5.text);

        xy1 = double.Parse(craft1.text) * double.Parse(bonus1.text);
        xy2 = double.Parse(craft2.text) * double.Parse(bonus2.text);
        xy3 = double.Parse(craft3.text) * double.Parse(bonus3.text);
        xy4 = double.Parse(craft4.text) * double.Parse(bonus4.text);
        xy5 = double.Parse(craft5.text) * double.Parse(bonus5.text);

        xysig = xy1 + xy2 + xy3 + xy4 + xy5;

        xkuad1 = Math.Pow(double.Parse(craft1.text), 2);
        xkuad2 = Math.Pow(double.Parse(craft2.text), 2);
        xkuad3 = Math.Pow(double.Parse(craft3.text), 2);
        xkuad4 = Math.Pow(double.Parse(craft4.text), 2);
        xkuad5 = Math.Pow(double.Parse(craft5.text), 2);

        ykuad1 = Math.Pow(double.Parse(bonus1.text), 2);
        ykuad2 = Math.Pow(double.Parse(bonus2.text), 2);
        ykuad3 = Math.Pow(double.Parse(bonus3.text), 2);
        ykuad4 = Math.Pow(double.Parse(bonus4.text), 2);
        ykuad5 = Math.Pow(double.Parse(bonus5.text), 2);

        xkuadsig = xkuad1 + xkuad2 + xkuad3 + xkuad4 + xkuad5;
        ykuadsig = ykuad1 + ykuad2 + ykuad3 + ykuad4 + ykuad5;

        //

        atas1 = (ysig * xkuadsig) - (xsig * xysig);
        bawah1 = (5 * xkuadsig) - Math.Pow(xsig,2);
        a = atas1 / bawah1;

        atas2 = (5 * xysig) - (xsig * ysig);
        bawah2 = (5 * xkuadsig) - Math.Pow(xsig,2);
        b = atas2 / bawah2;

        ModelReg.text = ("y = "+a.ToString("N3")+"+" + b.ToString("N3")+ "X");

        //-------------------------------------------------------------

        atas3 = (5 * xysig) - (xsig * ysig);
        bawah3 = ((5 * xkuadsig) - Math.Pow(xsig,2)) * ((5 * ykuadsig) - Math.Pow(ysig,2));
        bawah31 = Math.Sqrt(bawah3);

        r = atas3 / bawah31;
        if (r < 0)
        {
            Debug.Log("Hubungan Terbalik");
            text = "Hubungan Terbalik";
        }
        else
        {
            Debug.Log("Hubungan Lurus / Linear");
            text = "Hubungan Lurus / Linear";
        }

        if (r >= 0.8)
        {
            Debug.Log("Sangat Kuat");
            text2 = "Sangat Kuat";
        }
        else if (r>= 0.6)
        {
            Debug.Log("Kuat");
            text2 = "Kuat";
        }

        else if (r >= 0.4)
        {
            Debug.Log("Sedang");
            text2 = "Sedang";
        }

        else if (r>= 0.2)
        {
            Debug.Log("Lemah");
            text2 = "Lemah";
        }
        else
        {
            Debug.Log("Sangat Lemah");
            text2 = "Sangat Lemah";
        }

        Korelasi.text = r.ToString("N3");

        //--------------------------------------------------------------

        det = Math.Pow(r,2) * 100;

        Kontribusi.text = (det.ToString("N3")+"%");

        TextWriter tw = new StreamWriter(filename, false);
        tw.WriteLine("Craft ke - 1 = "+ craft1.text);
        tw.WriteLine("Craft ke - 2 = "+ craft2.text);
        tw.WriteLine("Craft ke - 3 = "+ craft3.text);
        tw.WriteLine("Craft ke - 4 = "+ craft4.text);
        tw.WriteLine("Craft ke - 5 = "+ craft5.text);

        tw.WriteLine("\n");
        tw.WriteLine("Bonus craft ke - 1 = "+ bonus1.text);
        tw.WriteLine("Bonus craft ke - 2 = "+ bonus2.text);
        tw.WriteLine("Bonus craft ke - 3 = "+ bonus3.text);
        tw.WriteLine("Bonus craft ke - 4 = "+ bonus4.text);
        tw.WriteLine("Bonus craft ke - 5 = "+ bonus5.text);

        tw.WriteLine("\n");
        tw.WriteLine("Model Regresi : " + "y = " + a.ToString("N3") + "+" + b.ToString("N3") + "X");
        tw.WriteLine(r);
        tw.WriteLine("Hubungannya adalah " + text);
        tw.WriteLine("Kekuatan Hubungannya adalah " + text2);
        tw.WriteLine("Kontribusi = "+ det.ToString("N3") + "%");

        tw.Close();
        Debug.Log("Data sudah di export");


    }
}
