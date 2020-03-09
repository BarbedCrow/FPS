using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firearm : Actor
{

    [SerializeField]
    private FirearmSettings settings;

    public void TryStartFire()
    {
        isFiring = true;
    }

    public void StopFire()
    {
        isFiring = false;
        firstShotWasDone = false;
    }

    #region protected

    protected override void Update()
    {
        base.Update();

        if (!isFiring) return;

        if (Time.time < timeForNextShot) return;

        if (settings.Type != FirearmType.AUTO && firstShotWasDone) return;

        Shoot();
    }

    #endregion

    #region private

    private bool isFiring = false;
    private bool firstShotWasDone = false;
    private float timeForNextShot = -1;

    private void Shoot()
    {
        timeForNextShot = Time.time + settings.TimeBetweenShots;
        firstShotWasDone = true;
    }

    #endregion

}

[System.Serializable]
public class FirearmSettings
{
    [SerializeField]
    private float timeBetweenShots;
    public float TimeBetweenShots { get { return timeBetweenShots; } set { } }

    [SerializeField]
    private FirearmType type;
    public FirearmType Type { get { return type; } set { } }
}

[SerializeField]
public enum FirearmType
{
    SINGLE,
    AUTO,
    BURST
}
