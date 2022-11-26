using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceManager : MonoBehaviour
{
    public List<int> diceNumberList = new List<int>();
    public int diceCount;
    public GameObject diceFactory;
    public bool createDice;
    public static DiceManager instance;//싱글톤 시작
    private void Awake()
    {
        instance = this;
    }//싱글톤 종료

    void Start()
    {
        diceCount = 5; // 받아오는 다이수 개수 값(수정 필요)
        createDice = true; // 주사위 생성 bool 값 (true 일 때 주사위 생성, 이 값을 변경하여 생성 여부 결정)
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && createDice == true) // 스페이스 바로 주사위 생성
        {
            for (int i = 0; i < diceCount; i++)
            {
                GameObject dice = Instantiate(diceFactory);
                setPosition(dice, i);
            }
            createDice = false;
        }       
        diceNumberList.Sort();
    }

    void setPosition(GameObject dice, int i)
    {
        switch (i)
        {
            case 0:
                dice.transform.position = new Vector3(2, 16, 0);
                break;
            case 1:
                dice.transform.position = new Vector3(0, 16, 2);
                break;
            case 2:
                dice.transform.position = new Vector3(2, 17, 2);
                break;
            case 3:
                dice.transform.position = new Vector3(-2, 18, 0);
                break;
            case 4:
                dice.transform.position = new Vector3(0, 17, -2);
                break;
            case 5:
                dice.transform.position = new Vector3(-2, 16, -2);
                break;
            case 6:
                dice.transform.position = new Vector3(0, 16, 0);
                break;
            case 7:
                dice.transform.position = new Vector3(0, 17, -4);
                break;
            default:
                Destroy(dice);
                break;
        }
    }
}
