using UnityEngine;

public class MultipleBosses : MonoBehaviour {
    private PortalActivation portal;
    private int bossIndex;
    private bossStatus[] bossArray;

    public int amountOfBossesInScene;
    

    private void Start()
    {
        bossArray = new bossStatus[amountOfBossesInScene];
        bossIndex = 0;
        portal = GetComponent<PortalActivation>();
        SetToAlive();
    }

    private void SetToAlive()
    {
        for (int i = 0; i < bossArray.Length; i++)
        {
            bossArray[i] = bossStatus.alive;
        }
    }

    public void NotifyThatBossIsDead()
    {
        bossArray[bossIndex] = bossStatus.dead;
        bossIndex++;
        CheckIfAnyBossIsLeft();
    }

    private void CheckIfAnyBossIsLeft()
    {
        for (int i = 0; i < bossArray.Length; i++)
        {
            if (bossArray[i].Equals(bossStatus.alive))
            {
                return;
            }
        }
        portal.ActivatePortal();
    }

    private enum bossStatus {dead=0, alive=1}
}
