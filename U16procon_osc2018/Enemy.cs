namespace U16procon {
  namespace Enemy {
    public class Enemy {

      /*
        上下左右に敵がいた場合にBlockを置く
        data:周囲情報
        return:行動コード
               周囲に敵がいなければ-1を返却します
       */
      public int GetEnemy(int[] data) {
        if (data[1] == (int)Encode.Field.Enemy) return (int)Encode.Action_encode.Putup();
        else if (data[5] == (int)Encode.Field.Enemy) return (int)Encode.Action_encode.Putright();
        else if (data[3] == (int)Encode.Field.Enemy) return (int)Encode.Action_encode.Putleft();
        else if (data[7] == (int)Encode.Field.Enemy) return (int)Encode.Action_encode.Putdown();
        else return -1;
      }
    }
  } // namespace Enemy
} // namespace U16procon
