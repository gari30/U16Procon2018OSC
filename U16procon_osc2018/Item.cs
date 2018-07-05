namespace U16procon {
  namespace Item {
    public class Item {

      /*
        周囲のアイテムがあれば取る
        注：優先度は上>右>左>下
        data:   周囲情報
        return: 行動コード
                周囲にアイテムがない場合は-1を返却します
       */
      public int GetItem(int[] data) {
        return GetItemFirst(ref data);

      }

      private int GetItemFirst(ref int[] data) {
        if (data[1] == (int)Encode.Field.Item) return Encode.Action_encode.Walkup();
        else if (data[5] == (int)Encode.Field.Item) return Encode.Action_encode.Walkright();
        else if (data[3] == (int)Encode.Field.Item) return Encode.Action_encode.Walkleft();
        else if (data[7] == (int)Encode.Field.Item) return Encode.Action_encode.Walkdown();
        else return GetGoingItem(ref data);
      }

      private int GetGoingItem(ref int[] data) {
        byte item_count = 0;
        foreach(int i in data) {
          if (i == (int)Encode.Field.Item) {
            item_count++;
          }
        }

        if(item_count == 1) {
          if (data[0] == (int)Encode.Field.Item) {
            if (data[1] != (int)Encode.Field.Block) return Encode.Action_encode.Walkup();
            else if (data[3] != (int)Encode.Field.Block) return Encode.Action_encode.Walkleft();
            else return -1;
          }
          else if (data[2] == (int)Encode.Field.Item) {
            if (data[1] != (int)Encode.Field.Block) return Encode.Action_encode.Walkup();
            else if (data[5] != (int)Encode.Field.Block) return Encode.Action_encode.Walkright();
            else return -1;
          }
          else if (data[6] == (int)Encode.Field.Item) {
            if (data[3] != (int)Encode.Field.Block) return Encode.Action_encode.Walkleft();
            else if (data[7] != (int)Encode.Field.Block) return Encode.Action_encode.Walkdown();
            else return -1;
          }
          else if (data[8] == (int)Encode.Field.Item) {
            if (data[5] != (int)Encode.Field.Block) return Encode.Action_encode.Walkright();
            else if (data[7] != (int)Encode.Field.Block) return Encode.Action_encode.Walkdown();
            else return -1;
          }
          else {
            return -1;  //ありえない
          }
        }
        else {
          return -1;
        }
      }
    }
  } // namespace Item
} // namespace U16procon
