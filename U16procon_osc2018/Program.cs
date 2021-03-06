namespace U16procon {
  class Program {
    static void Main(string[] args) {
      Core.Core core = new Core.Core();

      while(true) {
        core.CoreMain();
      }
    }
  }
}   //namespace U16procon

//TODO: No.2 マップ記憶の実装
/*      Dictionary型で実装してみる            */

//TODO: No.3 A*の実装
/*      ネット情報参考にしてじっそうしてみる  */

namespace U16procon {
  namespace Core {
    class Core {

      //インスタンス
      CHaser.Client client = CHaser.Client.Create();
      Walk.Walk walk = new Walk.Walk();
      Item.Item item = new Item.Item();
      Enemy.Enemy enemy = new Enemy.Enemy();
      Loop.Loop loop = new Loop.Loop();

      //変数
      static short turn_count = 0;
      int[] value = new int[9];     //GetReady info
      int[] action_after = new int[9];    //action after info
      int answer = 0;   //temp action code
      byte loop_count = 0;  //loop avoidance action count

      public void CoreMain() {
        turn_count++;
        value = client.GetReady();

        foreach (int i in value) {
          System.Console.Write(i + ",");
        }
        System.Console.WriteLine();

        if (loop_count == 0) {
          walk.WalkSet(value);

          if(loop.CodeSet(answer) == true) {
            loop_count = 8; //8ターンループ回避行動を設定
          }
        }
        else {
          loop_count--;
          bool walk_ret = walk.LoopWalk(value);
          if(walk_ret == false) {
            loop_count = 0;
            loop.LoopReset();
          }
        }
        answer = walk.WalkGet();

        int item_ret = item.GetItem(value);
        if (item_ret != -1) {
          loop_count = 0;
          loop.LoopReset();
          answer = item_ret;
        }

        int enemy_ret = enemy.GetEnemy(value);
        if (enemy_ret != -1) {
          answer = enemy_ret;
        }

        System.Console.WriteLine("code=" + answer);

        switch(answer) {
          case 100:
            //上に移動
            action_after = client.WalkUp();
            break;
          case 101:
            //右に移動
            action_after = client.WalkRight();
            break;
          case 102:
            //下に移動
            action_after = client.WalkDown();
            break;
          case 103:
            //左に移動
            action_after = client.WalkLeft();
            break;
          case 400:
            //上にput
            action_after = client.PutUp();
            break;
          case 401:
            //右にput
            action_after = client.PutRight();
            break;
          case 402:
            //下にput
            action_after = client.PutDown();
            break;
          case 403:
            //左にput
            action_after = client.PutLeft();
            break;
          case 700:
            //Look、上
            action_after = client.LookUp();
            break;
          case 701:
            //Look、右
            action_after = client.LookRight();
            break;
          case 702:
            //Look、下
            action_after = client.LookDown();
            break;
          case 703:
            //Look、左
            action_after = client.LookLeft();
            break;
          case 800:
            //search、上
            action_after = client.SearchUp();
            break;
          case 801:
            //search、右
            action_after = client.SearchRight();
            break;
          case 802:
            //search、下
            action_after = client.SearchDown();
            break;
          case 803:
            //search、左
            action_after = client.SearchLeft();
            break;
          default:
            //エラー吐き出し
            System.Console.WriteLine("行動コードが不適切です。");
            break;
        }
        //System.Console.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8}", action_after[0], action_after[1], action_after[2], action_after[3], action_after[4], action_after[5], action_after[6], action_after[7], action_after[8]);
      }
    }
  }   //namespace Core
}  //namespace U16procon
