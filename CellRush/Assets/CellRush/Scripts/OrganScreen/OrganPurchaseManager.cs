using UnityEngine;

public class OrganPurchaseManager : MonoBehaviour
{
    public OrganChoiceUI organChoiceUI;
    public OrganConfirmUI organConfirmUI;

    public static OrganPurchaseManager instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void NewOrganPressed(NewOrganButton organButton)
    {
        organChoiceUI.SetChoiceUI(organButton.transform);
        organChoiceUI.OpenChoice();
        Debug.Log("New Organ Pressed");
    }

     public void NewOrganCancelled()
    {
        organChoiceUI.CloseChoice();
        Debug.Log("New Organ Cancelled");
    }
}
