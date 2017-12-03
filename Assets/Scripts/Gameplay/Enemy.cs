using System.Collections;
using System.Collections.Generic;
using EZCameraShake;
using UnityEngine;
using Pathfinding;

public enum EnemyType
{
    Shocker,
    Blaster,
}

public class Enemy : Entity
{
    public EnemyType Type;
    public float Damage = 5f;

    private AudioSource[] _as;

    private bool _isDead;

    public bool _wasHit;

    public static int LastBlastIndex, LastShotIndex;

	new void Start ()
	{
	    base.Start();
        var aiPath = GetComponent<AIPath>();
	    aiPath.target = _game.Character.transform;

	    _as = GetComponents<AudioSource>();
	}

    new void Update ()
	{
	    //var direction = (_game.Character.transform.position - transform.position).normalized;

	    //_velocity += (Vector2)direction * Acceleration * Time.deltaTime;

        transform.localScale = Vector3.one * (0.5f + CurrentEnergy / MaxEnergy);

        //base.Update();

	    if (_isDead && !_as[1].isPlaying)
	    {
	        Destroy(gameObject);
            _game.KillCount++;
	    }
	}

    new void FixedUpdate()
    {
        
    }

    void LateUpdate()
    {
        if (_isDead || !_wasHit && _as[0].isPlaying)
        {
            _as[0].Stop();
        }
        _wasHit = false;
    }

    protected override void OnEnergyDepleted()
    {
        if (_isDead) return;
        Debug.Log(string.Format("Depleted, Current Energy: {0}", CurrentEnergy));
    }

    protected override void OnMaxEnergyReached()
    {
        if (_isDead) return;

        Debug.Log(string.Format("Max, Current Energy: {0}", CurrentEnergy));
        _game.Enemies.Remove(this);
        transform.localScale = Vector3.zero;
        _isDead = true;
        GetComponent<AIPath>().target = null;
        PlayBlast();

        var shaker = CameraShaker.Instance;
        shaker.DefaultPosInfluence = new Vector3(0.25f, 0.25f, 0.0f);
        shaker.DefaultRotInfluence = new Vector3(0.0f, 0.0f, 0.25f);
        shaker.ShakeOnce(4.0f, 7.0f, 0.1f, 0.6f);
    }

    public override void DoLaserHit(float energy)
    {
        if (_isDead) return;
        
        AddEnergy(energy);
        _wasHit = true;
        PlayHeatsound();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
    }

    void OnTriggerExit2D(Collider2D other)
    {
    }

    public void PlayBlast()
    {
        var index = (LastShotIndex + 1 + Random.Range(0, 4)) % 4;
        LastShotIndex = index;
        Debug.Log(index);
        _as[1].clip = GameManager.Instance.Blasts[Random.Range(0, 4)];
        _as[1].Play();
    }

    public void PlayHeatsound()
    {
        if (_as[0].isPlaying) return;

        var game = GameManager.Instance.ActiveStrategy as StrategyGame;
        var period = MaxEnergy / game.LaserDamage;

        _as[0].clip = GameManager.Instance.Heats[Random.Range(0, 2)];
        _as[0].time = _as[0].clip.length - period - 1.0f;
        _as[0].Play();
    }
}
