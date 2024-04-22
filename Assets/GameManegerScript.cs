using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManegerScript : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject otherPrefab;
    //配列
    int[,] map;
    GameObject[,] field;

    //void PrintArray()
    //{
    //    string debugText = "";
    //    for (int i = 0; i < map.Length; i++)
    //    {
    //        debugText += map[i].ToString() + ",";
    //    }
    //    Debug.Log(debugText);
    //}

    private Vector2Int GetPlayerIndex()
    {
        for (int y = 0; y < field.GetLength(0); y++)
        {
            for (int x = 0; x < field.GetLength(1); x++)
            {
                //Nullチェック

                if (field[y, x].tag == "Player")
                {
                    return new Vector2Int(x, y);
                }
            }
        }
        return new Vector2Int(-1, -1);
    }

    //bool MoveNumber(int number, int moveFrom, int moveTo)
    //{
    //    //移動先が範囲外なら移動不可
    //    if (moveTo < 0 || moveTo >= map.Length) { return false; }
    //    //移動先に２（箱）がいたら
    //    if (map[moveTo] == 2)
    //    {
    //        int velocity = moveTo - moveFrom;

    //        bool success = MoveNumber(2, moveTo, moveTo + velocity);
    //        //もし箱が移動失敗したら、移動可能かどうかをboolで記録
    //        if (!success) { return false; }
    //    }
    //    map[moveTo] = number;
    //    map[moveFrom] = 0;
    //    return true;
    //}

    void Start()
    {
        //マップの生成
        map = new int[,] {
         { 0, 0, 0, 0, 0 },
         { 0, 0, 1, 0, 0 },
         { 0, 0, 0, 0, 0 },
        };
        //フィールドサイズ決定
        field = new GameObject
        [
            map.GetLength(0),
            map.GetLength(1)
        ];
        //マップに応じて描画
        for (int y = 0; y < map.GetLength(0); y++)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                if (map[y, x] == 1)
                {
                    field[y, x] = Instantiate(
                        playerPrefab,
                        new Vector3(x, map.GetLength(0) - y, 0.0f),
                        Quaternion.identity
                        );
                }
                else
                {
                    field[y, x] = Instantiate(
                        otherPrefab,
                        new Vector3(x, map.GetLength(0) - 1 - y, 0.0f),
                        Quaternion.identity
                        );
                }
            }
        }

        string debugText = "";

        for (int y = 0; y < map.GetLength(0); y++)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                debugText += map[y, x].ToString() + ".";
            }
            debugText += "\n";
        }
        Debug.Log(debugText);
    }
}

//PrintArray();
//    }
//}

//    void Update()
//    {
//        // 右矢印キーが押されたときの処理
//        if (Input.GetKeyDown(KeyCode.RightArrow))
//        {
//            // プレイヤーの位置を示すインデックスを初期化
//            int playerIndex = GetPlayerIndex();
//            MoveNumber(1,playerIndex, playerIndex + 1);
//            PrintArray();
//        }
//    }
//}
