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

    public TextMeshProUGUI
    empireValueText;

    public TextMeshProUGUI
    businessIncomeText;

    // UI-елемент для показу кількості куплених бізнесів
    public TextMeshProUGUI
        totalBusinessesText;



    void Update()
    {
        // Якщо менеджера валюти нема — нічого не оновлює
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



        // Якщо бізнес менеджер існує - показую кількість куплених бізнесів
        if(
            BusinessManager
            .Instance
            != null
        )
        {
            totalBusinessesText.text =

            "Purchased companies"

            +

            "\t\t"

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
    if (
    empireValueText != null
    &&
    BusinessManager.Instance != null
)
{
    empireValueText.text =

    "Empire Value"

    +

    "\t$"

    +

    System.Math.Round(

    BusinessManager
    .Instance
    .GetEmpireValue()

    );
    
}
    
    if (
    businessIncomeText != null
    &&
    BusinessManager.Instance != null
)
{
    businessIncomeText.text =

    "Business Income"

    +

    "\t\t\t$"

    +

    System.Math.Round(

    BusinessManager
    .Instance
    .GetTotalIncome()

    )

    +

    "";
}
}
}   