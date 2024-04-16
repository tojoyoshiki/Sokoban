using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManegerScript : MonoBehaviour
{
    //�z��
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
            // �E���L�[�������ꂽ�Ƃ��̏���
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                // �v���C���[�̈ʒu�������C���f�b�N�X��������
                int playerIndex = -1;
                // �}�b�v��Ńv���C���[�̈ʒu����������
                for (int i = 0; i < map.Length; i++)
                {
                    if (map[i] == 1)
                    {
                        playerIndex = i;
                        break;
                    }
                }
                // �v���C���[�����������ꍇ
                if (playerIndex != -1)
                {
                    // �v���C���[���}�b�v�̉E�[�ɂ��Ȃ����`�F�b�N
                    if (playerIndex < map.Length - 1)
                    {
                        // �v���C���[���E�Ɉړ�������
                        map[playerIndex + 1] = 1;
                        // ���̃v���C���[�̈ʒu����ɂ���
                        map[playerIndex] = 0;
                    }
                }

                // �X�V���ꂽ�}�b�v�̏�Ԃ��f�o�b�O�p�Ƀ��O�o�͂���
                string debugText = "";
                for (int i = 0; i < map.Length; i++)
                {
                    debugText += map[i].ToString() + ",";
                }
                Debug.Log(debugText);
            }
    }
}
