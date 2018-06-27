namespace U16procon {
  namespace Walk {
    using Encode;

    class Walk {
      static private int kcode = 0;
      static private int kMode = 1;

      /*
        移動方向を指定する
        mode:移動したい方向を指定
              1:右上
              3:右下
              5:左上
              7:左下
       */
      public void WalkSet(int mode) {
        kMode = mode;
      }

      /*
        移動方向の決定
        data:GetReadyで取得した周囲情報
       */
      public void WalkSet(int[] data) {
         SlantingWalk(ref data);
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
