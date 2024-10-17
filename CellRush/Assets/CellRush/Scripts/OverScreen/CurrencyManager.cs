using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    public static CurrencyManager Instance { get; private set; }

    [SerializeField] private PointHandler energyHandler;
    [SerializeField]private PointHandler adnHandler;
    [SerializeField]private PointHandler goldenAtomsHandler;

    private void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Energy methods
    public void AddEnergy(Number amount)
    {
        if (energyHandler != null)
        {
            energyHandler.AddPoints(amount);
            GameData.Instance.ModifyCurrencyEnergy(energyHandler.GetPoints());
        }
    }

    public void RemoveEnergy(Number amount)
    {
        if (energyHandler != null)
        {
            energyHandler.SubtractPoints(amount);
            GameData.Instance.ModifyCurrencyADN(energyHandler.GetPoints());
        }
    }

    public Number GetEnergy() => energyHandler != null ? energyHandler.GetPoints() : new Number(0, 0);

    // ADN methods
    public void AddADN(Number amount)
    {
        if (adnHandler != null)
        {
            adnHandler.AddPoints(amount);
            GameData.Instance.ModifyCurrencyADN(adnHandler.GetPoints());
        }
    }

    public void RemoveADN(Number amount)
    {
        if (adnHandler != null)
        {
            adnHandler.SubtractPoints(amount);
            GameData.Instance.ModifyCurrencyADN(adnHandler.GetPoints());
        }
    }

    public Number GetADN() => adnHandler != null ? adnHandler.GetPoints() : new Number(0, 0);

    // GoldenAtoms methods
    public void AddGoldenAtoms(Number amount)
    {
        if (goldenAtomsHandler != null)
        {
            goldenAtomsHandler.AddPoints(amount);
            GameData.Instance.ModifyCurrencyGoldenAtoms(goldenAtomsHandler.GetPoints());
        }
    }

    public void RemoveGoldenAtoms(Number amount)
    {
        if (goldenAtomsHandler != null)
        {
            goldenAtomsHandler.SubtractPoints(amount);
            GameData.Instance.ModifyCurrencyGoldenAtoms(goldenAtomsHandler.GetPoints());
        }
    }

    public Number GetGoldenAtoms() => goldenAtomsHandler != null ? goldenAtomsHandler.GetPoints() : new Number(0, 0);
}