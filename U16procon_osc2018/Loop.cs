namespace U16procon {
  namespace Loop {
    public class Loop {
      static short[] code_box = { 1, 2, 3, 4, 5, 6 };
      private static short old_code = 0;

      /*
        行動コードはこの関数で保存する
        code:行動コード
        return:true(Loop検知)
               false(Loop未検知)
       */
      public bool CodeSet(int code) {
        if (code != old_code) {
          for (int i = 4; i >= 0; i--) {
            code_box[i + 1] = code_box[i];
          }
          code_box[0] = (short)code;
          old_code = (short)code;
        }

        return LoopCheck();
      }

      public void LoopReset() {
        for (int i = 0; i < code_box.Length; i++ ) {
          code_box[i] = (short)i;
        }
      }

      private bool LoopCheck() {
        foreach(short i in code_box) {
          System.Console.Write(i + ",");
        }
        System.Console.WriteLine();

        if (code_box[0] == code_box[2] && code_box[2] == code_box[4] &&
            code_box[1] == code_box[3] && code_box[3] == code_box[5] ) {
          System.Console.WriteLine("Loop検知1");
          if ((code_box[0] == Encode.Action_encode.Walkup() &&
               code_box[1] == Encode.Action_encode.Walkdown()) ||
              (code_box[0] == Encode.Action_encode.Walkdown() &&
               code_box[1] == Encode.Action_encode.Walkup()) ||
              (code_box[0] == Encode.Action_encode.Walkleft() &&
               code_box[1] == Encode.Action_encode.Walkright()) ||
              (code_box[0] == Encode.Action_encode.Walkright() &&
               code_box[1] == Encode.Action_encode.Walkleft()) ) {

            System.Console.WriteLine("Loop検知2");
            return true;
          }
        }
        return false;
      }
    }
  } // namespace Loop
} // namespace U16procon
