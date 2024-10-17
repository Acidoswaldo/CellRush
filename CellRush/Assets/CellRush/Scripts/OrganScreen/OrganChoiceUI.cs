using UnityEngine;
using MoreMountains.Feedbacks;
using MoreMountains.Feel;
using UnityEngine.UI;
using System.Data.Common;

public class OrganChoiceUI : MonoBehaviour
{
    [SerializeField] private MMF_Player _openFeedback;
    [SerializeField] private MMF_Player _closeFeedback;
    [SerializeField] private MMF_Player _fadeInFeedback;
    [SerializeField] private MMF_Player _fadeOutFeedback;
    [SerializeField] RectTransform choiceUI;
    public bool IsOpen { get; private set; }

    public void SetChoiceUI(Transform buttonTransform)
    {
        MMF_Position openPositionFeedback = _openFeedback.GetFeedbackOfType<MMF_Position>();
        openPositionFeedback.InitialPositionTransform = buttonTransform;

        MMF_Position closePositionFeedback = _closeFeedback.GetFeedbackOfType<MMF_Position>();
        closePositionFeedback.DestinationPositionTransform = buttonTransform;

        choiceUI.position = buttonTransform.position;
        choiceUI.localScale = Vector3.zero;
    }
    public void OpenChoice()
    {
        if (IsOpen) return;
        if(_closeFeedback.IsPlaying)
        {
            _closeFeedback.StopFeedbacks();
        }
        if(_fadeOutFeedback.IsPlaying)
        {
            _fadeOutFeedback.StopFeedbacks();
        }
        
        _fadeInFeedback.PlayFeedbacks();
        IsOpen = true;
    }
    public void CloseChoice()
    {
        if (!IsOpen) return;
        if(_openFeedback.IsPlaying)
        {
            _openFeedback.StopFeedbacks();
        }
        if(_fadeInFeedback.IsPlaying)
        {
            _fadeInFeedback.StopFeedbacks();
        }
        _closeFeedback.PlayFeedbacks();
        IsOpen = false;
    }
}
