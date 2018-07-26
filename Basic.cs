using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardClass
{

	/// <summary> 撲克牌類別 </summary>
	public struct Card
	{
		/// <summary>
		/// 撲克牌的四種花色(spade黑桃, heart紅心, diamond方塊, club梅花),
		///  none 可以用作鬼牌或特殊用途
		/// </summary>
		public enum Suits { none, spade, heart, diamond, club }

		/// <summary> 代表牌的花色 </summary>
		public Suits suit;

		/// <summary>
		/// 代表牌的點數
		/// </summary>
		public string rank;

		public Card(Suits suit, string rank)
		{
			this.suit = suit;
			this.rank = rank;
		}

		/// <summary>
		/// 比較兩張卡的花色、點數是否相同
		/// </summary>
		/// <param name="card">欲比較的卡牌</param>
		/// <returns>花色與點數都相同則回傳true, 否則回傳false</returns>
		public bool Equals(Card card)
		{
			if (card.suit == this.suit && card.rank == this.rank) return true;
			else return false;
		}

		/// <summary>
		/// 檢查該張卡是否為普通制式的卡片
		/// </summary>
		/// <returns></returns>
		public bool IsLegal()
		{
			if (this.suit == Suits.none) return false;
			else
			{
				foreach (string s in new string[] { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" })
				{
					if (rank == s) return true;
				}
				return false;
			}
		}

		/// <summary>
		/// 檢查該張卡是否為普通制式的卡片或指定的卡片集
		/// </summary>
		/// <param name="sample">允許通過的卡片集</param>
		/// <returns></returns>
		public bool IsLegal(List<Card> sample)
		{
			foreach (Card sc in sample)
			{
				if (sc.Equals(this)) return true;
			}

			if (this.suit == Suits.none) return false;
			else
			{
				foreach (string s in new string[] { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" })
				{
					if (rank == s) return true;
				}
				return false;
			}
		}

		/// <summary>
		/// 傳回牌點的數字
		/// </summary>
		/// <returns></returns>
		public int ToInt()
		{
			if (rank == "A") return 1;
			else if (rank == "J") return 11;
			else if (rank == "Q") return 12;
			else if (rank == "K") return 13;
			else return int.Parse(rank);
		}
	}

	public class Player
	{
		public string name;
		public List<Card> hand;
		public bool pass;

		public Player(string name, List<Card> hand, bool pass)
		{
			this.name = name;
			this.hand = hand;
			this.pass = pass;
		}

		public Player(string name, List<Card> hand)
		{
			this.name = name;
			this.hand = hand;
			pass = false;
		}

		public Player(string name, bool pass)
		{
			this.name = name;
			hand = new List<Card>();
			this.pass = pass;
		}

		public Player(string name)
		{
			this.name = name;
			hand = new List<Card>();
			pass = false;
		}
	}

	/// <summary>
	/// 提供對撲克牌的基本操作
	/// </summary>
	public static class Dealer
	{
		/// <summary>
		/// 輸出一組沒有鬼牌的撲克牌組
		/// </summary>
		public static List<Card> GetDeckOfCard()
		{
			string[] ranks = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
			List<Card> output = new List<Card>();
			foreach (string r in ranks)
			{
				output.Add(new Card(Card.Suits.spade, r));
				output.Add(new Card(Card.Suits.heart, r));
				output.Add(new Card(Card.Suits.diamond, r));
				output.Add(new Card(Card.Suits.club, r));
			}
			return output;
		}

		/// <summary>
		/// 將傳入的牌組洗牌
		/// </summary>
		/// <param name="hand"></param>
		public static void Shuffle(List<Card> hand)
		{
			Random random = new Random();

			for (int n = hand.Count - 1; n > 0; --n)
			{
				int k = random.Next(n + 1);
				Card temp = hand[n];
				hand[n] = hand[k];
				hand[k] = temp;
			}
		}

		/// <summary>
		/// 從 參數1 中抽出前 num 張卡牌放到 參數2 中(參數1中的卡牌會消失)
		/// </summary>
		/// <param name="from"></param>
		/// <param name="to"></param>
		/// <param name="num"></param>
		public static void DrawCard(List<Card> from, List<Card> to, int num)
		{
			for (int i = 0; i < num; i++)
			{
				to.Add(from[i]);
			}
			for (int i = 0; i < num; i++)
			{
				from.RemoveAt(0);
			}
		}

		/// <summary>
		/// 從 參數1 中選取前 num 張卡牌(參數1中的卡牌不會消失)
		/// </summary>
		/// <param name="from"></param>
		/// <param name="num"></param>
		/// <returns></returns>
		public static List<Card> LookCard(List<Card> from, int num)
		{
			List<Card> outcome = new List<Card>();
			for (int i = 0; i < num; i++)
			{
				outcome.Add(from[i]);
			}
			return outcome;
		}

		/// <summary>
		/// 從 參數1 中找到指定卡牌的index值，若沒有則傳回-1
		/// </summary>
		/// <param name="from"></param>
		/// <param name="rank"></param>
		/// <param name="suits"></param>
		/// <returns></returns>
		public static int FindCardIndex(List<Card> from, Card card)
		{
			foreach (Card c in from)
			{
				if (c.Equals(card))
				{
					return from.IndexOf(c);
				}
			}
			return -1;
		}

		/// <summary>
		/// 從 參數1 中找到指定卡牌的index值，若沒有找到則傳回-1
		/// </summary>
		/// <param name="hand"></param>
		/// <param name="rank"></param>
		/// <returns></returns>
		public static int FindCardIndex(List<Card> hand, string rank)
		{
			foreach (Card c in hand)
			{
				if (c.rank == rank)
				{
					return hand.IndexOf(c);
				}
			}
			return -1;
		}
	}
}
