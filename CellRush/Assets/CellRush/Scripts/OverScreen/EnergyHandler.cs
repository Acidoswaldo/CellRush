using Unity.VisualScripting;
using UnityEngine;
using AssetKits.ParticleImage;
using TMPro;

public class EnergyHandler : MonoBehaviour
{
    private CurrencyManager currencyManager;
    [SerializeField] private Number energyPerSecond;
    [SerializeField] private ParticleImage energyParticle;
    [SerializeField, Range(0.1f, 1f)] private float energyInterval = 1.0f; // Interval in seconds to apply energy
    [SerializeField] private TextMeshProUGUI energyPerSecText;
    private float timeSinceLastEnergy;

    void Start()
    {
        currencyManager = CurrencyManager.Instance;
        timeSinceLastEnergy = 0f;
    }

    void Update()
    {
        CheckParticleEffect();
        energyPerSecText.text = energyPerSecond.ToString() + "/s";
        timeSinceLastEnergy += Time.deltaTime;

        if (timeSinceLastEnergy >= energyInterval)
        {
            Number energyToAdd = energyPerSecond * (timeSinceLastEnergy / 1f);
            AddEnergy(energyToAdd);
            timeSinceLastEnergy = 0f;
        }
    }

    void CheckParticleEffect()
    {
        if (energyPerSecond.mantissa == 0 && energyParticle.isPlaying)
        {
            energyParticle.Stop();
        }
        else if (energyPerSecond.mantissa > 0 && !energyParticle.isPlaying)
        {
            energyParticle.Play();
        }
    }

    public void AddEnergy(Number amount)
    {
        currencyManager.AddEnergy(amount);
    }
}
