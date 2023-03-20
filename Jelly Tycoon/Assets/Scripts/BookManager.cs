using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookManager : MonoBehaviour
{
    public Jelly jelly;

    public GameObject bookPanel;
    public Image[] jelly_Of_Book;
    public Text[] jellyName_Of_Book;

    public static bool[] jelly_unlock_list;
    int unlock_List_Length;

    // 싱글톤 패턴
    public static BookManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (instance != null)
            {
                Destroy(gameObject);
            }
        }
  

        // 배열 생성
        jelly_unlock_list = new bool[5]; // 배열 안에 숫자는 젤리 종류의 갯수.

        jelly_unlock_list[0] = true; // 청포도 젤리 해금

        // 도감 불러오기
        unlock_List_Length = PlayerPrefs.GetInt("Upgrade");

        for (int i = 0; i <= unlock_List_Length; i++)
        {
            jelly_unlock_list[i] = true;
        }

        UpdateBook();
    }

    // 도감을 열고 닫는 메소드
    public void OpenBookPanel()
    {
        SoundManager.instance.PlaySound("ButtonClick");
        bookPanel.SetActive(true);
    }
    public void CloseBookPanel()
    {
        SoundManager.instance.PlaySound("ButtonClick");
        bookPanel.SetActive(false);
    }

    // 도감매니저에서는 도감의 언락 현황을 관리

    public void UpdateBook()
    {
        // 언락 현황을 체크하고 이미지와 텍스트를 변경
        for (int i = 0; i < jelly_unlock_list.Length; i++)
        {
            if (jelly_unlock_list[i])
            {
                jelly_Of_Book[i].color = Color.white;
                jellyName_Of_Book[i].text = jelly.jelly_namelist[i];
            }
        }
    }
}
