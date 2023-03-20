using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float gold;
    public float jelatin;

    public Text gold_Text;
    public Text jelatin_Text;



    private void Awake()
    {
        //PlayerPrefs.DeleteAll();

        gold = PlayerPrefs.GetFloat("Gold");
        jelatin = PlayerPrefs.GetFloat("Jelatin");
    }

    void Update()
    {
        gold_Text.text = string.Format("{0:n0}", gold);
        jelatin_Text.text = string.Format("{0:n0}", jelatin);
    }
    



}
