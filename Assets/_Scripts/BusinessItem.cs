using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BusinessItem :
MonoBehaviour
{
    public BusinessData data;


    public TextMeshProUGUI
        priceText;



    // UI для магазину

    public GameObject
        shopView;


    public GameObject
        businessView;



    void Start()
    {
        priceText.text =

        "$"

        +

        data.basePrice;
    }




    public void Buy()
    {
        // Якщо грошей не вистачає - нічого не робе
        if(
            CurrencyManager
            .Instance
            .balance

            <

            data.basePrice
        )
        {
            return;
        }



        // Віднімає гроші
        CurrencyManager
        .Instance
        .balance -=

        data.basePrice;



        CurrencyManager
        .Instance
        .UpdateUI();



        // купує бізнес
        BusinessManager
        .Instance
        .BuyBusiness(
            data
        );



        // Закриває магазин
        if(
            shopView
            != null
        )
        {
            shopView
            .SetActive(false);
        }



        // Відкриває сторінку бізнесів
        if(
            businessView
            != null
        )
        {
            businessView
            .SetActive(true);
        }
    }
}