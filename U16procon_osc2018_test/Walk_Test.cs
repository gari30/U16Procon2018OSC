using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace U16procon {
  namespace Test.Walk {
    using U16procon.Walk;

    [TestClass]
    public class Walk_Test {

      // Blockの方向へ移動しないことを確認
      [TestMethod]
      public void WalkGetTest1() {

        Walk walk = new Walk();

        int ret = new int();

        // 右側にBlockがある場合
        // 右側に移動する行動コードが返却されないこと
        var get_ready_info1 = new[] { (int)Field_Test.Floor, (int)Field_Test.Floor, (int)Field_Test.Floor,
                                      (int)Field_Test.Floor, (int)Field_Test.Floor, (int)Field_Test.Block,
                                      (int)Field_Test.Floor, (int)Field_Test.Floor, (int)Field_Test.Floor };
        walk.WalkSet(get_ready_info1);
        ret = walk.WalkGet();
        Assert.AreNotEqual(ret, Encode.Action_encode.Walkright());

        // 右側にBlockがあり、右側に移動しようとした場合
        // 右側に移動する行動コードが返却されないこと
        var get_ready_info2 = new[] { (int)Field_Test.Floor, (int)Field_Test.Floor, (int)Field_Test.Floor,
                                      (int)Field_Test.Floor, (int)Field_Test.Floor, (int)Field_Test.Block,
                                      (int)Field_Test.Floor, (int)Field_Test.Floor, (int)Field_Test.Floor };
        walk.WalkSet(get_ready_info2, 1); // 移動方向指定(1:右)
        ret = walk.WalkGet();
        Assert.AreNotEqual(ret, Encode.Action_encode.Walkright());

        // 左側にBlockがある場合
        // 左側に移動する行動コードが返却されないこと
        var get_ready_info3 = new[] { (int)Field_Test.Floor, (int)Field_Test.Floor, (int)Field_Test.Floor,
                                      (int)Field_Test.Block, (int)Field_Test.Floor, (int)Field_Test.Floor,
                                      (int)Field_Test.Floor, (int)Field_Test.Floor, (int)Field_Test.Floor };
        walk.WalkSet(get_ready_info3);
        ret = walk.WalkGet();
        Assert.AreNotEqual(ret, Encode.Action_encode.Walkleft());

        // 左側にBlockがあり、左側に移動しようとした場合
        // 左側に移動する行動コードが返却されないこと
        var get_ready_info4 = new[] { (int)Field_Test.Floor, (int)Field_Test.Floor, (int)Field_Test.Floor,
                                      (int)Field_Test.Block, (int)Field_Test.Floor, (int)Field_Test.Floor,
                                      (int)Field_Test.Floor, (int)Field_Test.Floor, (int)Field_Test.Floor };
        walk.WalkSet(get_ready_info4, 5); // 移動方向指定(5：左)
        ret = walk.WalkGet();
        Assert.AreNotEqual(ret, Encode.Action_encode.Walkleft());

        // 上側にBlockがある場合
        // 上側に移動する行動コードが返却されないこと
        var get_ready_info5 = new[] { (int)Field_Test.Floor, (int)Field_Test.Block, (int)Field_Test.Floor,
                                      (int)Field_Test.Floor, (int)Field_Test.Floor, (int)Field_Test.Floor,
                                      (int)Field_Test.Floor, (int)Field_Test.Floor, (int)Field_Test.Floor };
        walk.WalkSet(get_ready_info5);
        ret = walk.WalkGet();
        Assert.AreNotEqual(ret, Encode.Action_encode.Walkup());

        // 上側にBlockがあり、上側に移動しようとした場合
        // 上側に移動する行動コードが返却されないこと
        var get_ready_info6 = new[] { (int)Field_Test.Floor, (int)Field_Test.Block, (int)Field_Test.Floor,
                                      (int)Field_Test.Floor, (int)Field_Test.Floor, (int)Field_Test.Floor,
                                      (int)Field_Test.Floor, (int)Field_Test.Floor, (int)Field_Test.Floor };
        walk.WalkSet(get_ready_info6, 2); // 移動方向指定(2:上)
        ret = walk.WalkGet();
        Assert.AreNotEqual(ret, Encode.Action_encode.Walkup());

        // 下側にBlockがある場合
        // 下側に移動する行動コードが返却されないこと
        var get_ready_info7 = new[] { (int)Field_Test.Floor, (int)Field_Test.Floor, (int)Field_Test.Floor,
                                      (int)Field_Test.Floor, (int)Field_Test.Floor, (int)Field_Test.Floor,
                                      (int)Field_Test.Floor, (int)Field_Test.Block, (int)Field_Test.Floor };
        walk.WalkSet(get_ready_info7);
        ret = walk.WalkGet();
        Assert.AreNotEqual(ret, Encode.Action_encode.Walkdown());

        // 下側にBlockがあり、下側に移動しようとした場合
        // 下側に移動する行動コードが返却されないこと
        var get_ready_info8 = new[] { (int)Field_Test.Floor, (int)Field_Test.Floor, (int)Field_Test.Floor,
                                      (int)Field_Test.Floor, (int)Field_Test.Floor, (int)Field_Test.Floor,
                                      (int)Field_Test.Floor, (int)Field_Test.Block, (int)Field_Test.Floor };
        walk.WalkSet(get_ready_info8, 4); // 移動方向指定(4:下)
        ret = walk.WalkGet();
        Assert.AreNotEqual(ret, Encode.Action_encode.Walkup());
      }
    }
  } // namespace Test.Walk
} // namespace U16procon
