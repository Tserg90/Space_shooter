using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Settings", menuName = "Game Settings", order = 51)]
public class GameSettings : ScriptableObject
{
    [SerializeField] private int playerHp = 3;
    [SerializeField] private int playerSpeed = 15;
    [SerializeField] private int meteor1Hp = 1;
    [SerializeField] private int meteor2Hp = 2;
    [SerializeField] private float reloadGun = 0.3f;
    public int PlayerHp => this.playerHp;
    public int PlayerSpeed => this.playerSpeed;
    public int Meteor1Hp => this.meteor1Hp;
    public int Meteor2Hp => this.meteor2Hp;
    public float ReloadGun => this.reloadGun;
}
