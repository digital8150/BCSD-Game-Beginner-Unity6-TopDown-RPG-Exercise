using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering;
public class QuestData
{
    public string questName;
    public int[] npcId;

    public QuestData(string name, int[] npcId)
    {
        this.questName = name;
        this.npcId = npcId;
    }
}
