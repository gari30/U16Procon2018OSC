namespace U16procon_osc2018 {
  class Program {
    static void Main(string[] args) {
      U16proconCore.Core core = new U16proconCore.Core();

      while(true) {
        core.CoreMain();
      }
    }
  }
}   //namespace U16procon_osc2018

//TODO: No.1 ループ回避の実装
/*      既存のloop回避コードを組み込んで見る */

//TODO: No.2 マップ記憶の実装
/*      Dictionary型で実装してみる            */

//TODO: No.3 A*の実装
/*      ネット情報参考にしてじっそうしてみる  */

namespace U16proconCore {
  class Core {

    //インスタンス
    CHaser.Client client = CHaser.Client.Create();
    U16proconWalk.Walk walk = new U16proconWalk.Walk();

    //変数
    static short turn_count = 0;
    int[] value = new int[9];     //GetReady info
    int[] action_after = new int[9];    //action after info
    int answer = 0;   //temp action code

    public void CoreMain() {
      turn_count++;
      value = client.GetReady();

      walk.WalkSet(value);
      answer = walk.WalkGet();
      switch (answer)
			{
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
}  //namespace U16proconCore
