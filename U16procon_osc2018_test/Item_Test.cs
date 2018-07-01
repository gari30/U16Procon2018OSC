using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace U16procon {
  namespace Test.Item {
    using U16procon.Item;

    [TestClass]
    public class Item_Test {

      [TestMethod]
      public void GetItemTest() {

        Item item = new Item();

        int ret = new int();

        // 周囲になにもない場合
        // -1を返却することを確認
        var get_ready_info1 = new[] { (int)Field_Test.Floor, (int)Field_Test.Floor, (int)Field_Test.Floor,
                                      (int)Field_Test.Floor, (int)Field_Test.Floor, (int)Field_Test.Floor,
                                      (int)Field_Test.Floor, (int)Field_Test.Floor, (int)Field_Test.Floor };
        ret = item.GetItem(get_ready_info1);
        Assert.AreEqual(ret, -1);

        // 周囲にItemがある場合
        // Itemの方向の移動コードを返却することを確認
        var get_ready_info2 = new[] { (int)Field_Test.Floor, (int)Field_Test.Floor, (int)Field_Test.Floor,
                                      (int)Field_Test.Floor, (int)Field_Test.Floor, (int)Field_Test.Item,
                                      (int)Field_Test.Floor, (int)Field_Test.Floor, (int)Field_Test.Floor };
        ret = item.GetItem(get_ready_info2);
        Assert.AreEqual(ret, Encode.Action_encode.Walkright());

        // 周囲にEnemy、Block(Item以外)がある場合
        // -1を返却することを確認
        var get_ready_info3 = new[] { (int)Field_Test.Floor, (int)Field_Test.Floor, (int)Field_Test.Floor,
                                      (int)Field_Test.Floor, (int)Field_Test.Floor, (int)Field_Test.Floor,
                                      (int)Field_Test.Floor, (int)Field_Test.Enemy, (int)Field_Test.Floor };
        ret = item.GetItem(get_ready_info3);
        Assert.AreEqual(ret, -1);

        // 周囲にEnemy、Block、Itemがある場合
        // Itemの方向の移動コードを返却することを確認
        var get_ready_info4 = new[] { (int)Field_Test.Floor, (int)Field_Test.Enemy, (int)Field_Test.Floor,
                                      (int)Field_Test.Block, (int)Field_Test.Floor, (int)Field_Test.Block,
                                      (int)Field_Test.Floor, (int)Field_Test.Item,  (int)Field_Test.Floor };
        ret = item.GetItem(get_ready_info4);
        Assert.AreEqual(ret, Encode.Action_encode.Walkdown());

        // 上下左右以外にItemがある場合
        // -1を返却することを確認
        var get_ready_info5 = new[] { (int)Field_Test.Item,  (int)Field_Test.Floor, (int)Field_Test.Item,
                                      (int)Field_Test.Floor, (int)Field_Test.Floor, (int)Field_Test.Floor,
                                      (int)Field_Test.Item,  (int)Field_Test.Floor, (int)Field_Test.Item  };
        ret = item.GetItem(get_ready_info5);
        Assert.AreEqual(ret, -1);
      }
    }
  } // namespace Test.Item
} // namespace U16procon
