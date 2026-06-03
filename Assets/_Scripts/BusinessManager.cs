using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BusinessManager :
MonoBehaviour
{
    public static
    BusinessManager Instance;



    public GameObject
        ownedBusinessPrefab;


    public Transform
        ownedContainer;



    [Header("Глобальна статистика")]

    public TextMeshProUGUI
        totalIncomeText;



    [Header("Множники")]

    public float
        incomeMultiplier = // На це число множиться дохід кожного бізнесу
        1.25f;


    public float
        upgradeCostMultiplier = // На це число множиться ціна апгрейду кожного бізнесу
        1.05f;




    // Зберігає усі куплені бізнеси щоб рахувати прибуток та показувати статистику профілю
    public List
    <OwnedBusinessCard>

    businesses =

    new();


    float timer;


    void Awake()
    {
        Instance = this;
    }


    void Update()
    {
        timer +=
        Time.deltaTime;


        // Пасивний дохід кожні 5 для демки але стандарт 60 сек
        if(
            timer >= 5f
        )
        {
            timer = 0;

            AddPassiveIncome();
        }
    }



    public void BuyBusiness( // метод викликається при купівлі нового бізнесу
        BusinessData data
    )
    {
        GameObject obj =

        Instantiate(

        ownedBusinessPrefab,

        ownedContainer

        );


        OwnedBusinessCard card =

        obj.GetComponent
        <OwnedBusinessCard>();



        if(card == null)
            return;



        card.SetupCard(
            data
        );



        businesses.Add(
            card
        );


        UpdateGlobalIncome();
    }



    void AddPassiveIncome()
    {
        double total = 0;


        foreach(
            var business
            in businesses
        )
        {


            if(
                business
                ==
                null
            )
                continue;



            total +=

            business
            .GetIncome()/ 60;

        }


        if(
            CurrencyManager
            .Instance
            ==
            null
        )
            return;


        CurrencyManager
        .Instance
        .balance += total;


        CurrencyManager
        .Instance
        .UpdateUI();
    }

    // Плашка загального доходу усіх компаній
    public void UpdateGlobalIncome()
    {
        double total = 0;

        foreach(
            var business
            in businesses
        )
        {
            if(
                business
                ==
                null
            )
                continue;



            total +=

            business
            .GetIncome();
        }

        if(
            totalIncomeText
            !=
            null
        )
        {
            totalIncomeText.text =

            "$"

            +

            System.Math
            .Round(
                total
            );
        }
    }
    public double GetEmpireValue()
{
    double total = 0;

    foreach (var business in businesses)
    {
        if (business == null)
            continue;

        total += business.GetTotalValue();
    }

    if (CurrencyManager.Instance != null)
    {
        total += CurrencyManager.Instance.balance;
    }

    return System.Math.Round(total);
}
    public double GetTotalIncome()
{
    double total = 0;

    foreach (
        var business
        in businesses
    )
    {
        if (
            business == null
        )
        {
            continue;
        }

        total +=
            business.GetIncome();
    }

    return total;
}
}