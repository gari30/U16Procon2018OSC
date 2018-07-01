using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace U16procon {
  namespace Test.Enemy {
    using U16procon.Enemy;

    [TestClass]
    public class Enemy_Test {

      [TestMethod]
      public void GetEnemyTest() {

        Enemy enemy = new Enemy();

        int ret = new int();

        // 周囲になにもない場合
        // -1を返却することを確認
        var get_ready_info1 = new[] { (int)Field_Test.Floor, (int)Field_Test.Floor, (int)Field_Test.Floor,
                                      (int)Field_Test.Floor, (int)Field_Test.Floor, (int)Field_Test.Floor,
                                      (int)Field_Test.Floor, (int)Field_Test.Floor, (int)Field_Test.Floor };
        ret = enemy.GetEnemy(get_ready_info1);
        Assert.AreEqual(ret, -1);

        // 周囲にEnemyがある場合
        // Enemyの方向の移動コードを返却することを確認
        var get_ready_info2 = new[] { (int)Field_Test.Floor, (int)Field_Test.Floor, (int)Field_Test.Floor,
                                      (int)Field_Test.Enemy, (int)Field_Test.Floor, (int)Field_Test.Floor,
                                      (int)Field_Test.Floor, (int)Field_Test.Floor, (int)Field_Test.Floor };
        ret = enemy.GetEnemy(get_ready_info2);
        Assert.AreEqual(ret, Encode.Action_encode.Putleft());

        // 周囲にItem、Block(Enemy以外)がある場合
        // -1を返却することを確認
        var get_ready_info3 = new[] { (int)Field_Test.Floor, (int)Field_Test.Block, (int)Field_Test.Floor,
                                      (int)Field_Test.Block, (int)Field_Test.Floor, (int)Field_Test.Item,
                                      (int)Field_Test.Floor, (int)Field_Test.Item,  (int)Field_Test.Floor };
        ret = enemy.GetEnemy(get_ready_info3);
        Assert.AreEqual(ret, -1);

        // 周囲にEnemy、Block、Itemがある場合
        // Itemの方向の移動コードを返却することを確認
        var get_ready_info4 = new[] { (int)Field_Test.Floor, (int)Field_Test.Enemy, (int)Field_Test.Floor,
                                      (int)Field_Test.Block, (int)Field_Test.Floor, (int)Field_Test.Item,
                                      (int)Field_Test.Floor, (int)Field_Test.Block, (int)Field_Test.Floor };
        ret = enemy.GetEnemy(get_ready_info4);
        Assert.AreEqual(ret, Encode.Action_encode.Putup());

        // 上下左右以外にEnemyがある場合
        // -1を返却することを確認
        var get_ready_info5 = new[] { (int)Field_Test.Enemy, (int)Field_Test.Floor, (int)Field_Test.Enemy,
                                      (int)Field_Test.Floor, (int)Field_Test.Floor, (int)Field_Test.Floor,
                                      (int)Field_Test.Enemy, (int)Field_Test.Floor, (int)Field_Test.Enemy };
        ret = enemy.GetEnemy(get_ready_info5);
        Assert.AreEqual(ret, -1);
      }
    }
  } // namespace Test.Enemy
} // namespace U16procon
