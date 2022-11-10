using NBGame.backpack;
using NBGame.saveSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class backpackController : MonoBehaviour, playerInfoLoader
{
    //itemType is item type and int is the amount
    public static Dictionary<itemType, int> PlayerBackpack = new Dictionary<itemType, int>();



    public static void addToBackPack(itemType itemType, int amount)
    {
        if (PlayerBackpack.ContainsKey(itemType))
        {

            PlayerBackpack[itemType] += amount;
        }
        else
        {
            PlayerBackpack.Add(itemType, amount);
        }
    }

    public static void addToBackPack(itemType itemType)
    {
        addToBackPack(itemType, 1);
    }

    public void LoadGame(playerInfo data)
    {
        PlayerBackpack=new Dictionary<itemType, int>();
        if (data.backpackSave!=null) {
            foreach (playerInfo.backpackItem item in data.backpackSave)
            {
                PlayerBackpack.Add(item.type, item.amount);
            }
        }
    }

    public void saveGame(ref playerInfo data)
    {
        data.saveBackpack(PlayerBackpack);
    }
}

