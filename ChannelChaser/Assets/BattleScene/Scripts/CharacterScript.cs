using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using Random = UnityEngine.Random;

[Serializable]
public enum BattleMove
{
    Heal,
    Punch,
    Uppercut,
    FlurryOfBlows,
    StunningStrike,
    Slash,
    FeintingAttack,
    DivineSmite,
    StarlightStrike,
    FireBolt,
    RayOfFrost,
    CloudOfDaggers,
    MagicMissile,
    Shoot,
    BarbedArrow,
    SniperShot,
    ExplosiveArrow,
    QuickDraw,
    TrickShot,
    ViolentShot,
    Deadshot,
    NoMove
}

public class CharacterScript : MonoBehaviour
{

    public bool isCharactersTurn = false;
    public bool isAI = false;
    public bool isStunned = false;

    public float Health = 100;

    public int ActionPoints = 10;
    public int maxActionPoints = 10;

    public int stunAmount = 2;
    private int currentStunCounter = 0;

    public float healAmount = 25;
    public int maxHealsAllowed = 2;
    public int healsPerformed = 0;

    public static string monsterName = "none";

    //Turn Sequence
    public float elapsedTime = 0;
    public float breakTime = 2;
    static public bool isTurn = true;

    //UnnarmedDamage
    public float PunchAmount = 10;
    public float UppercutAmount = 16;
    public float FlurryOfBlowsAmount = 24;
    public float StunningStrikeAmount = 40;

    //SwordDamage
    public float SlashAmount = 12;
    public float FeintingAttackAmount = 16;
    public float DivineSmiteAmount = 25;
    public float StarlightStrikeAmount = 50;

    //MagicDamage
    public float FireBoltAmount = 14;
    public float RayOfFrostAmount = 12;
    public float CloudOfDaggersAmount = 24;
    public float MagicMissileAmount = 39;

    //CrossbowDamage
    public float ShootAmount = 11;
    public float BarbedArrowAmount = 15;
    public float SniperShotAmount = 28;
    public float ExplosiveArrowAmount = 60;

    //FlintlockDamage
    public float QuickDrawAmount = 12;
    public float TrickShotAmount = 16;
    public float ViolentShotAmount = 22;
    public float DeadshotAmount = 36;

    Dictionary<BattleMove, int> possibleMoves;
    public CharacterScript opponent;

    // Use this for initialization
    void Start () {
        possibleMoves = new Dictionary<BattleMove, int>();
        possibleMoves.Add(BattleMove.Heal, 2); //Heal
        possibleMoves.Add(BattleMove.Punch, 0); //Unarmed
        possibleMoves.Add(BattleMove.Uppercut, 0);
        possibleMoves.Add(BattleMove.FlurryOfBlows, 5);
        possibleMoves.Add(BattleMove.StunningStrike, 10);
        possibleMoves.Add(BattleMove.Slash, 0); //Sword
        possibleMoves.Add(BattleMove.FeintingAttack, 0);
        possibleMoves.Add(BattleMove.DivineSmite, 5);
        possibleMoves.Add(BattleMove.StarlightStrike, 10);
        possibleMoves.Add(BattleMove.FireBolt, 0); //Magic
        possibleMoves.Add(BattleMove.RayOfFrost, 0);
        possibleMoves.Add(BattleMove.CloudOfDaggers, 5);
        possibleMoves.Add(BattleMove.MagicMissile, 10);
        possibleMoves.Add(BattleMove.Shoot, 0); //Crossbow
        possibleMoves.Add(BattleMove.BarbedArrow, 0);
        possibleMoves.Add(BattleMove.SniperShot, 5);
        possibleMoves.Add(BattleMove.ExplosiveArrow, 10);
        possibleMoves.Add(BattleMove.QuickDraw, 0); //FlintLock
        possibleMoves.Add(BattleMove.TrickShot, 0);
        possibleMoves.Add(BattleMove.ViolentShot, 5);
        possibleMoves.Add(BattleMove.Deadshot, 10);
        possibleMoves.Add(BattleMove.NoMove, 0);
    }
	
	// Update is called once per frame
	void Update () {
        //if this is the AI and it's the AI turn and the turn break has elapsed
        if (isAI && isCharactersTurn && isTurn)
        {
            //if the AI is not stunned
            if (!isStunned)
            {
                //update the AI
                UpdateAI();
            }
            else
            {
                currentStunCounter--;

                if (currentStunCounter <= 0)
                    isStunned = false;
            }
        }

        if (isAI)
        {
            if(monsterName == "BeholderInit")
            {
                Health = 200;
                monsterName = "Beholder";
            }
            else if(monsterName == "AnimatedStatueInit")
            {
                Health = 70;
                monsterName = "Animated Statue";
            }
        }
    }


