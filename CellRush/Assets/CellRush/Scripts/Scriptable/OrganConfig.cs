using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "NewOrganConfig", menuName = "Organ/OrganConfig")]
public class OrganConfig : ScriptableObject
{

    [BoxGroup("BasicInfo")] public string organName;
    [BoxGroup("BasicInfo")] public string description;
    [BoxGroup("BasicInfo")] public Sprite organImage;
     [BoxGroup("BasicInfo")] public Sprite organBackgroundImage;
     [BoxGroup("BasicInfo")] public Color organColor;
      [BoxGroup("BasicInfo")] public Number baseEnergyPerCell; // Base energy generated per second
    [BoxGroup("Costs")] public Number[] baseCosts = new Number[5]; // Base cost to buy the organ and multiples.
    [BoxGroup("Costs")] public Number baseCellCost;
    
       
    
   


    [System.Serializable]
    public struct UpgradesInfo
    {
        [Range(0, 500)] public int percentageIncrease; // Percentage increase in energy generation
        public Number cost; // Base cost to upgrade
    }

    public UpgradesInfo[] upgradesInfo = new UpgradesInfo[5];




}
