#### Card-game-Package
A C# ClassLibrary(dll) for card games. Helping you to create a card games quickly.  
There are some class like card, player, etc.,   
and some basic operations of poker games, such as shuffles, draws and more.

一個C#類別庫(dll)，專為撲克牌遊戲而設計。裡面提供了撲克牌、玩家等類別，與一些撲克牌遊戲的基本操作，如洗牌、抽牌等等。  
basic.cs 為原始碼  
CardClass.dll 為程式

---

# 功能

### Class Card 卡片
- **花色 suit**  
  { 無none, 黑桃spade, 紅心heart, 方塊diamond, 梅花club }
- **點數 rank**  
  {"A","2",...,"K"}
- **Equals**(Card card)  
  檢查此張卡片與另一張卡片的花色、點數是否完全相同
- **IsLegal**()  
  檢查此張卡牌是否為標準(四花色 + A~K)卡牌
- **IsLegal**(List<Card> sample)  
  同上，但若符合sample內的卡牌也會回傳true
- **ToInt**()  
  傳回此張卡排代表的點數

### Class Player 玩家
- **名字 name**
- **手牌 hand**
- **略過 pass**

### static Class Dealer 荷官功能
- **GetDeckOfCard**()  
  回傳一副沒有鬼牌的撲克牌，共52張
- **Shuffle**(List<Card> hand)  
  將傳入的牌組洗牌
- **DrawCard**(List<Card> from, List<Card> to, int num)  
  從from中抽出前num張卡片放入to中
- **LookCard**(List<Card> from, int num)  
  查看from中前num張卡
- **FindCardIndex**(List<Card> from, Card card)  
  傳回from中與card*完全相同*的卡的index值
- **FindCardIndex**(List<Card> hand, string rank)  
  傳回from中與card*點數相同*的卡的index值
