using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CurrencyManager : MonoBehaviour
{
    public static CurrencyManager Instance;

    [Header("Економіка")]
   
[Header("Статистика")]

// рахує всі кліки
public int totalClicks = 0;

// скільки заробив кліками
public double totalMoneyFromClicks = 0;
    public double balance = 0;  
    public double moneyPerClick = 1;
    public double upgradeCost = 10;
    public int clickLevel = 1;
    public int maxLevel = 50; 

    [Header("Налаштування прогресії")] // Ці налаштування визначають, як швидко зростає дохід та вартість апгрейдів
    [Tooltip("На це число множиться дохід за клік (напр. 1.4 = +40%)")]
    public double clickMultiplier = 1.4; 
    [Tooltip("На це число множиться ціна наступного апгрейду")]
    public double costMultiplier = 1.6;

    [Header("Зв'язок з UI")]
    public TextMeshProUGUI balanceText;
    public TextMeshProUGUI perClickText;
    public TextMeshProUGUI upgradeButtonText;
    public TextMeshProUGUI levelCounterText; 
    public Button upgradeButton; 

    [Header("Дизайн кнопки MAX")]
    public Color maxLevelColor = new Color(0.1f, 0.4f, 0.1f);

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    private void Start() => UpdateUI();

    public void AddMoney()
    {
        balance += moneyPerClick;
        UpdateUI();
        totalClicks++;
        totalMoneyFromClicks += // Статистика для профілю
        moneyPerClick;
    }

    public void UpgradeClick()
    {
        if (balance >= upgradeCost && clickLevel < maxLevel)
        {
            balance -= upgradeCost;
            clickLevel++;
            
            moneyPerClick = System.Math.Round(moneyPerClick * clickMultiplier, 2); 
            upgradeCost = System.Math.Round(upgradeCost * costMultiplier); 

            UpdateUI();
        }
    }

    //ПЕРЕВІРКИ
    public void UpdateUI() // Оновлює всі елементи UI, пов'язані з валютою та апгрейдами
    {
        if (balanceText != null)
            balanceText.text = "$" + balance.ToString("N2");

        if (perClickText != null)
            perClickText.text = "$" + moneyPerClick.ToString("N2") + " per click";

        if (levelCounterText != null)
            levelCounterText.text = clickLevel + "/" + maxLevel;

        if (upgradeButtonText != null)
        {
            if (clickLevel >= maxLevel)
            {
                upgradeButtonText.text = "MAX";
                if (upgradeButton != null)
                {
                    upgradeButton.image.color = maxLevelColor;
                    upgradeButton.interactable = false; 
                }
            }
            else
            {
                upgradeButtonText.text = "UPGRADE CLICK LEVEL $" + upgradeCost.ToString("N0") + "";
            }
        }
    }
}