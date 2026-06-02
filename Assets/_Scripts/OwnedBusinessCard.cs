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

    public TextMeshProUGUI
        levelLimitText;

    private int level = 1;

    private BusinessData data;




    // Створює нову компанію
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

        // Оновлюється загальний дохід при створенні компанії
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


    // Кнопка апгрейду
    public void Upgrade()
    {
        if (level >= data.maxLevel)
    {
     return;
    }
        
        double price =
            GetUpgradePrice();

        // Перевірка, чи вистачає грошей на апгрейд
        if (
            CurrencyManager
            .Instance
            .balance < price
        )
        {
            return;
        }

        level++;

        CurrencyManager
        .Instance
        .balance -= price;

        CurrencyManager
        .Instance
        .UpdateUI();

        RefreshUI();

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


    // Поточний дохід бізнесу
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


    // Ціна апгрейду
public double GetUpgradePrice()
{
    return System.Math.Round(

        (data.basePrice * 0.9f) * //-10% від базової ціни

        Mathf.Pow(

            BusinessManager
            .Instance
            .upgradeCostMultiplier,

            level

        )

    );
}



    // Оновлення UI картки
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

        if (
            levelLimitText != null
        )
        {
            levelLimitText.text =
                level +
                "/" +
                data.maxLevel;
        }

        // Оновлення назви компанії
        if (
            nameText != null
        )
        {
            nameText.text =
                data.businessName;
        }
    }
}