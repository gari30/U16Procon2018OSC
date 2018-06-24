//高橋祐希
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

namespace U16proconActionEncode
{
	static class Action_encode
	{
		static public short walkup()
		{
			return 100;
		}
		static public short walkright()
		{
			return 101;
		}
		static public short walkdown()
		{
			return 102;
		}
		static public short walkleft()
		{
			return 103;
		}
		static public short putup()
		{
			return 400;
		}
		static public short putright()
		{
			return 401;
		}
		static public short putdown()
		{
			return 402;
		}
		static public short putleft()
		{
			return 403;
		}
		static public short lookup()
		{
			return 700;
		}
		static public short lookright()
		{
			return 701;
		}
		static public short lookdown()
		{
			return 702;
		}
		static public short lookleft()
		{
			return 703;
		}
		static public short searchup()
		{
			return 800;
		}
		static public short searchright()
		{
			return 801;
		}
		static public short searchdown()
		{
			return 802;
		}
		static public short searchleft()
		{
			return 803;
		}
	}
}   //namespace U16proconActionEncode
