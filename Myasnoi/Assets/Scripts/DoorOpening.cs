using UnityEngine;

public class DoorOpening : MonoBehaviour
{
    public GameObject DoorTutorialText;
    public Animator doorAnimator, indicatorAnimator;
    public Light PlayerFlashlight;
    public string PlayerName;
    private const string DoorOpenedEventName = "opened";
    private bool _tutorialTextWasShown = false;

    private void OnCollisionEnter(Collision collision)
    {
        const int minFlashflightrange = 8; // make separate playerflashlight class extending light;
        if (!_tutorialTextWasShown)
        {
            DoorTutorialText.SetActive(true);
            _tutorialTextWasShown = true;
        }
        else
        {
            if (collision.gameObject.name == PlayerName && !AnimatorIsPlaying() &&
                PlayerFlashlight.range < minFlashflightrange)
                DoorAnimation(open: true);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        DoorAnimation(open: false);
    }

    private void DoorAnimation(bool open)
    {
        doorAnimator.SetBool(DoorOpenedEventName, open);
        indicatorAnimator.SetBool(DoorOpenedEventName, open);
    }

    private bool AnimatorIsPlaying()
    {
        return doorAnimator.GetCurrentAnimatorStateInfo(0).length >
               doorAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime;
    }
}
