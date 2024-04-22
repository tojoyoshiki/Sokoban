using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManegerScript : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject otherPrefab;
    //�z��
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
                //Null�`�F�b�N

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
    //    //�ړ��悪�͈͊O�Ȃ�ړ��s��
    //    if (moveTo < 0 || moveTo >= map.Length) { return false; }
    //    //�ړ���ɂQ�i���j��������
    //    if (map[moveTo] == 2)
    //    {
    //        int velocity = moveTo - moveFrom;

    //        bool success = MoveNumber(2, moveTo, moveTo + velocity);
    //        //���������ړ����s������A�ړ��\���ǂ�����bool�ŋL�^
    //        if (!success) { return false; }
    //    }
    //    map[moveTo] = number;
    //    map[moveFrom] = 0;
    //    return true;
    //}

    void Start()
    {
        //�}�b�v�̐���
        map = new int[,] {
         { 0, 0, 0, 0, 0 },
         { 0, 0, 1, 0, 0 },
         { 0, 0, 0, 0, 0 },
        };
        //�t�B�[���h�T�C�Y����
        field = new GameObject
        [
            map.GetLength(0),
            map.GetLength(1)
        ];
        //�}�b�v�ɉ����ĕ`��
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
//        // �E���L�[�������ꂽ�Ƃ��̏���
//        if (Input.GetKeyDown(KeyCode.RightArrow))
//        {
//            // �v���C���[�̈ʒu�������C���f�b�N�X��������
//            int playerIndex = GetPlayerIndex();
//            MoveNumber(1,playerIndex, playerIndex + 1);
//            PrintArray();
//        }
//    }
//}
