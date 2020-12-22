
using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class NPC: MonoBehaviour
{
    [Header("NPC資料")]
    public NPCdata data;
    [Header("對話框")]
    public GameObject dialog;
    [Header("對話內容")]
    public Text textContent;
    [Header("對話者名稱")]
    public Text textname;
    [Header("對話間隔")]
    public float interval = 0.2f;

    ///玩家是否進入感應區
    public bool playerInArea;

    //定義列舉 enum (下拉式選單，只能選一個)
    public enum NPCState
    { 
       FirstDialog, Missioning, Finish
    }

    //列舉欄位
    //修飾詞 列舉名稱 自訂欄位名稱  指定預設值
    public NPCState state = NPCState.FirstDialog;

    /* 協同程序
    private void Start()
    {
        //啟動協程
        StartCoroutine(Test());
    }
    
    private IEnumerator Test()
    {
        print("嗨~");
        yield return new WaitForSeconds(1.5f);
        print("嗨~我是一點五秒後");
        yield return new WaitForSeconds(2);
        print("嗨~又過了兩秒鐘了喔");
    }
    */

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "ming")
        {
            playerInArea = true;
           StartCoroutine(Dialog());

        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "ming")
        {
            playerInArea = false;
            stopdialog();
        }
    }

    /// <summary>
    /// 停止對話
    /// </summary>
    private void stopdialog()
    {
        dialog.SetActive(false);   //關閉對話框
        StopAllCoroutines();       //關閉所有協程
    }

    /// <summary>
    /// 開始對話
    /// </summary>
    private IEnumerator Dialog()
    {
        /**
        // print(data.conversationA);
        // print(data.conversationA[5]);
        */

        //顯示對話框
        dialog.SetActive(true);
        //清空文字
        textContent.text = "";
        //對話者名稱 指定為 此物件的名稱
        textname.text = name;

        //要說的對話
        string dialogString = data.conversationB;
        switch (state)
        {
            case NPCState.FirstDialog:
            dialogString = data.conversationA;
            break;
            case NPCState.Missioning:
            dialogString = data.conversationB;
            break;
            case NPCState.Finish:
            dialogString = data.conversationC;
            break;
        }        

        //for 迴圈:重複處裡相同程式
        //字串的長度 dialogA.Length

        for (int i = 0; i < dialogString.Length; i++)
        {
            //print(data.conversationA[i]);
            //文字串聯
            textContent.text += dialogString[i] + "";
            yield return new WaitForSeconds(interval);
        }
    }
}
