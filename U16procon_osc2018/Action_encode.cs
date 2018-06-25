//h27.11.09 ver.1.0
//h27.11.10 ver.2.0  インスタンス生成をしなくても使用できるように変更
//h27.11.11 ver.2.1 update　未使用のusingを削除

/*************使い方*********
 * Action_encode.使いたい動作();
 * と使ってください
 * 
 * 返り値にその動作の行動コードを返します、引数は要りません
 */

//TODO:このclassをenumで書き換える

namespace U16procon {
  namespace Encode {

    enum Field {
      Floor = 0,
      Enemy,
      Block,
      Item,
    }

    static class Action_encode {
      static public short Walkup() {
        return 100;
      }
      static public short Walkright() {
        return 101;
      }
      static public short Walkdown() {
        return 102;
      }
      static public short Walkleft() {
        return 103;
      }
      static public short Putup() {
        return 400;
      }
      static public short Putright() {
        return 401;
      }
      static public short Putdown() {
        return 402;
      }
      static public short Putleft() {
        return 403;
      }
      static public short Lookup() {
        return 700;
      }
      static public short Lookright() {
        return 701;
      }
      static public short Lookdown() {
        return 702;
      }
      static public short Lookleft() {
        return 703;
      }
      static public short Searchup() {
        return 800;
      }
      static public short Searchright() {
        return 801;
      }
      static public short Searchdown() {
        return 802;
      }
      static public short Searchleft() {
        return 803;
      }
    }
  }   //namespace encode
}   //namespace U16procon
