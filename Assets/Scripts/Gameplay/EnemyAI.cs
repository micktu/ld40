﻿using System;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using Pathfinding.Util;
using UnityEngine;
using Random = UnityEngine.Random;

public enum EnemyState
{
    Idle,
    SeekingTerminal,
    FollowingPath,
    Stalking,
}

public class EnemyAI : MonoBehaviour
{
    private EnemyState _state;

    private StrategyGame _game;

    private Seeker _seeker;

    private Enemy _enemy;

    private bool _isSearchingPath;

    private IMovementPlane _movementPlane;

    private ABPath _path;

    private HackingArea _currentTerminal;

    private bool _hasAggro;

    private PathInterpolator _interpolator = new PathInterpolator();

    public float TerminalRadius = 3.0f;
    public float TerminalInnerRadius = 2f;
    public float VisionRadius = 4.0f;
    public float IdlePeriod = 2.0f;

    private float _stateTime;

    private float _lastPathTime;

	void Start()
    {
		_game = GameManager.Instance.ActiveStrategy as StrategyGame;
        _seeker = GetComponent<Seeker>();
        _seeker.pathCallback = OnPathComplete;
        _enemy = GetComponent<Enemy>();

        EnterState(EnemyState.SeekingTerminal);

    }

    void Update()
    {
        if (!_isSearchingPath)
        {
            var hasVision = CheckPlayerVision();
            if (hasVision && _state != EnemyState.FollowingPath)
            {
                EnterState(EnemyState.Stalking);
            }
        }

        switch (_state)
        {
            case EnemyState.Idle:
                if (_stateTime >= IdlePeriod)
                {
                    EnterState(EnemyState.SeekingTerminal);
                }
                break;
            case EnemyState.SeekingTerminal:
                if (_isSearchingPath) break;

                var hasVision = CheckPlayerVision();
                if (hasVision)
                {
                    EnterState(EnemyState.Stalking);
                    break;
                }

                float dsq;
                var area = FindClosestHackingArea(out dsq);

                var point = (Vector3)Random.insideUnitCircle * TerminalRadius;

                if (point.x < 0 && point.x > -TerminalInnerRadius) point.x = -TerminalInnerRadius;
                else if (point.x >= 0 && point.x < TerminalInnerRadius) point.x = TerminalInnerRadius;

                if (point.y < 0 && point.y > -TerminalInnerRadius) point.y = -TerminalInnerRadius;
                else if (point.y >= 0 && point.y < TerminalInnerRadius) point.y = TerminalInnerRadius;

                point += area.transform.position;

                _seeker.StartPath(transform.position, point);
                _isSearchingPath = true;
                break;
            case EnemyState.FollowingPath:
                if (!Move())
                {
                    EnterState(EnemyState.Idle);
                }
                break;
            case EnemyState.Stalking:
                if (_isSearchingPath) break;

                _seeker.StartPath(transform.position, _game.Character.transform.position);
                _isSearchingPath = true;
                break;
        }

        _stateTime += Time.deltaTime;
    }

    public void EnterState(EnemyState state)
    {
        _state = state;
        _stateTime = 0.0f;
    }

    public bool Move()
    {
        var position = transform.position;

        _interpolator.MoveToLocallyClosestPoint(position, true, false);
        _interpolator.MoveToCircleIntersection2D(position, 0.5f, _movementPlane);
        var target = _interpolator.position;
        Vector2 dir = target - position;

        var distance = dir.magnitude + _interpolator.remainingDistance;

        if (distance <= 1.0f)
        {
            return false;
        }

        _enemy.AddSpringForce(dir, distance);
        return true;
    }

    private bool CheckPlayerVision()
    {
        var playerPosition = _game.Character.transform.position;
        var dsq = (playerPosition - transform.position).sqrMagnitude;

        if (dsq <= VisionRadius * VisionRadius)
        {
            //_hasAggro = true;
            return true;
        }

        return false;
    }

    private HackingArea FindClosestHackingArea(out float distanceSquared)
    {
        var position = transform.position;

        HackingArea closestArea = null;
        distanceSquared = Single.PositiveInfinity;

        foreach (var area in _game.HackingAreas)
        {
            var areaPosition = area.transform.position;
            var dsq = (areaPosition - position).sqrMagnitude;

            if (dsq < distanceSquared)
            {
                distanceSquared = dsq;
                closestArea = area;
            }
        }

        return closestArea;
    }

    private void OnPathComplete(Path path)
    {
        path.Claim(this);
        _isSearchingPath = false;

        if (path.error)
        {
            path.Release(this);
            return;
        }

        if (_path != null) _path.Release(this);

        _path = path as ABPath;

        var graph = AstarData.GetGraph(path.path[0]) as ITransformedGraph;
        _movementPlane = graph != null ? graph.transform : GraphTransform.identityTransform;

        if (_path.vectorPath.Count == 1)
        {
            _path.vectorPath.Add(_path.vectorPath[0]);
        }

        _interpolator.SetPath(_path.vectorPath);

        var position = transform.position;
        _interpolator.MoveToLocallyClosestPoint((position + _path.originalStartPoint) * 0.5f);
        _interpolator.MoveToLocallyClosestPoint(position);

        EnterState(EnemyState.FollowingPath);
    }
}