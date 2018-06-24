namespace U16proconWalk {
  using U16proconActionEncode;

  class Walk {
    private int[] kData = new int[9];
    static private int kMode = 1;

    public void WalkSet(int[] data, int mode) {
      kData = data;
      kMode = mode;
    }
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
          if(kData[5] != 2) {
            kMode = 2;
            code = Action_encode.walkright();
          }
          else if(kData[2] != 2 && kData[1] != 2) {
            kMode = 1;
            code = Action_encode.walkup();
          }
          else if(kData[3] != 2) {
            kMode = 5;
            code = Action_encode.walkleft();
          }
          else if(kData[1] != 2) {
            kMode = 6;
            code = Action_encode.walkup();
          }
          else// if (kData[7] != 2)
          {
            kMode = 8;
            code = Action_encode.walkdown();
          }
          break;

        case 2:
          if(kData[1] != 2) {
            kMode = 1;
            code = Action_encode.walkup();
          }
          else if(kData[2] != 2 && kData[5] != 2) {
            kMode = 2;
            code = Action_encode.walkright();
          }
          else if(kData[7] != 2) {
            kMode = 4;
            code = Action_encode.walkdown();
          }
          else if(kData[5] != 2) {
            kMode = 2;
            code = Action_encode.walkright();
          }
          else// if (kData[3] != 2)
          {
            kMode = 7;
            code = Action_encode.walkleft();
          }
          break;

        case 3://右下
          if(kData[5] != 2) {
            kMode = 4;
            code = Action_encode.walkright();
          }
          else if(kData[8] != 2 && kData[7] != 2) {
            kMode = 3;
            code = Action_encode.walkdown();
          }
          else if(kData[3] != 2) {
            kMode = 7;
            code = Action_encode.walkleft();
          }
          else if(kData[7] != 2) {
            kMode = 8;
            code = Action_encode.walkleft();
          }
          else //if (kData[1] != 2)
          {
            kMode = 6;
            code = Action_encode.walkup();
          }
          break;

        case 4:
          if(kData[7] != 2) {
            kMode = 3;
            code = Action_encode.walkdown();
          }
          else if(kData[8] != 2 && kData[5] != 2) {
            kMode = 4;
            code = Action_encode.walkright();
          }
          else if(kData[1] != 2) {
            kMode = 2;
            code = Action_encode.walkup();
          }
          else if(kData[5] != 2) {
            kMode = 1;
            code = Action_encode.walkright();
          }
          else //if (kData[3] != 2)
          {
            kMode = 5;
            code = Action_encode.walkleft();
          }
          break;

        case 5://左上
          if(kData[3] != 2) {
            kMode = 6;
            code = Action_encode.walkleft();
          }
          else if(kData[1] != 2 && kData[0] != 2) {
            kMode = 5;
            code = Action_encode.walkup();
          }
          else if(kData[5] != 2) {
            kMode = 1;
            code = Action_encode.walkright();
          }
          else if(kData[1] != 2) {
            kMode = 2;
            code = Action_encode.walkup();
          }
          else //if (kData[7] != 2)
          {
            kMode = 4;
            code = Action_encode.walkdown();
          }
          break;

        case 6:
          if(kData[1] != 2) {
            kMode = 5;
            code = Action_encode.walkup();
          }
          else if(kData[3] != 2 && kData[0] != 2) {
            kMode = 6;
            code = Action_encode.walkleft();
          }
          else if(kData[7] != 2) {
            kMode = 8;
            code = Action_encode.walkdown();
          }
          else if(kData[3] != 2) {
            kMode = 7;
            code = Action_encode.walkleft();
          }
          else// if (kData[5] != 2)
          {
            kMode = 3;
            code = Action_encode.walkright();
          }
          break;

        case 7://左下
          if(kData[3] != 2) {
            kMode = 8;
            code = Action_encode.walkleft();
          }
          else if(kData[7] != 2 && kData[6] != 2) {
            kMode = 7;
            code = Action_encode.walkdown();
          }
          else if(kData[5] != 2) {
            kMode = 3;
            code = Action_encode.walkright();
          }
          else if(kData[7] != 2) {
            kMode = 4;
            code = Action_encode.walkdown();
          }
          else// if (kData[1] != 2)
          {
            kMode = 2;
            code = Action_encode.walkup();
          }
          break;

        case 8:
          if(kData[7] != 2) {
            kMode = 7;
            code = Action_encode.walkdown();
          }
          else if(kData[3] != 2 && kData[6] != 2) {
            kMode = 8;
            code = Action_encode.walkleft();
          }
          else if(kData[1] != 2) {
            kMode = 6;
            code = Action_encode.walkup();
          }
          else if(kData[3] != 2) {
            kMode = 5;
            code = Action_encode.walkleft();
          }
          else// if (kkData[5] != 2)
          {
            kMode = 1;
            code = Action_encode.walkright();
          }
          break;

        default:
          code = Action_encode.walkup();
          break;
      }
      return code;
    }

  }
} //U16proconWalk
