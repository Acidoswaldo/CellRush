using UnityEngine;
using Sirenix.OdinInspector;

public class GameData : MonoBehaviour
{
    public static GameData Instance { get; private set; }

    // Currency data
    [SerializeField, ReadOnly, BoxGroup("Currency")] private Number _currencyEnergy;
    [SerializeField, ReadOnly, BoxGroup("Currency")] private Number _currencyADN;
    [SerializeField, ReadOnly, BoxGroup("Currency")] private Number _currencyGoldenAtoms;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            InitializeData();
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void InitializeData()
    {

    }

    // Currency methods
    public Number GetCurrencyEnergy() => _currencyEnergy;
    public Number GetCurrencyADN() => _currencyADN;
    public Number GetCurrencyGoldenAtoms() => _currencyGoldenAtoms;

    public void ModifyCurrencyEnergy(Number amount) => _currencyEnergy = NumberHandler.Add(_currencyEnergy, amount);
    public void ModifyCurrencyADN(Number amount) => _currencyADN = NumberHandler.Add(_currencyADN, amount);
    public void ModifyCurrencyGoldenAtoms(Number amount) => _currencyGoldenAtoms = NumberHandler.Add(_currencyGoldenAtoms, amount);

    // Player progress method

    // Game settings methods
}
