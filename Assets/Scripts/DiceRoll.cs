using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRoll : MonoBehaviour
{
    Rigidbody rb;
    Vector3 initPosition;
    public int number = 0;
    public static int count1;
    public static int count2;
    public static int count3;
    public static int count4;
    public static int count5;
    public static int count6;
    public bool rolled;
    public Vector3 diceVelocity;
    public static DiceRoll instance;//ΩÃ±€≈Ê Ω√¿€
    private void Awake()
    {
        instance = this;
    }//ΩÃ±€≈Ê ¡æ∑·

    void Start()
    {
        count1 = 0;
        count2 = 0;
        count3 = 0;
        count4 = 0;
        count5 = 0;
        count6 = 0;
        number = 0;
        rb = GetComponent<Rigidbody>();
        initPosition = transform.position;
        rolled = false;
    }

    void Update()
    {
        diceVelocity = rb.velocity; 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            setCount();
            roll();
        }

        if (diceVelocity.x == 0f && diceVelocity.y == 0f && diceVelocity.z == 0f && DiceCheckZone.instance.diceNumber != 0 && rolled == true)
        {
            writeNumber();
            //Debug.Log(number);
        }
    }

    void roll()
    {
        rolled = true;
        //DiceCheckZone.instance.diceNumberList.Clear();
        transform.position = initPosition; 
        transform.rotation = Quaternion.Euler(Random.Range(0, 500), Random.Range(0, 500), Random.Range(0, 500));
        rb.AddForce(Random.Range(-300, 300), Random.Range(0, 500), Random.Range(-200, 200)); 
        rb.AddTorque(Random.Range(2000, 3000), Random.Range(2000, 3000), Random.Range(2000, 3000));
    }

    void setCount()
    {
        count1 = 0;
        count2 = 0;
        count3 = 0;
        count4 = 0;
        count5 = 0;
        count6 = 0;
    }

    void writeNumber()
    {
        number = DiceCheckZone.instance.diceNumber;
        DiceCheckZone.instance.diceNumber = 0;
        rolled = false;
        /*switch (number)
        {
            case 1:
                count1++;
                break;
            case 2:
                count2++;
                break;
            case 3:
                count3++;
                break;
            case 4:
                count4++;
                break;
            case 5:
                count5++;
                break;
            case 6:
                count6++;
                break;
        }*/
    }
}
