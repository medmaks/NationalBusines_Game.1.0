using TMPro;
using UnityEngine;

public class ProfileManager :
MonoBehaviour
{
    // UI-елемент для показу
    // загальної кількості кліків
    public TextMeshProUGUI
        totalClicksText;


    // UI-елемент для показу
    // грошей від кліків
    public TextMeshProUGUI
        moneyFromClicksText;


    // UI-елемент для показу
    // кількості куплених бізнесів
    public TextMeshProUGUI
        totalBusinessesText;



    void Update()
    {
        // Якщо менеджера валюти нема —
        // нічого не оновлюю
        if(
            CurrencyManager
            .Instance
            == null
        )
        {
            return;
        }



        // Загальна кількість кліків
        totalClicksText.text =

        "Total number of clicks"

        +

        "\t\t"

        +

        CurrencyManager
        .Instance
        .totalClicks;



        // Зароблено на кліках
        moneyFromClicksText.text =

        "Money From Clicks"

        +

        "\t\t$"

        +

        System.Math.Round(

        CurrencyManager
        .Instance
        .totalMoneyFromClicks
        );



        // Якщо бізнес менеджер існує —
        // показую кількість куплених бізнесів
        if(
            BusinessManager
            .Instance
            != null
        )
        {
            totalBusinessesText.text =

            "Purchased companies"

            +

            "\t"

            +

            BusinessManager
            .Instance
            .businesses
            .Count;
        }
        else
        {
            // Якщо бізнесів ще нема
            totalBusinessesText.text =

            "Purchased companies"

            +

            "\t0";
        }
    }
}