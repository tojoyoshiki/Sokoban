using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManegerScript : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject otherPrefab;
    //配列
    int[,] map;
    GameObject[,] field;
    private Vector2Int GetPlayerIndex()
    {
        for (int y = 0; y < field.GetLength(0); y++)
        {
            for (int x = 0; x < field.GetLength(1); x++)
            {
                if (field[y, x] == null) { continue; }
                if (field[y, x].tag == "Player")
                {
                    return new Vector2Int(x, y);
                }
            }
        }
        return new Vector2Int(-1, -1);
    }

    bool MoveNumber(Vector2Int moveFrom, Vector2Int moveTo)
    {
        //移動先が範囲外なら移動不可
        if (moveTo.y < 0 || moveTo.y >= field.GetLength(0)) { return false; }
        if (moveTo.x < 0 || moveTo.x >= field.GetLength(2)) { return false; }

        //if (map[moveTo] == 2)
        //{
        //    int velocity = moveTo - moveFrom;

        //    bool success = MoveNumber(2, moveTo, moveTo + velocity);
        //    //もし箱が移動失敗したら、移動可能かどうかをboolで記録
        //    if (!success) { return false; }
        //}

        field[moveTo.y, moveTo.x] = field[moveFrom.y, moveFrom.x];
        field[moveFrom.y, moveFrom.x] = null;
        field[moveFrom.y, moveFrom.x].transform.position =
            new Vector3(moveTo.x, map.GetLength(0) - moveTo.y, 0);
        return true;
    }

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
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Vector2Int playerIndex = GetPlayerIndex();
            MoveNumber(playerIndex, new Vector2Int(playerIndex.x, playerIndex.y + 1));
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Vector2Int playerIndex = GetPlayerIndex();
            MoveNumber(playerIndex, new Vector2Int(playerIndex.x, playerIndex.y - 1));
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Vector2Int playerIndex = GetPlayerIndex();
            MoveNumber(playerIndex, new Vector2Int(playerIndex.x + 1, playerIndex.y));
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Vector2Int playerIndex = GetPlayerIndex();
            MoveNumber(playerIndex, new Vector2Int(playerIndex.x - 1, playerIndex.y));
        }
    }
}