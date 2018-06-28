namespace U16procon {
  namespace Item {
    class Item {

      /*
        周囲のアイテムがあれば取る
        注：優先度は上>右>左>下
        data:   周囲情報
        return: 行動コード
                周囲にアイテムがない場合は-1を返却します
       */
      public int GetItem(int[] data) {
        if (data[1] == (int)Encode.Field.Item) return (int)Encode.Action_encode.Walkup();
        else if (data[5] == (int)Encode.Field.Item) return (int)Encode.Action_encode.Walkright();
        else if (data[3] == (int)Encode.Field.Item) return (int)Encode.Action_encode.Walkleft();
        else if (data[7] == (int)Encode.Field.Item) return (int)Encode.Action_encode.Walkdown();
        else return -1;
      }
    }
  } // namespace Item
} // namespace U16procon
