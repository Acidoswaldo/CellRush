using UnityEngine;
using MoreMountains.Feedbacks;
[RequireComponent (typeof(PointHandler))]
public class PointUIHandler : MonoBehaviour
{
    private PointHandler energyPointHandler;
    [SerializeField] private TMPro.TextMeshProUGUI text;
    [SerializeField] private MMFeedbacks onPointsChangedFeedback;

    private void Awake()
    {
        energyPointHandler = GetComponent<PointHandler>();
        if(onPointsChangedFeedback!= null) onPointsChangedFeedback = GetComponent<MMFeedbacks>();
    }

    private void OnEnable()
    {
        energyPointHandler.onPointsChanged += UpdateText;
    }

    private void OnDisable()
    {
        energyPointHandler.onPointsChanged -= UpdateText;
    }

    private void UpdateText(Number newValue)
    {
        text.text = newValue.ToString();
       if(onPointsChangedFeedback!= null)  onPointsChangedFeedback?.PlayFeedbacks();
    }
}
