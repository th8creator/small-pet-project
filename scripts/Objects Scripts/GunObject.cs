using JetBrains.Annotations;
using UnityEngine;

public class GunObject : ObjectBehaviour
{

    public PlayerGunBehaviour playerGunBehaviour;

    public override void GetPrizeOnDestroy()
    {
        base.GetPrizeOnDestroy();
        playerGunBehaviour.UpgradeGun();
    }
}
