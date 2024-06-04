using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Project_GG
{
    static public class _Check
    {
        // 적 찾기
        static public int Check_SearchEnemy_First()
        {
            int iResult = -1;

            for (int i = 0; i < Phase.aTargets.Length; i++)
            {
                if (Phase.aTargets[i].iId > 0)
                {
                    iResult = i;
                    break;
                }
            }

            if (iResult >= 0)
            {
                return iResult;
            }
            else
            {
                Console.WriteLine("적 찾을 수 없음");
                return iResult;
            }
        }

        // 플레이어 찾기
        static public int Check_SearchPlayer()
        {
            int iResult = -1;

            for (int i = 0; i < Phase.aTargets.Length; i++)
            {
                if (Phase.aTargets[i].iId == 0)
                {
                    iResult = i;
                    break;
                }
            }

            if (iResult >= 0)
            {
                return iResult;
            }
            else
            {
                Console.WriteLine("플레이어 찾을 수 없음");
                return iResult;
            }
        }


        // 좌표에 존재하는 대상
        static public int Check_TargetOnMap(int x, int y)
        {
            // 아무것도 존재하지 않음
            int iResult = -1;

            // 플레이어 존재 좌표
            int iPlayer = _Check.Check_SearchPlayer();
            if (Phase.aTargets[iPlayer].x == x && Phase.aTargets[iPlayer].y == y)
            {
                iResult = 1;
            }

            // 적
            int iEnemy = _Check.Check_SearchEnemy_First();
            if (Phase.aTargets[iEnemy].x == x && Phase.aTargets[iEnemy].y == y)
            {
                iResult = 100 + Phase.aTargets[iEnemy].iId;
            }

            return iResult;
        }
    }
}
