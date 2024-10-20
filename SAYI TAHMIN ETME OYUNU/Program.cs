using System;

namespace NumberGuessingGame
{
    // Oyuncu sınıfı
    class Player
    {
        public string Name { get; set; }
        public int Guess { get; set; }

        public Player(string name)
        {
            Name = name;
        }

        // Oyuncunun tahminini al
        public void MakeGuess()
        {
            Console.Write($"{Name}, bir sayı tahmin et (1-100): ");
            Guess = int.Parse(Console.ReadLine());
        }
    }

    // Oyun sınıfı
    class Game
    {
        private int targetNumber;
        private int attempts;
        private Player player;

        public Game(Player player)
        {
            this.player = player;
            Random rand = new Random();//random da rastgele olmasi icin//
            targetNumber = rand.Next(1, 101);  // 1-100 arası rastgele sayı
            attempts = 7;  // 8 deneme hakkı
        }

        public void Start()
        {
            Console.WriteLine("===Sayı Tahmin Oyunu ===");
            Console.WriteLine($"{player.Name}, bilgisayar 1 ile 100 arasında bir sayı tuttu. Tahmin etmeye çalış!");

            // Oyuncuya tahmin hakkı ver
            for (int i = 0; i < attempts; i++)
            {
                player.MakeGuess();
                if (player.Guess == targetNumber)
                {
                    Console.WriteLine("Tebrikler! Sayıyı doğru tahmin ettiniz.");
                    return;
                }
                else if (player.Guess < targetNumber)
                {
                    Console.WriteLine("Daha büyük bir sayı deneyin.");
                }
                else
                {
                    Console.WriteLine("Daha küçük bir sayı deneyin.");
                }
                Console.WriteLine($"Kalan deneme hakkınız: {attempts - (i + 1)}");
                //neden i+1 i degeri 0 dan basliyor 
            }

            // Oyuncu tahmin edemezse en son secenek
            Console.WriteLine($"Maalesef, doğru sayı {targetNumber} idi. Tekrar deneyin!");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Oyuncu adı alma
            Console.Write("Oyuncu adınızı girin: ");
            string playerName = Console.ReadLine();

            // Oyuncu ve oyun objelerini oluştur
            Player player = new Player(playerName);
            Game game = new Game(player);

            // Oyunu başlat
            game.Start();
        }
    }
}