    void UpdateAI()
    {
        //priorites healing
        if (Health <= 50 && CanAffordMove(BattleMove.Heal) && healsPerformed < maxHealsAllowed)
        {
            MakeMove(BattleMove.Heal);
            healsPerformed++;
        }
        else
        {
            BattleMove selectedMove = PickRandomMove();

            if (selectedMove != BattleMove.NoMove)
            {
                MakeMove(selectedMove);
            }
            else
            {
                EndTurn();
            }
        }
    }


    public void HandleMove(BattleMove move)
    {
        switch (move)
        {
            //Unarmed
            case BattleMove.Punch:
                Health -= PunchAmount;
                break;

            case BattleMove.Uppercut:
                Health -= UppercutAmount;
                break;

            case BattleMove.FlurryOfBlows:
                Health -= FlurryOfBlowsAmount;
                break;

            case BattleMove.StunningStrike:
                Health -= StunningStrikeAmount;
                break;

            //Sword
            case BattleMove.Slash:
                Health -= SlashAmount;
                break;

            case BattleMove.FeintingAttack:
                Health -= FeintingAttackAmount;
                break;

            case BattleMove.DivineSmite:
                Health -= DivineSmiteAmount;
                break;

            case BattleMove.StarlightStrike:
                Health -= StarlightStrikeAmount;
                break;

            //Magic
            case BattleMove.FireBolt:
                Health -= FireBoltAmount;
                break;

            case BattleMove.RayOfFrost:
                Health -= RayOfFrostAmount;
                break;

            case BattleMove.CloudOfDaggers:
                Health -= CloudOfDaggersAmount;
                break;

            case BattleMove.MagicMissile:
                Health -= MagicMissileAmount;
                break;

            //Crossbow
            case BattleMove.Shoot:
                Health -= ShootAmount;
                break;

            case BattleMove.BarbedArrow:
                Health -= BarbedArrowAmount;
                break;

            case BattleMove.SniperShot:
                Health -= SniperShotAmount;
                break;

            case BattleMove.ExplosiveArrow:
                Health -= ExplosiveArrowAmount;
                break;

            //Flintlock
            case BattleMove.QuickDraw:
                Health -= ExplosiveArrowAmount;
                break;

            case BattleMove.TrickShot:
                Health -= TrickShotAmount;
                break;

            case BattleMove.ViolentShot:
                Health -= ViolentShotAmount;
                break;

            case BattleMove.Deadshot:
                Health -= DeadshotAmount;
                break;
        }
    }

    public void MakeMove(BattleMove move)
    {
        if (CanAffordMove(move))
        {
            Debug.Log("IsAI: " + isAI + " , Move: " + move);

            if (move == BattleMove.Heal)
            {
                Health += healAmount;
            }
            else
            {
                opponent.HandleMove(move);
            }

            ActionPoints -= possibleMoves[move];
            EndTurn();
        }

        if (IsOutOfMoves())
        {
            EndTurn();
        }
    }

    private void EndTurn()
    {
        isCharactersTurn = false;
        opponent.ActionPoints = 10;
        opponent.isCharactersTurn = true;
    }

    public BattleMove PickRandomMove()
    {
        Dictionary<BattleMove, int> moves = possibleMoves.Where(m => CanAffordMove(m.Key)).ToDictionary(m => m.Key, m => m.Value);

        if (moves.Count == 0)
            return BattleMove.NoMove;

        if (moves.ContainsKey(BattleMove.Heal))
            moves.Remove(BattleMove.Heal);

        if (moves.Count == 0)
            return BattleMove.NoMove;

        return moves.ElementAt(Random.Range(0, moves.Count - 1)).Key;
    }

    public void MakeMake(string move)
    {
        MakeMove((BattleMove)Enum.Parse(typeof(BattleMove), move));
    }

    public bool CanAffordMove(BattleMove desiredMove)
    {
        return possibleMoves[desiredMove] <= ActionPoints;
    }

    public bool IsOutOfMoves()
    {
        return ActionPoints < possibleMoves.Values.ToList().Min();
    }

    public void Timer()
    {
        if (isTurn == false)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime > breakTime)
            {
                elapsedTime = 0;
                isTurn = true;
            }
        }
    }
}
