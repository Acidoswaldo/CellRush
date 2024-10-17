using Unity.VisualScripting;
using UnityEngine;

public class PointGenerator : MonoBehaviour
{
    [SerializeField] private Enums.CurrencyType currencyType;
    [SerializeField] private Number amount;
    [SerializeField] private CurrencyManager currencyManager;
    void Start()
    {
        currencyManager = CurrencyManager.Instance;
    }
    public void AddPoints()
    {
        switch (currencyType)
        {
            case Enums.CurrencyType.Energy:
                currencyManager.AddEnergy(amount);
                break;
            case Enums.CurrencyType.ADN:
                currencyManager.AddADN(amount);
                break;
            case Enums.CurrencyType.GoldenAtoms:
                currencyManager.AddGoldenAtoms(amount);
                break;
        }
    }

    public void ModifyAmount(Number newAmount)
    {
        amount = newAmount;
    }

    public Number  Getamount()
    {
        return amount;
    }
}
