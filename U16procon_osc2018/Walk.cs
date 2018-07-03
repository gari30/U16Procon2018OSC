namespace U16procon {
  namespace Walk {
    using System.Collections.Generic;
    using Encode;

    public class Walk {
      static private int kcode = 0;
      static private int kMode = 1;
      private static short kcode_hold = 0;

      /*
        移動方向を指定する
        mode:移動したい方向を指定
              1:右上
              3:右下
              5:左上
              7:左下
        data:GetReadyで取得した周囲情報
       */
      public void WalkSet(int[] data, int mode) {
        kMode = mode;
        SlantingWalk(ref data);
      }

      /*
        移動方向の決定
        data:GetReadyで取得した周囲情報
       */
      public void WalkSet(int[] data) {
        SlantingWalk(ref data);
      }

      /*
        Loop検知中の移動
        data:GetReadyで取得した周囲情報
        return:true(回避行動中)
               false(回避行動中止、通常動作に戻る)
       */
      public bool LoopWalk(int[] data) {
        List<short> walk_course = new List<short> { Action_encode.Walkup(),
                                                    Action_encode.Walkdown(),
                                                    Action_encode.Walkright(),
                                                    Action_encode.Walkleft() };
        if (data[1] == (int)Field.Block) walk_course.Remove(Action_encode.Walkup());
        if (data[7] == (int)Field.Block) walk_course.Remove(Action_encode.Walkdown());
        if (data[5] == (int)Field.Block) walk_course.Remove(Action_encode.Walkright());
        if (data[3] == (int)Field.Block) walk_course.Remove(Action_encode.Walkleft());

        if (kcode_hold == 0) {
          System.Random random = new System.Random();
          int rand_data = random.Next(walk_course.Count);

          kcode_hold = walk_course[rand_data];
          kcode = walk_course[rand_data];
        }
        else {
          if (walk_course.Contains(kcode_hold) == true) {
            kcode = kcode_hold;
          }
          else {
            SlantingWalk(ref data);
            return false;
          }
        }
        return true;
      }

      /*
        移動方向情報の取得
        return:行動コード
       */
      public int WalkGet() {
        return kcode;
      }

      private void SlantingWalk(ref int[] data) {

        switch(kMode) {
          case 1://右上
            if(data[5] != (int)Field.Block) {
              kMode = 2;
              kcode = Action_encode.Walkright();
            }
            else if(data[2] != (int)Field.Block && data[1] != (int)Field.Block) {
              kMode = 1;
              kcode = Action_encode.Walkup();
            }
            else if(data[3] != (int)Field.Block) {
              kMode = 5;
              kcode = Action_encode.Walkleft();
            }
            else if(data[1] != (int)Field.Block) {
              kMode = 6;
              kcode = Action_encode.Walkup();
            }
            else// if (data[7] != (int)Field.Block)
            {
              kMode = 8;
              kcode = Action_encode.Walkdown();
            }
            break;

          case 2:
            if(data[1] != (int)Field.Block) {
              kMode = 1;
              kcode = Action_encode.Walkup();
            }
            else if(data[2] != (int)Field.Block && data[5] != (int)Field.Block) {
              kMode = 2;
              kcode = Action_encode.Walkright();
            }
            else if(data[7] != (int)Field.Block) {
              kMode = 4;
              kcode = Action_encode.Walkdown();
            }
            else if(data[5] != (int)Field.Block) {
              kMode = 2;
              kcode = Action_encode.Walkright();
            }
            else// if (data[3] != (int)Field.Block)
            {
              kMode = 7;
              kcode = Action_encode.Walkleft();
            }
            break;

          case 3://右下
            if(data[5] != (int)Field.Block) {
              kMode = 4;
              kcode = Action_encode.Walkright();
            }
            else if(data[8] != (int)Field.Block && data[7] != (int)Field.Block) {
              kMode = 3;
              kcode = Action_encode.Walkdown();
            }
            else if(data[3] != (int)Field.Block) {
              kMode = 7;
              kcode = Action_encode.Walkleft();
            }
            else if(data[7] != (int)Field.Block) {
              kMode = 8;
              kcode = Action_encode.Walkleft();
            }
            else //if (data[1] != (int)Field.Block)
            {
              kMode = 6;
              kcode = Action_encode.Walkup();
            }
            break;

          case 4:
            if(data[7] != (int)Field.Block) {
              kMode = 3;
              kcode = Action_encode.Walkdown();
            }
            else if(data[8] != (int)Field.Block && data[5] != (int)Field.Block) {
              kMode = 4;
              kcode = Action_encode.Walkright();
            }
            else if(data[1] != (int)Field.Block) {
              kMode = 2;
              kcode = Action_encode.Walkup();
            }
            else if(data[5] != (int)Field.Block) {
              kMode = 1;
              kcode = Action_encode.Walkright();
            }
            else //if (data[3] != (int)Field.Block)
            {
              kMode = 5;
              kcode = Action_encode.Walkleft();
            }
            break;

          case 5://左上
            if(data[3] != (int)Field.Block) {
              kMode = 6;
              kcode = Action_encode.Walkleft();
            }
            else if(data[1] != (int)Field.Block && data[0] != (int)Field.Block) {
              kMode = 5;
              kcode = Action_encode.Walkup();
            }
            else if(data[5] != (int)Field.Block) {
              kMode = 1;
              kcode = Action_encode.Walkright();
            }
            else if(data[1] != (int)Field.Block) {
              kMode = 2;
              kcode = Action_encode.Walkup();
            }
            else //if (data[7] != (int)Field.Block)
            {
              kMode = 4;
              kcode = Action_encode.Walkdown();
            }
            break;

          case 6:
            if(data[1] != (int)Field.Block) {
              kMode = 5;
              kcode = Action_encode.Walkup();
            }
            else if(data[3] != (int)Field.Block && data[0] != (int)Field.Block) {
              kMode = 6;
              kcode = Action_encode.Walkleft();
            }
            else if(data[7] != (int)Field.Block) {
              kMode = 8;
              kcode = Action_encode.Walkdown();
            }
            else if(data[3] != (int)Field.Block) {
              kMode = 7;
              kcode = Action_encode.Walkleft();
            }
            else// if (data[5] != (int)Field.Block)
            {
              kMode = 3;
              kcode = Action_encode.Walkright();
            }
            break;

          case 7://左下
            if(data[3] != (int)Field.Block) {
              kMode = 8;
              kcode = Action_encode.Walkleft();
            }
            else if(data[7] != (int)Field.Block && data[6] != (int)Field.Block) {
              kMode = 7;
              kcode = Action_encode.Walkdown();
            }
            else if(data[5] != (int)Field.Block) {
              kMode = 3;
              kcode = Action_encode.Walkright();
            }
            else if(data[7] != (int)Field.Block) {
              kMode = 4;
              kcode = Action_encode.Walkdown();
            }
            else// if (data[1] != (int)Field.Block)
            {
              kMode = 2;
              kcode = Action_encode.Walkup();
            }
            break;

          case 8:
            if(data[7] != (int)Field.Block) {
              kMode = 7;
              kcode = Action_encode.Walkdown();
            }
            else if(data[3] != (int)Field.Block && data[6] != (int)Field.Block) {
              kMode = 8;
              kcode = Action_encode.Walkleft();
            }
            else if(data[1] != (int)Field.Block) {
              kMode = 6;
              kcode = Action_encode.Walkup();
            }
            else if(data[3] != (int)Field.Block) {
              kMode = 5;
              kcode = Action_encode.Walkleft();
            }
            else// if (data[5] != (int)Field.Block)
            {
              kMode = 1;
              kcode = Action_encode.Walkright();
            }
            break;

          default:
            kcode = Action_encode.Walkup();
            break;
        }
      }

    }
  }   //namespace Walk
} //U16proconWalk
