using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class OwnedBusinessCard :
MonoBehaviour
{
    [Header("UI")]
    public Image iconImage;

    public TextMeshProUGUI
        nameText;

    public TextMeshProUGUI
        incomeText;

    public TextMeshProUGUI
        upgradePriceText;



    private int level = 1;

    private BusinessData data;



    //---------------------------------
    // Створюю нову компанію
    //---------------------------------

    public void SetupCard(
        BusinessData business
    )
    {
        data = business;


        if (
            iconImage != null
            &&
            business.icon != null
        )
        {
            iconImage.sprite =
                business.icon;
        }


        if (nameText != null)
        {
            nameText.text =
                business.businessName;
        }


        RefreshUI();


        // Оновлюю загальний дохід
        // після створення бізнесу
        if (
            BusinessManager
            .Instance != null
        )
        {
            BusinessManager
            .Instance
            .UpdateGlobalIncome();
        }
    }



    //---------------------------------
    // Кнопка апгрейду
    //---------------------------------

    public void Upgrade()
    {
        double price =
            GetUpgradePrice();


        // Якщо грошей мало —
        // просто виходжу
        if (
            CurrencyManager
            .Instance
            .balance < price
        )
        {
            return;
        }


        CurrencyManager
        .Instance
        .balance -= price;


        level++;


        CurrencyManager
        .Instance
        .UpdateUI();


        RefreshUI();



        // Я забував оновити
        // глобальний дохід,
        // через це зверху були
        // старі цифри
        if (
            BusinessManager
            .Instance != null
        )
        {
            BusinessManager
            .Instance
            .UpdateGlobalIncome();
        }
    }



    //---------------------------------
    // Поточний дохід бізнесу
    //---------------------------------

    public double GetIncome()
    {
        return System.Math.Round(

            data.baseIncome *

            Mathf.Pow(

                BusinessManager
                .Instance
                .incomeMultiplier,

                level - 1

            )

        );
    }



    //---------------------------------
    // Ціна апгрейду
    //---------------------------------

    public double GetUpgradePrice()
    {
        return System.Math.Round(

            data.basePrice *

            Mathf.Pow(

                BusinessManager
                .Instance
                .upgradeCostMultiplier,

                level

            )

        );
    }



    //---------------------------------
    // Оновлення UI картки
    //---------------------------------

    public void RefreshUI()
    {
        if (
            incomeText != null
        )
        {
            incomeText.text =

            "$"

            +

            GetIncome()

            +

            " <size=40%><color=#FFFFFF99>per hour</color></size>";
        }



        if (
            upgradePriceText != null
        )
        {
            upgradePriceText.text =

            "$"

            +

            GetUpgradePrice();
        }



        // Поки прибираю рівень,
        // потім зроблю окремо
        if (
            nameText != null
        )
        {
            nameText.text =
                data.businessName;
        }
    }
}