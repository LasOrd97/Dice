using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceCheckZone : MonoBehaviour
{
    public int diceNumber = 0;
    public List<int> diceNumberList = new List<int>();
    Vector3 diceVelocity;
    public static DiceCheckZone instance;//ΩÃ±€≈Ê Ω√¿€
    private void Awake()
    {
        instance = this;
    }//ΩÃ±€≈Ê ¡æ∑·

    void Start()
    {

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            diceNumber = 0;
            //diceNumberList.Sort();
        }
    }

    void FixdeUpdate()
    {
        diceVelocity = DiceRoll.instance.diceVelocity;
    }

    void OnTriggerStay(Collider col)
    {
        if (diceVelocity.x == 0f && diceVelocity.y == 0f && diceVelocity.z == 0f && DiceRoll.instance.rolled == true && diceNumber == 0)
        {
            switch (col.gameObject.name) 
            {
                case "Side1":
                    diceNumber = 6;
                    break;
                case "Side2":
                    diceNumber = 5;
                    break;
                case "Side3":
                    diceNumber = 4;
                    break;
                case "Side4":
                    diceNumber = 3;
                    break;
                case "Side5":
                    diceNumber = 2;
                    break;
                case "Side6":
                    diceNumber = 1;
                    break;
            }
        }
    }
}