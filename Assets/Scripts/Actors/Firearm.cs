using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Firearm : Actor
{

    [SerializeField] private FirearmSettings settings;

    [HideInInspector] public UnityEvent OnStartReload = new UnityEvent();
    [HideInInspector] public UnityEvent OnStopReload = new UnityEvent();
    [HideInInspector] public UnityEvent OnStartFire = new UnityEvent();
    [HideInInspector] public UnityEvent OnStopFire = new UnityEvent();
    [HideInInspector] public UnityEvent OnFire = new UnityEvent();

    public FirearmSettings Settings { get { return settings; } set { } }
    public int CurrBulletsCount { get { return currBulletsCount; } set { } }
    public int CurrBulletsInClip { get { return currBulletsInClip; } set { } }

    public void StartFire()
    {
        isFiring = true;
    }

    public void StopFire()
    {
        if (isFiring)
        {
            OnStopFire.Invoke();
        }
        isFiring = false;
        firstShotWasDone = false;
    }

    public void StartReload()
    {
        if (currBulletsCount == 0 || currBulletsInClip == settings.BulletsInClip) return;
        isReloading = true;
        timeForNextReload = Time.time + settings.ReloadSpeed;
        OnStartReload.Invoke();
    }

    #region protected

    protected override void Start()
    {
        base.Start();

        currBulletsCount = settings.BulletsMax - settings.BulletsInClip;
        currBulletsInClip = settings.BulletsInClip;
    }

    protected override void Update()
    {
        base.Update();

        ReloadLogicUpdate();
        ShootLogicUpdate();
    }

    #endregion

    #region private

    private bool isReloading = false;
    private bool isFiring = false;
    private bool firstShotWasDone = false;

    private float timeForNextShot = -1;
    private float timeForNextReload = -1;

    private int currBulletsCount = 0;
    private int currBulletsInClip = 0;

    private void ShootLogicUpdate()
    {
        if (!isFiring) return;
        if (Time.time < timeForNextShot) return;
        if (settings.Type != FirearmType.AUTO && firstShotWasDone) return;
        if (currBulletsInClip <= 0) return;

        Shoot();
    }

    private void Shoot()
    {
        currBulletsInClip -= 1;
        timeForNextShot = Time.time + settings.TimeBetweenShots;
        if (!firstShotWasDone)
        {
            firstShotWasDone = true;
            OnStartFire.Invoke();
        }

        if (isReloading)
        {
            isReloading = false; // Maybe there should be some more proper logic, but for this time it's ok
        }

        //Hit detection

        var pos = settings.BulletSpawn.position;

        //calculate destination point https://stackoverflow.com/a/50746409/276052
        var tr = settings.BulletSpawn;
        var radius = Random.Range(settings.MinBulletGroupRadius, settings.MaxBulletGroupRadius); // TO DO: radius dependency of fire rate
        var r = radius * Mathf.Sqrt(Random.Range(0, 1f));
        var theta = Random.Range(0, 1f) * 2 * Mathf.PI;
        var x = r * Mathf.Cos(theta);
        var y = r * Mathf.Sin(theta);
        var endPos = tr.forward * settings.Range + tr.right * x + tr.up * y;
        Debug.DrawRay(pos, endPos, Color.red, 1);
        OnFire.Invoke();
    }

    private void OnDrawGizmos() // Debug draw
    {
        var pos = settings.BulletSpawn.position;
        UnityEditor.Handles.color = Color.green;
        var endPos = pos + settings.BulletSpawn.forward * settings.Range;
        UnityEditor.Handles.DrawWireDisc(endPos, settings.BulletSpawn.transform.forward, settings.MaxBulletGroupRadius);
    }

    private void ReloadLogicUpdate()
    {
        if (!isReloading) return;
        if (Time.time < timeForNextReload) return;

        var maxReload = settings.ReloadBulletsCount;
        var reqToReload = (maxReload > currBulletsInClip) ? maxReload - currBulletsInClip : maxReload;
        if (currBulletsCount < reqToReload)
        {
            currBulletsInClip += currBulletsCount;
            currBulletsCount = 0;
        }
        else
        {
            currBulletsCount -= reqToReload;
            currBulletsInClip += reqToReload;
        }
        if(currBulletsCount == 0 || currBulletsInClip == settings.BulletsInClip)
        {
            isReloading = false;
            OnStopReload.Invoke();
        }else if(currBulletsCount > 0 && currBulletsInClip < settings.BulletsInClip)
        {
            timeForNextReload = Time.time + settings.ReloadSpeed;
        }
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

    [SerializeField]
    private int bulletsInClip;
    public int BulletsInClip { get { return bulletsInClip; } set { } }

    [SerializeField]
    private int reloadBulletsCount;
    public int ReloadBulletsCount { get { return reloadBulletsCount; } set { } }

    [SerializeField]
    private int bulletsMax;
    public int BulletsMax { get { return bulletsMax; } set { } }

    [SerializeField]
    private int bulletDamage;
    public int BulletDamage { get { return bulletDamage; } set { } }

    [SerializeField]
    private float reloadSpeed;
    public float ReloadSpeed { get { return reloadSpeed; } set { } }

    [SerializeField]
    private float range;
    public float Range { get { return range; } set { } }

    [SerializeField]
    private float minBulletGroupRadius;
    public float MinBulletGroupRadius { get { return minBulletGroupRadius; } set { } }

    [SerializeField]
    private float maxBulletGroupRadius;
    public float MaxBulletGroupRadius { get { return maxBulletGroupRadius; } set { } }

    [SerializeField]
    private Transform bulletSpawn;
    public Transform BulletSpawn { get { return bulletSpawn; } set { } }
}

[SerializeField]
public enum FirearmType
{
    SINGLE,
    AUTO,
    BURST
}
