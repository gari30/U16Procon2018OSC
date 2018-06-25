namespace U16procon {
  namespace Walk {
    using Encode;

    class Walk {
      private int[] kData = new int[9];
      static private int kMode = 1;

      /*
        移動前情報を設定
        data:GetReadyで取得した周囲情報
        mode:移動したい方向を指定
              1:右上
              3:右下
              5:左上
              7:左下
       */
      public void WalkSet(int[] data, int mode) {
        kData = data;
        kMode = mode;
      }

      /*
        移動前情報を設定
        data:GetReadyで取得した周囲情報
       */
      public void WalkSet(int[] data) {
        kData = data;
      }

      public int WalkGet() {
        return SlantingWalk();
      }

      private int SlantingWalk() {
        int code = 0;

        switch(kMode) {
          case 1://右上
            if(kData[5] != (int)Field.Block) {
              kMode = 2;
              code = Action_encode.Walkright();
            }
            else if(kData[2] != (int)Field.Block && kData[1] != (int)Field.Block) {
              kMode = 1;
              code = Action_encode.Walkup();
            }
            else if(kData[3] != (int)Field.Block) {
              kMode = 5;
              code = Action_encode.Walkleft();
            }
            else if(kData[1] != (int)Field.Block) {
              kMode = 6;
              code = Action_encode.Walkup();
            }
            else// if (kData[7] != (int)Field.Block)
            {
              kMode = 8;
              code = Action_encode.Walkdown();
            }
            break;

          case 2:
            if(kData[1] != (int)Field.Block) {
              kMode = 1;
              code = Action_encode.Walkup();
            }
            else if(kData[2] != (int)Field.Block && kData[5] != (int)Field.Block) {
              kMode = 2;
              code = Action_encode.Walkright();
            }
            else if(kData[7] != (int)Field.Block) {
              kMode = 4;
              code = Action_encode.Walkdown();
            }
            else if(kData[5] != (int)Field.Block) {
              kMode = 2;
              code = Action_encode.Walkright();
            }
            else// if (kData[3] != (int)Field.Block)
            {
              kMode = 7;
              code = Action_encode.Walkleft();
            }
            break;

          case 3://右下
            if(kData[5] != (int)Field.Block) {
              kMode = 4;
              code = Action_encode.Walkright();
            }
            else if(kData[8] != (int)Field.Block && kData[7] != (int)Field.Block) {
              kMode = 3;
              code = Action_encode.Walkdown();
            }
            else if(kData[3] != (int)Field.Block) {
              kMode = 7;
              code = Action_encode.Walkleft();
            }
            else if(kData[7] != (int)Field.Block) {
              kMode = 8;
              code = Action_encode.Walkleft();
            }
            else //if (kData[1] != (int)Field.Block)
            {
              kMode = 6;
              code = Action_encode.Walkup();
            }
            break;

          case 4:
            if(kData[7] != (int)Field.Block) {
              kMode = 3;
              code = Action_encode.Walkdown();
            }
            else if(kData[8] != (int)Field.Block && kData[5] != (int)Field.Block) {
              kMode = 4;
              code = Action_encode.Walkright();
            }
            else if(kData[1] != (int)Field.Block) {
              kMode = 2;
              code = Action_encode.Walkup();
            }
            else if(kData[5] != (int)Field.Block) {
              kMode = 1;
              code = Action_encode.Walkright();
            }
            else //if (kData[3] != (int)Field.Block)
            {
              kMode = 5;
              code = Action_encode.Walkleft();
            }
            break;

          case 5://左上
            if(kData[3] != (int)Field.Block) {
              kMode = 6;
              code = Action_encode.Walkleft();
            }
            else if(kData[1] != (int)Field.Block && kData[0] != (int)Field.Block) {
              kMode = 5;
              code = Action_encode.Walkup();
            }
            else if(kData[5] != (int)Field.Block) {
              kMode = 1;
              code = Action_encode.Walkright();
            }
            else if(kData[1] != (int)Field.Block) {
              kMode = 2;
              code = Action_encode.Walkup();
            }
            else //if (kData[7] != (int)Field.Block)
            {
              kMode = 4;
              code = Action_encode.Walkdown();
            }
            break;

          case 6:
            if(kData[1] != (int)Field.Block) {
              kMode = 5;
              code = Action_encode.Walkup();
            }
            else if(kData[3] != (int)Field.Block && kData[0] != (int)Field.Block) {
              kMode = 6;
              code = Action_encode.Walkleft();
            }
            else if(kData[7] != (int)Field.Block) {
              kMode = 8;
              code = Action_encode.Walkdown();
            }
            else if(kData[3] != (int)Field.Block) {
              kMode = 7;
              code = Action_encode.Walkleft();
            }
            else// if (kData[5] != (int)Field.Block)
            {
              kMode = 3;
              code = Action_encode.Walkright();
            }
            break;

          case 7://左下
            if(kData[3] != (int)Field.Block) {
              kMode = 8;
              code = Action_encode.Walkleft();
            }
            else if(kData[7] != (int)Field.Block && kData[6] != (int)Field.Block) {
              kMode = 7;
              code = Action_encode.Walkdown();
            }
            else if(kData[5] != (int)Field.Block) {
              kMode = 3;
              code = Action_encode.Walkright();
            }
            else if(kData[7] != (int)Field.Block) {
              kMode = 4;
              code = Action_encode.Walkdown();
            }
            else// if (kData[1] != (int)Field.Block)
            {
              kMode = 2;
              code = Action_encode.Walkup();
            }
            break;

          case 8:
            if(kData[7] != (int)Field.Block) {
              kMode = 7;
              code = Action_encode.Walkdown();
            }
            else if(kData[3] != (int)Field.Block && kData[6] != (int)Field.Block) {
              kMode = 8;
              code = Action_encode.Walkleft();
            }
            else if(kData[1] != (int)Field.Block) {
              kMode = 6;
              code = Action_encode.Walkup();
            }
            else if(kData[3] != (int)Field.Block) {
              kMode = 5;
              code = Action_encode.Walkleft();
            }
            else// if (kkData[5] != (int)Field.Block)
            {
              kMode = 1;
              code = Action_encode.Walkright();
            }
            break;

          default:
            code = Action_encode.Walkup();
            break;
        }
        return code;
      }

    }
  }   //namespace Walk
} //U16proconWalk
