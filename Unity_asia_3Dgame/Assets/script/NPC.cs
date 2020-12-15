
using UnityEngine;
using UnityEngine.UI;


public class NPC: MonoBehaviour
{
    [Header("NPC資料")]
    public NPCdata data;
    [Header("對話框")]
    public GameObject dialog;
    [Header("對話內容")]
    public Text textContent;

    ///玩家是否進入感應區
    public bool playerInArea;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "ming")
        {
            playerInArea = true;
            Dialog();

        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "ming")
        {
            playerInArea = false;
        }
    }
    private void Dialog()
    {
        // print(data.conversationA);
        // print(data.conversationA[5]);


        //for 迴圈:重複處裡相同程式
        for (int i = 0; i < data.conversationA.Length; i++)
        {
            print(data.conversationA[i]);
        }
    }
}
