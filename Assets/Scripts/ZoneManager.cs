using UnityEngine;

public class ZoneManager : MonoBehaviour
{
    public int currentZone = 0;
    private ZoneChangeTrigger[] triggers;
    private ZoneCamera[] zoneCameras;
    public bool InTransition;
    public float transitionTime = 2;
    public float currentTransitionTime;
    public PMOVE player;

    private void Awake()
    {
        triggers = FindObjectsOfType<ZoneChangeTrigger>();
        zoneCameras= FindObjectsOfType<ZoneCamera>();

        for (int i = 0; i < triggers.Length; i++)
        {
            if(triggers[i].currentZone != currentZone)
                triggers[i].gameObject.SetActive(false);
        }
    }


    public void OnPlayerEntered(int triggerID, int nextZone)
    {
        if (currentZone == triggerID && !InTransition)
        {
            currentTransitionTime = 0;
            InTransition = true;
            currentZone = nextZone;

            for (int i = 0; i < triggers.Length; i++)
            {
                triggers[i].gameObject.SetActive(false);
            }

            for (int i = 0; i < triggers.Length; i++)
            {
                if (triggers[i].currentZone == nextZone)
                {
                    triggers[i].gameObject.SetActive(true);
                }
            }

            for (int i = 0; i < zoneCameras.Length; i++)
            {
                zoneCameras[i].SetPriority(0);
            }

            for (int i = 0; i < zoneCameras.Length; i++)
            {
                if (zoneCameras[i].currentZone == nextZone)
                {
                    zoneCameras[i].SetPriority(1);
                }
            }
        }
    }

    private void Update()
    {
        currentTransitionTime += Time.deltaTime;
        if(currentTransitionTime > transitionTime) 
        {
            InTransition = false;
        }

        player.SetPlayerMovementState(!InTransition);
    }
}
