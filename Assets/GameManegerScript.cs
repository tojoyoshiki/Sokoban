using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManegerScript : MonoBehaviour
{
    //配列
    int[] map;

    // Start is called before the first frame update
    void Start()
    {
        map = new int[] { 0, 0, 0, 1, 0, 0, 0, 0, 0 };

        string debugText = "";
        for (int i = 0; i < map.Length; i++)
        {
            //Debug.Log(map[i] + ",");

            debugText += map[i].ToString() + ",";
        }
        Debug.Log(debugText);
    }

    // Update is called once per frame
    void Update()
    {
            // 右矢印キーが押されたときの処理
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                // プレイヤーの位置を示すインデックスを初期化
                int playerIndex = -1;
                // マップ上でプレイヤーの位置を検索する
                for (int i = 0; i < map.Length; i++)
                {
                    if (map[i] == 1)
                    {
                        playerIndex = i;
                        break;
                    }
                }
                // プレイヤーが見つかった場合
                if (playerIndex != -1)
                {
                    // プレイヤーがマップの右端にいないかチェック
                    if (playerIndex < map.Length - 1)
                    {
                        // プレイヤーを右に移動させる
                        map[playerIndex + 1] = 1;
                        // 元のプレイヤーの位置を空にする
                        map[playerIndex] = 0;
                    }
                }

                // 更新されたマップの状態をデバッグ用にログ出力する
                string debugText = "";
                for (int i = 0; i < map.Length; i++)
                {
                    debugText += map[i].ToString() + ",";
                }
                Debug.Log(debugText);
            }
    }
}
