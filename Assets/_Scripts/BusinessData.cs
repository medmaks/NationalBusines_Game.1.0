using UnityEngine;

[CreateAssetMenu(fileName = "NewBusiness", menuName = "Business/Data")]
public class BusinessData : ScriptableObject
{
    public string businessName;
    public Sprite icon;
    public double basePrice;      // Початкова ціна покупки
    public double baseIncome;     // Початковий дохід
}