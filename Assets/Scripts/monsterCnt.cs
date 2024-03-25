using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterCnt : MonoBehaviour
{
    // Start is called before the first frame update
    private monsterManage monsterManage;
    void Start()
    {
        GameObject monsterManager = GameObject.Find("monsterManager");
        monsterManage = monsterManager.GetComponent<monsterManage>();
        monsterManage.monsterCnt++;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void moncntjian()
    {
        monsterManage.monsterCnt--;
    }
}
