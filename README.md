# Card-game-Package
A C# ClassLibrary(dll) for card games. Helping you to create a card games quickly.There are some class like card, player, etc., and some basic operations of poker games, such as shuffles, draws and more.

一個以C#編寫的類別庫(dll)，專為撲克牌遊戲而設計。裡面提供了撲克牌、玩家等類別，與一些撲克牌遊戲的基本操作，如洗牌、抽牌等等。

#### 功能

## Class 卡片
- enum(Suits) **花色 suit**  
  { 無none, 黑桃spade, 紅心heart, 方塊diamond, 梅花club }
- string **點數 rank**  
  {"A","2",...,"K"}
- bool **Equals**(Card card)  
  檢查此張卡片與另一張卡片的花色、點數是否完全相同
- bool **IsLegal**()  
  檢查此張卡牌是否為標準(四花色 + A~K)卡牌
- bool **IsLegal**(List<Card> sample)  
  同上，但若符合sample內的卡牌也會回傳true
- int **ToInt**()  
  傳回此張卡排代表的點數

## Class 玩家
