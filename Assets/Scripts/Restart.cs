using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : MonoBehaviour
{
    public void RestartStatic()
    {
        HitEnemy.DeadPlayer = false;
        TimerEnemyMoveToCoffin.StartStop = true;
        OpeningTheDoor.ActiveOpenDoor = false;
        OpeningTheDoor.CrossActive = false;
        BarLoading._timer = 5f;
        Potion.PickUpVisibility = false;
        PotionSpeed.PickUpSpeed = false;
        CrossActive.crossActive = false;
        Slot._checkSlot = true;
        ActivePotionSpeed.ActiveSpeed = false;
        ActivePotionVisibility.ActiveVisibility = false;
        CrossActive.crossActive = false;
    }
}
