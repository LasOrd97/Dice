using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    Rigidbody rb;
    Vector3 initPosition;
    public int number = 0;
    public GameObject[] diceList;
    private GameObject diceTemp;
    private float numberTemp;
    private int diceListLength;
    public bool rolled;
    public Vector3 diceVelocity;
    

    void Start()
    {
        number = 0;
        diceListLength = diceList.Length;
        rb = GetComponent<Rigidbody>();
        initPosition = transform.position;
        rolled = false;
    }

    void Update()
    {
        diceVelocity = rb.velocity;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            roll();
        }

        if (rb.transform.position.y < 5 && diceVelocity.x == 0f && diceVelocity.y == 0f && diceVelocity.z == 0f && rolled == true)
        {
            setNumber();
            Debug.Log(number); // 다이스 값 출력
        }
    }

    void roll()
    {
        rolled = true;
        DiceManager.instance.diceNumberList.Clear();
        transform.position = initPosition;
        transform.rotation = Quaternion.Euler(Random.Range(0, 500), Random.Range(0, 500), Random.Range(0, 500));
        rb.AddForce(Random.Range(-300, 300), Random.Range(0, 500), Random.Range(-200, 200));
        rb.AddTorque(Random.Range(2000, 3000), Random.Range(2000, 3000), Random.Range(2000, 3000));
    }

    void setNumber()
    {
        numberTemp = 0;

        for (int i = 0; i < diceListLength; i++)
        {
            diceTemp = diceList[i];
            if (diceTemp.transform.position.y > numberTemp)
            {
                numberTemp = diceTemp.transform.position.y;
                number = i+1;
            }
        }
        DiceManager.instance.diceNumberList.Add(number);
        rolled = false;
    }
}