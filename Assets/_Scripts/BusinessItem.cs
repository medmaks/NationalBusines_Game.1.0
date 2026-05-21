using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BusinessItem :
MonoBehaviour
{
    public BusinessData data;


    public TextMeshProUGUI
        priceText;



    // Я прив'язую екрани,
    // щоб не використовувати Find()

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
        // Перевіряю чи вистачає грошей
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



        // Віднімаю гроші
        CurrencyManager
        .Instance
        .balance -=

        data.basePrice;



        CurrencyManager
        .Instance
        .UpdateUI();



        // Купую бізнес
        BusinessManager
        .Instance
        .BuyBusiness(
            data
        );



        // Закриваю магазин
        if(
            shopView
            != null
        )
        {
            shopView
            .SetActive(false);
        }



        // Відкриваю сторінку бізнесів
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