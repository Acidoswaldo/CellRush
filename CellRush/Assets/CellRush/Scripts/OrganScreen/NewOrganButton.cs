using UnityEngine;

public class NewOrganButton : MonoBehaviour
{
    public int ID;
    public void OnButtonPressed()
    {
        OrganPurchaseManager.instance.NewOrganPressed(this);
    }
}