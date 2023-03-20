using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Jelly : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameManager gm;
    public UpgradeManager um;

    public float level; // 젤리 강화 레벨
    public int jelly_Class; // 젤리 연구 레벨
    public int jelatin_Prob_Level; // 젤라틴 획득 확률 레벨
    public int jelatin_Prob; // 젤라틴 획득 확률
    public int get_Jelatin_Amount_Level; // 젤라틴 획득량 레벨
    public int get_Jelatin_Amount; // 젤라틴 획득량

    public float deco_Get_Gold_Amount; // 데코로 인한 골드 수익

    public int[] get_Gold_Amount; // 젤리 종류에 따른 골드 획득량 배열

    public Sprite[] jelly_spritelist; // 젤리 스프라이트 배열
    public string[] jelly_namelist; // 젤리 이름 배열
    public Sprite[] deco_spritelist; // 데코 스프라이트 배열
    public string[] deco_namelist; // 데코 이름 배열
    public string[] deco_infolist; // 데코 설명 배열
    public string[] deco_state_infolist; // 데코 능력 설명 배열
    public int[] jelly_LevelUp_pricelist; // 강화 가격 배열
    public int[] jelly_Upgrade_pricelist; // 연구 가격 배열
    public int[] jelatinProb_LevelUp_pricelist; // 젤라틴 획득 확률 가격 배열
    public int[] jelatinAmount_LevelUp_pricelist; // 젤라틴 획득량 가격 배열
    public int[] market_item_pricelist; // 상점 물품 가격 배열

    public float anim_size; // 클릭 애니메이션 사이즈


    public void OnPointerDown(PointerEventData data)
    {
        transform.localScale = new Vector3(anim_size + 0.05f, anim_size + 0.05f, 1);
    }

    public void OnPointerUp(PointerEventData data)
    {
        // 골드 획득
        gm.gold += ((level / 10) + (deco_Get_Gold_Amount / 10) + 1) * get_Gold_Amount[jelly_Class]; // 레벨디자인

        // 난수 생성
        int rand = Random.Range(1, 101);

        // 난수가 젤라틴 획득 확률보다 작거나 같으면
        if (rand <= jelatin_Prob + 1)
        {
            // 젤라틴 획득
            gm.jelatin += ((get_Jelatin_Amount + 1));

            // 효과음 재생
            SoundManager.instance.PlaySound("Get_Jelatin");
        }
        else
        {
            // 효과음 재생
            SoundManager.instance.PlaySound("jellyTouch");
        }

        PlayerPrefs.SetFloat("Gold", gm.gold); // 골드 저장
        PlayerPrefs.SetFloat("Jelatin", gm.jelatin); // 젤라틴 저장

        transform.localScale = new Vector3(anim_size, anim_size, 1);
    }
}
