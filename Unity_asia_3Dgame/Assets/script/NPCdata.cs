
using UnityEngine;


[CreateAssetMenu(fileName ="NPC 資料" , menuName ="MU/NPC 資料")]
public class NPCdata : ScriptableObject
{
    [Header("第一段對話") , TextArea(1,5)]
    public string conversationA;
    [Header("第二段對話"), TextArea(1, 5)]
    public string conversationB;
    [Header("第三段對話"), TextArea(1, 5)]
    public string conversationC;

    [Header("任務需求項目數量")]
    public int count;

    [Header("已經取得項目數量")]
    public int countCurrent;

}
