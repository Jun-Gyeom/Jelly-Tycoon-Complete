using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour
{
    public Jelly jelly; // 젤리 스크립트

    public Text level_text; // 강화레벨 텍스트
    public Text upgradeLevel_text; // 연구레벨 텍스트
    public Text jelatinProbLevel_text; // 젤라틴 획득 확률 레벨 텍스트
    public Text jelatinAmountLevel_text; // 젤라틴 획득량 레벨 텍스트

    public Image jelly_Image; // 젤리 이미지
    public Image jelly_UnlockImage; // 해금 팝업 창 젤리 이미지
    public Text jelly_Name; // 해금 팝업 창 젤리 이름
    public Text jelly_Gold_Amount; // 해당 젤리가 클릭 당 벌어드리는 골드를 나타내는 텍스트

    public Text jelly_LevelUp_PriceText; // 젤리 강화 가격 텍스트
    public Text jelly_Upgrade_PriceText; // 젤리 연구 가격 텍스트
    public Text jelatinProb_LevelUp_PriceText; // 젤라틴 획득 확률 가격 텍스트
    public Text jelatinAmount_LevelUp_PriceText; // 젤라틴 획득량 레벨 텍스트

    public Text market_item_1; // 상점 1번 물품 구매 가격 텍스트
    public Text market_item_2; // 상점 2번 물품 구매 가격 텍스트
    public Text market_item_3; // 상점 3번 물품 구매 가격 텍스트
    public Text market_item_4; // 상점 4번 물품 구매 가격 텍스트
    public Text market_item_5; // 상점 5번 물품 구매 가격 텍스트

    public Button market_Buy_Btn_1; //상점 1번 물품 구매 버튼
    public Button market_Buy_Btn_2; //상점 2번 물품 구매 버튼
    public Button market_Buy_Btn_3; //상점 3번 물품 구매 버튼
    public Button market_Buy_Btn_4; //상점 4번 물품 구매 버튼
    public Button market_Buy_Btn_5; //상점 5번 물품 구매 버튼

    public Button jelly_LevelUp_Btn; // 젤리 품질 업그레이드 버튼
    public Button jelly_Upgrade_Btn; // 젤리 연구 업그레이드 버튼
    public Button jelatinProb_Btn; // 젤라틴 획득 확률 업그레이드 버튼
    public Button jelatinAmount_Btn; // 젤라틴 획득량 업그레이드 버튼

    public GameObject plate; // 상점 1번 물품: 접시
    public GameObject window; // 상점 2번 물품: 창문
    public GameObject clock; // 상점 3번 물품: 시계
    public GameObject ice; // 상점 4번 물품: 얼음 뭉치
    public GameObject jelly_Doll; // 상점 5번 물품: 젤리 인형

    public Image deco_UnlockImage; // 데코 획득 팝업 창 데코 이미지
    public Text deco_Name; // 데코 획득 팝업 창 데코 이름
    public Text deco_Info; // 데코 획득 팝업 창 데코 설명
    public Text deco_State_Info; // 데코 획득 팝업 창 데코 능력 설명

    public bool isBuy_Plate; // 접시를 보유 중인가?
    public bool isBuy_Window; // 창문를 보유 중인가?
    public bool isBuy_Clock; // 시계를 보유 중인가?
    public bool isBuy_Ice; // 얼음 뭉치를 보유 중인가?
    public bool isBuy_Jelly_Doll; // 젤리 인형을 보유 중인가?

    public GameObject deco_UnlockPanel; // 데코 획득 팝업창
    public GameObject unlockPanel; // 해금 팝업창
    public GameObject marketPanel; // 상점 창
    public GameObject rewardAD_Panel; // 리워드광고 패널

    private void Awake()
    {

        // 데이터 불러오기
        jelly.level = PlayerPrefs.GetInt("Level");
        jelly.jelly_Class = PlayerPrefs.GetInt("Upgrade");
        jelly.jelatin_Prob_Level = PlayerPrefs.GetInt("Prob_Level");
        jelly.get_Jelatin_Amount_Level = PlayerPrefs.GetInt("Amount_Level");

        jelly.jelatin_Prob = PlayerPrefs.GetInt("Prob");
        jelly.get_Jelatin_Amount = PlayerPrefs.GetInt("Amount");
        jelly.deco_Get_Gold_Amount = PlayerPrefs.GetFloat("Deco_Get_Gold_Amount");

        isBuy_Plate = System.Convert.ToBoolean(PlayerPrefs.GetInt("Plate"));
        isBuy_Window = System.Convert.ToBoolean(PlayerPrefs.GetInt("Window"));
        isBuy_Clock = System.Convert.ToBoolean(PlayerPrefs.GetInt("Clock"));
        isBuy_Ice = System.Convert.ToBoolean(PlayerPrefs.GetInt("Ice"));
        isBuy_Jelly_Doll = System.Convert.ToBoolean(PlayerPrefs.GetInt("JellyDoll"));


        plate.SetActive(isBuy_Plate);
        window.SetActive(isBuy_Window);
        clock.SetActive(isBuy_Clock);
        ice.SetActive(isBuy_Ice);
        jelly_Doll.SetActive(isBuy_Jelly_Doll);

        jelly_Image.sprite = jelly.jelly_spritelist[jelly.jelly_Class];
        jelly_Name.text = jelly.jelly_namelist[jelly.jelly_Class]; // 젤리 이름 변경


        // 업그레이드 관련

        // 젤리 품질
        if (jelly.level == jelly.jelly_LevelUp_pricelist.Length) // 젤리 품질 레벨 최대 레벨이라면
        {
            jelly_LevelUp_Btn.interactable = false;
            jelly_LevelUp_PriceText.text = "최대 레벨";
        }
        else
        {
            jelly_LevelUp_PriceText.text = string.Format("{0:n0}", jelly.jelly_LevelUp_pricelist[(int)jelly.level]); // 강화 가격 변경
        }

        // 젤리 연구
        if (jelly.jelly_Class == jelly.jelly_Upgrade_pricelist.Length) // 젤리 연구 레벨 최대 레벨이라면
        {
            jelly_Upgrade_Btn.interactable = false;
            jelly_Upgrade_PriceText.text = "최대 레벨";
        }
        else
        {
            jelly_Upgrade_PriceText.text = string.Format("{0:n0}", jelly.jelly_Upgrade_pricelist[jelly.jelly_Class]); // 연구 가격 변경
        }

        // 젤라틴 획득 확률
        if (jelly.jelatin_Prob_Level == jelly.jelatinProb_LevelUp_pricelist.Length) // 젤라틴 획득 확률 레벨 최대 레벨이라면
        {
            jelatinProb_Btn.interactable = false;
            jelatinProb_LevelUp_PriceText.text = "최대 레벨";
        }
        else
        {
            jelatinProb_LevelUp_PriceText.text = string.Format("{0:n0}", jelly.jelatinProb_LevelUp_pricelist[jelly.jelatin_Prob_Level]); // 강화 가격 변경
        }

        // 젤라틴 획득량
        if (jelly.get_Jelatin_Amount_Level == jelly.jelatinAmount_LevelUp_pricelist.Length) // 젤라틴 획득량 레벨 최대 레벨이라면
        {
            jelatinAmount_Btn.interactable = false;
            jelatinAmount_LevelUp_PriceText.text = "최대 레벨";
        }
        else
        {
            jelatinAmount_LevelUp_PriceText.text = string.Format("{0:n0}", jelly.jelatinAmount_LevelUp_pricelist[jelly.get_Jelatin_Amount_Level]); // 강화 가격 변경
        }


        // 상점 데코 관련
        if (isBuy_Plate)
        {
            market_Buy_Btn_1.interactable = false;
            market_item_1.text = "구매 완료";
        }
        else
        {
            market_item_1.text = string.Format("{0:n0}", jelly.market_item_pricelist[0]); // 상점 1번 물품 가격 변경
        }

        // 창문
        if (isBuy_Window)
        {
            market_Buy_Btn_2.interactable = false;
            market_item_2.text = "구매 완료";
        }
        else
        {

            market_item_2.text = string.Format("{0:n0}", jelly.market_item_pricelist[1]); // 상점 2번 물품 가격 변경
        }

        // 시계
        if (isBuy_Clock)
        {
            market_Buy_Btn_3.interactable = false;
            market_item_3.text = "구매 완료";
        }
        else
        {

            market_item_3.text = string.Format("{0:n0}", jelly.market_item_pricelist[2]); // 상점 3번 물품 가격 변경
        }

        // 얼음 뭉치
        if (isBuy_Ice)
        {
            market_Buy_Btn_4.interactable = false;
            market_item_4.text = "구매 완료";
        }
        else
        {

            market_item_4.text = string.Format("{0:n0}", jelly.market_item_pricelist[3]); // 상점 4번 물품 가격 변경
        }

        // 젤리 인형
        if (isBuy_Jelly_Doll)
        {
            market_Buy_Btn_5.interactable = false;
            market_item_5.text = "구매 완료";
        }
        else
        {

            market_item_5.text = string.Format("{0:n0}", jelly.market_item_pricelist[4]); // 상점 5번 물품 가격 변경
        }


        TextRenewal(); // 업그레이드 메뉴 일부 텍스트 리뉴얼
    }


    // 젤리 품질
    public void JellyLevelUp()
    {
        if (jelly.gm.gold < jelly.jelly_LevelUp_pricelist[(int)jelly.level])
        {
            SoundManager.instance.PlaySound("BuyFail");
            return;
        }

        jelly.gm.gold -= jelly.jelly_LevelUp_pricelist[(int)jelly.level]; // 결제
        PlayerPrefs.SetFloat("Gold", jelly.gm.gold); // 골드 저장

        jelly.level += 1;
        SoundManager.instance.PlaySound("BuyItem");
        PlayerPrefs.SetInt("Level", (int)jelly.level); // 강화 레벨 저장

        if (jelly.level == jelly.jelly_LevelUp_pricelist.Length) // 젤리 품질 레벨 최대 레벨이라면
        {
            jelly_LevelUp_Btn.interactable = false;
            jelly_LevelUp_PriceText.text = "최대 레벨";
        }
        else
        {
            jelly_LevelUp_PriceText.text = string.Format("{0:n0}", jelly.jelly_LevelUp_pricelist[(int)jelly.level]); // 강화 가격 변경
        }

        TextRenewal(); // 업그레이드 메뉴 일부 텍스트 리뉴얼
    }

    // 젤리 연구
    public void UpgradeJelly()
    {
        if (jelly.gm.jelatin < jelly.jelly_Upgrade_pricelist[jelly.jelly_Class])
        {
            SoundManager.instance.PlaySound("BuyFail");
            return;
        }

        jelly.gm.jelatin -= jelly.jelly_Upgrade_pricelist[jelly.jelly_Class]; // 결제
        PlayerPrefs.SetFloat("Jelatin", jelly.gm.jelatin); // 젤라틴 저장

        jelly.jelly_Class += 1;
        SoundManager.instance.PlaySound("BuyItem");
        SoundManager.instance.PlaySound("UpgradeJelly");

        // 도감
        BookManager.jelly_unlock_list[jelly.jelly_Class] = true; // 해당 젤리 도감 해금
        BookManager.instance.UpdateBook();

        PlayerPrefs.SetInt("Upgrade", jelly.jelly_Class); // 연구 레벨 저장

        jelly_Image.sprite = jelly.jelly_spritelist[jelly.jelly_Class]; // 젤리 이미지 변경
        jelly_UnlockImage.sprite = jelly.jelly_spritelist[jelly.jelly_Class]; // 해금 팝업 창 젤리 이미지 변경
        jelly_Gold_Amount.text = string.Format("{0:n0}", "수익 " + jelly.get_Gold_Amount[jelly.jelly_Class] + "원"); // 젤리 버는 돈(수익) 텍스트 변경
        jelly_Name.text = jelly.jelly_namelist[jelly.jelly_Class]; // 젤리 이름 변경

        if (jelly.jelly_Class == jelly.jelly_Upgrade_pricelist.Length) // 젤리 연구 레벨 최대 레벨이라면
        {
            jelly_Upgrade_Btn.interactable = false;
            jelly_Upgrade_PriceText.text = "최대 레벨";
        }
        else
        {
            jelly_Upgrade_PriceText.text = string.Format("{0:n0}", jelly.jelly_Upgrade_pricelist[jelly.jelly_Class]); // 연구 가격 변경
        }

        unlockPanel.gameObject.SetActive(true);

        TextRenewal(); // 업그레이드 메뉴 일부 텍스트 리뉴얼
    }

    // 젤라틴 획득 확률
    public void JelatinProb_LevelUp()
    {
        if (jelly.gm.gold < jelly.jelatinProb_LevelUp_pricelist[jelly.jelatin_Prob_Level])
        {
            SoundManager.instance.PlaySound("BuyFail");
            return;
        }

        jelly.gm.gold -= jelly.jelatinProb_LevelUp_pricelist[jelly.jelatin_Prob_Level]; // 결제
        PlayerPrefs.SetFloat("Gold", jelly.gm.gold); // 골드 저장

        jelly.jelatin_Prob += 1; // 젤라틴 획득 확률 +1
        jelly.jelatin_Prob_Level += 1; // 레벨 +1
        SoundManager.instance.PlaySound("BuyItem"); // 효과음 재생

        PlayerPrefs.SetInt("Prob_Level", jelly.jelatin_Prob_Level); // 강화 레벨 저장
        PlayerPrefs.SetInt("Prob", jelly.jelatin_Prob); // 젤라틴 획득 확률 저장

        if (jelly.jelatin_Prob_Level == jelly.jelatinProb_LevelUp_pricelist.Length) // 젤라틴 획득 확률 레벨 최대 레벨이라면
        {
            jelatinProb_Btn.interactable = false;
            jelatinProb_LevelUp_PriceText.text = "최대 레벨";
        }
        else
        {
            jelatinProb_LevelUp_PriceText.text = string.Format("{0:n0}", jelly.jelatinProb_LevelUp_pricelist[jelly.jelatin_Prob_Level]); // 강화 가격 변경
        }

        TextRenewal(); // 업그레이드 메뉴 일부 텍스트 리뉴얼
    }

    // 젤라틴 획득량
    public void JelatinAmount_LevelUp()
    {
        if (jelly.gm.jelatin < jelly.jelatinAmount_LevelUp_pricelist[jelly.get_Jelatin_Amount_Level])
        {
            SoundManager.instance.PlaySound("BuyFail");
            return;
        }

        jelly.gm.jelatin -= jelly.jelatinAmount_LevelUp_pricelist[jelly.get_Jelatin_Amount_Level]; // 결제
        PlayerPrefs.SetFloat("Jelatin", jelly.gm.jelatin); // 젤라틴 저장

        jelly.get_Jelatin_Amount += 1; // 젤라틴 획득량이자
        jelly.get_Jelatin_Amount_Level += 1; // 레벨 +1

        SoundManager.instance.PlaySound("BuyItem"); // 효과음 재생

        PlayerPrefs.SetInt("Amount_Level", jelly.get_Jelatin_Amount_Level); // 강화 레벨 저장
        PlayerPrefs.SetInt("Amount", jelly.get_Jelatin_Amount); // 젤라틴 획득량 저장

        if (jelly.get_Jelatin_Amount_Level == jelly.jelatinAmount_LevelUp_pricelist.Length) // 젤라틴 획득량 레벨 최대 레벨이라면
        {
            jelatinAmount_Btn.interactable = false;
            jelatinAmount_LevelUp_PriceText.text = "최대 레벨";
        }
        else
        {
            jelatinAmount_LevelUp_PriceText.text = string.Format("{0:n0}", jelly.jelatinAmount_LevelUp_pricelist[jelly.get_Jelatin_Amount_Level]); // 강화 가격 변경
        }

        TextRenewal(); // 업그레이드 메뉴 일부 텍스트 리뉴얼
    }

    // 텍스트 리뉴얼
    private void TextRenewal()
    {
        level_text.text = "수익 " + ((jelly.level / 10) + (jelly.deco_Get_Gold_Amount / 10) + 1) + "배";
        upgradeLevel_text.text = (jelly.jelly_Class + 1) + "단계 ";
        jelatinProbLevel_text.text = "확률 " + (jelly.jelatin_Prob + 1) + "%";
        jelatinAmountLevel_text.text = "획득 " + (jelly.get_Jelatin_Amount + 1) + "개";
    }

    // 연구 팝업 창 닫기
    public void ClosePopUp()
    {
        SoundManager.instance.PlaySound("ButtonClick");
        unlockPanel.gameObject.SetActive(false);
    }

    // 상점 팝업 창 열기
    public void OpenMarket()
    {
        SoundManager.instance.PlaySound("ButtonClick");
        marketPanel.gameObject.SetActive(true);
    }

    // 상점 팝업 창 닫기
    public void CloseMarket()
    {
        SoundManager.instance.PlaySound("ButtonClick");
        marketPanel.gameObject.SetActive(false);
    }

    // 리워드 광고 창 열기
    public void OpenReward_Tap()
    {
        SoundManager.instance.PlaySound("ButtonClick");
        rewardAD_Panel.gameObject.SetActive(true);
    }

    // 리워드 광고 창 닫기
    public void CloseReward_Tap()
    {
        SoundManager.instance.PlaySound("ButtonClick");
        rewardAD_Panel.gameObject.SetActive(false);
    }

    // 1번 아이템 접시 구매
    public void BuyItem1()
    {
        if (jelly.gm.gold < jelly.market_item_pricelist[0])
        {
            SoundManager.instance.PlaySound("BuyFail");
            return;
        }

        SoundManager.instance.PlaySound("BuyItem");
        SoundManager.instance.PlaySound("BuyDeco");
        jelly.gm.gold -= jelly.market_item_pricelist[0]; // 결제

        isBuy_Plate = true; // 접시를 구매했는가? true
        plate.gameObject.SetActive(true);

        jelly.deco_Get_Gold_Amount += 5; // 수익 +0.5배

        PlayerPrefs.SetFloat("Deco_Get_Gold_Amount", jelly.deco_Get_Gold_Amount); // 데코로 인한 골드 수익 저장
        PlayerPrefs.SetFloat("Gold", jelly.gm.gold); // 골드 저장
        PlayerPrefs.SetInt("Plate", System.Convert.ToInt16(isBuy_Plate)); // 구매 bool 값 저장

        deco_UnlockImage.sprite = jelly.deco_spritelist[0]; // 데코 획득 팝업 창 이미지 변경
        deco_Name.text = jelly.deco_namelist[0]; // 데코 획득 팝업 창 이름 변경
        deco_Info.text = jelly.deco_infolist[0]; // 데코 획득 팝업 창 설명 변경
        deco_State_Info.text = jelly.deco_state_infolist[0]; // 데코 획득 팝업 창 데코 능력 설명 변경

        market_Buy_Btn_1.interactable = false;
        market_item_1.text = "구매 완료";

        deco_UnlockPanel.gameObject.SetActive(true);

        TextRenewal(); // 업그레이드 메뉴 일부 텍스트 리뉴얼
    }

    // 2번 아이템 창문 구매
    public void BuyItem2()
    {
        if (jelly.gm.gold < jelly.market_item_pricelist[1])
        {
            SoundManager.instance.PlaySound("BuyFail");
            return;
        }

        SoundManager.instance.PlaySound("BuyItem");
        SoundManager.instance.PlaySound("BuyDeco");
        jelly.gm.gold -= jelly.market_item_pricelist[1]; // 결제

        isBuy_Window = true; // 창문을 구매했는가? true
        window.gameObject.SetActive(true);

        jelly.deco_Get_Gold_Amount += 5; // 수익 +0.5배

        PlayerPrefs.SetFloat("Deco_Get_Gold_Amount", jelly.deco_Get_Gold_Amount); // 데코로 인한 골드 수익 저장
        PlayerPrefs.SetFloat("Gold", jelly.gm.gold); // 골드 저장
        PlayerPrefs.SetInt("Window", System.Convert.ToInt16(isBuy_Window)); // 구매 bool 값 저장

        deco_UnlockImage.sprite = jelly.deco_spritelist[1]; // 데코 획득 팝업 창 이미지 변경
        deco_Name.text = jelly.deco_namelist[1]; // 데코 획득 팝업 창 이름 변경
        deco_Info.text = jelly.deco_infolist[1]; // 데코 획득 팝업 창 설명 변경
        deco_State_Info.text = jelly.deco_state_infolist[1]; // 데코 획득 팝업 창 데코 능력 설명 변경

        market_Buy_Btn_2.interactable = false;
        market_item_2.text = "구매 완료";

        deco_UnlockPanel.gameObject.SetActive(true);

        TextRenewal(); // 업그레이드 메뉴 일부 텍스트 리뉴얼
    }

    // 3번 아이템 시계 구매
    public void BuyItem3()
    {
        if (jelly.gm.gold < jelly.market_item_pricelist[2])
        {
            SoundManager.instance.PlaySound("BuyFail");
            return;
        }

        SoundManager.instance.PlaySound("BuyItem");
        SoundManager.instance.PlaySound("BuyDeco");
        jelly.gm.gold -= jelly.market_item_pricelist[2]; // 결제

        isBuy_Clock = true; // 시계를 구매했는가? true
        clock.gameObject.SetActive(true);

        jelly.jelatin_Prob += 5; // 젤라틴 획득 확률 5% 증가
        PlayerPrefs.SetInt("Prob", jelly.jelatin_Prob); // 젤라틴 획득 확률 저장

        PlayerPrefs.SetFloat("Gold", jelly.gm.gold); // 골드 저장
        PlayerPrefs.SetInt("Clock", System.Convert.ToInt16(isBuy_Clock)); // 구매 bool 값 저장

        deco_UnlockImage.sprite = jelly.deco_spritelist[2]; // 데코 획득 팝업 창 이미지 변경
        deco_Name.text = jelly.deco_namelist[2]; // 데코 획득 팝업 창 이름 변경
        deco_Info.text = jelly.deco_infolist[2]; // 데코 획득 팝업 창 설명 변경
        deco_State_Info.text = jelly.deco_state_infolist[2]; // 데코 획득 팝업 창 데코 능력 설명 변경

        market_Buy_Btn_3.interactable = false;
        market_item_3.text = "구매 완료";

        deco_UnlockPanel.gameObject.SetActive(true);

        TextRenewal(); // 업그레이드 메뉴 일부 텍스트 리뉴얼
    }

    // 4번 아이템 얼음 뭉치 구매
    public void BuyItem4()
    {
        if (jelly.gm.gold < jelly.market_item_pricelist[3])
        {
            SoundManager.instance.PlaySound("BuyFail");
            return;
        }

        SoundManager.instance.PlaySound("BuyItem");
        SoundManager.instance.PlaySound("BuyDeco");
        jelly.gm.gold -= jelly.market_item_pricelist[3]; // 결제

        isBuy_Ice = true; // 얼음 뭉치를 구매했는가? true
        ice.gameObject.SetActive(true);

        jelly.deco_Get_Gold_Amount += 5; // 수익 +0.5배

        PlayerPrefs.SetFloat("Deco_Get_Gold_Amount", jelly.deco_Get_Gold_Amount); // 데코로 인한 골드 수익 저장
        PlayerPrefs.SetFloat("Gold", jelly.gm.gold); // 골드 저장
        PlayerPrefs.SetInt("Ice", System.Convert.ToInt16(isBuy_Ice)); // 구매 bool 값 저장

        deco_UnlockImage.sprite = jelly.deco_spritelist[3]; // 데코 획득 팝업 창 이미지 변경
        deco_Name.text = jelly.deco_namelist[3]; // 데코 획득 팝업 창 이름 변경
        deco_Info.text = jelly.deco_infolist[3]; // 데코 획득 팝업 창 설명 변경
        deco_State_Info.text = jelly.deco_state_infolist[3]; // 데코 획득 팝업 창 데코 능력 설명 변경

        market_Buy_Btn_4.interactable = false;
        market_item_4.text = "구매 완료";

        deco_UnlockPanel.gameObject.SetActive(true);

        TextRenewal(); // 업그레이드 메뉴 일부 텍스트 리뉴얼
    }

    // 5번 아이템 젤리 인형 구매
    public void BuyItem5()
    {
        if (jelly.gm.gold < jelly.market_item_pricelist[4])
        {
            SoundManager.instance.PlaySound("BuyFail");
            return;
        }

        SoundManager.instance.PlaySound("BuyItem");
        SoundManager.instance.PlaySound("BuyDeco");
        jelly.gm.gold -= jelly.market_item_pricelist[4]; // 결제

        isBuy_Jelly_Doll = true; // 젤리 인형을 구매했는가? true
        jelly_Doll.gameObject.SetActive(true);

        jelly.get_Jelatin_Amount += 5; // 젤리 획득량 5개 증가

        PlayerPrefs.SetInt("Amount", jelly.get_Jelatin_Amount); // 젤라틴 획득량 저장
        PlayerPrefs.SetFloat("Gold", jelly.gm.gold); // 골드 저장
        PlayerPrefs.SetInt("JellyDoll", System.Convert.ToInt16(isBuy_Jelly_Doll)); // 구매 bool 값 저장

        deco_UnlockImage.sprite = jelly.deco_spritelist[4]; // 데코 획득 팝업 창 이미지 변경
        deco_Name.text = jelly.deco_namelist[4]; // 데코 획득 팝업 창 이름 변경
        deco_Info.text = jelly.deco_infolist[4]; // 데코 획득 팝업 창 설명 변경
        deco_State_Info.text = jelly.deco_state_infolist[4]; // 데코 획득 팝업 창 데코 능력 설명 변경

        market_Buy_Btn_5.interactable = false;
        market_item_5.text = "구매 완료";

        deco_UnlockPanel.gameObject.SetActive(true);

        TextRenewal(); // 업그레이드 메뉴 일부 텍스트 리뉴얼
    }
}
