using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace CoinChangeApp
{
    public partial class MainWindow : Window
    {
        private List<int> coins = new List<int>()
        {
            5, 10, 20, 50, 100, 200, 500, 1000, 2000
        };

        public MainWindow()
        {
            InitializeComponent();
        }

        private List<decimal> GetMinCoins(List<int> coins, decimal amount)
        {
            // Order Desc
            var sortedCoins = coins.OrderByDescending(c => c).ToList();
            List<decimal> resultCoins = new List<decimal>();

            foreach (var coin in sortedCoins)
            {
                while (coin <= amount)
                {
                    amount -= coin;
                    resultCoins.Add(coin);
                    if (amount == 0)
                        break;
                }
            }
            return resultCoins;
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                decimal paidAmount = decimal.Parse(PaidAmountTextBox.Text);
                decimal totalPurchase = decimal.Parse(TotalPurchaseTextBox.Text);

                if (paidAmount < totalPurchase)
                {
                    MessageBox.Show("Paid amount must be greater than or equal to total purchase!",
                                  "Invalid Input",
                                  MessageBoxButton.OK,
                                  MessageBoxImage.Warning);
                    return;
                }

                decimal changeAmount = paidAmount - totalPurchase;

                if (changeAmount == 0)
                {
                    MessageBox.Show("No change needed. Exact amount paid!",
                                  "Perfect Payment",
                                  MessageBoxButton.OK,
                                  MessageBoxImage.Information);
                    return;
                }

                List<decimal> result = GetMinCoins(coins, changeAmount);

                // Group coins by denomination
                var coinCounts = result.GroupBy(x => x)
                                      .ToDictionary(x => x.Key, x => x.Count());

            
                // Display coins
                DisplayCoins(coinCounts);
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid numbers!",
                              "Invalid Input",
                              MessageBoxButton.OK,
                              MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}",
                              "Error",
                              MessageBoxButton.OK,
                              MessageBoxImage.Error);
            }
        }

        private void DisplayCoins(Dictionary<decimal, int> coinCounts)
        {
            CoinsPanel.Children.Clear();

            // Sort by coin value descending
            var sortedCoins = coinCounts.OrderByDescending(x => x.Key);

            foreach (var coinData in sortedCoins)
            {
                int coinValue = (int)coinData.Key;
                int count = coinData.Value;

                // Create coin card
                Border coinCard = new Border();
                coinCard.Style = (Style)FindResource("CoinCard");

                // Stack panel for coin content
                StackPanel coinContent = new StackPanel
                {
                    Margin = new Thickness(15),
                    HorizontalAlignment = HorizontalAlignment.Center
                };

                // Try to load coin image from resources
                try
                {
                    string resourceKey = $"Coin{coinValue}";
                    BitmapImage coinImage = (BitmapImage)FindResource(resourceKey);

                    Image imgControl = new Image
                    {
                        Source = coinImage,
                        Style = (Style)FindResource("CoinImage")
                    };

                    coinContent.Children.Add(imgControl);
                }
                catch
                {
                    // Fallback: Show colored circle if image not found
                    Border coinCircle = new Border
                    {
                        Width = 120,
                        Height = 120,
                        CornerRadius = new CornerRadius(60),
                        Margin = new Thickness(0, 15, 0, 10)
                    };

                    try
                    {
                        string colorKey = $"Color{coinValue}";
                        coinCircle.Background = (SolidColorBrush)FindResource(colorKey);
                    }
                    catch
                    {
                        coinCircle.Background = new SolidColorBrush(Colors.Gray);
                    }

                    // Add coin value text inside circle
                    TextBlock circleText = new TextBlock
                    {
                        Text = $"{coinValue}\nDZD",
                        FontSize = 24,
                        FontWeight = FontWeights.Bold,
                        Foreground = Brushes.White,
                        TextAlignment = TextAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center,
                        HorizontalAlignment = HorizontalAlignment.Center
                    };

                    Grid circleGrid = new Grid();
                    circleGrid.Children.Add(coinCircle);
                    circleGrid.Children.Add(circleText);

                    coinContent.Children.Add(circleGrid);
                }

                // Denomination badge
                Border denominationBadge = new Border
                {
                    Background = new SolidColorBrush(Color.FromRgb(99, 102, 241)),
                    CornerRadius = new CornerRadius(8),
                   
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Margin = new Thickness(0, 0, 0, 8)
                };

                TextBlock denominationText = new TextBlock
                {
                    Text = $"{coinValue} DZD",
                    FontSize = 16,
                    FontWeight = FontWeights.Bold,
                    Foreground = Brushes.White
                };

                denominationBadge.Child = denominationText;
                coinContent.Children.Add(denominationBadge);

                // Count badge
                Border countBadge = new Border
                {
                    Background = new SolidColorBrush(Color.FromRgb(34, 197, 94)),
                    CornerRadius = new CornerRadius(8),
                   
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Margin = new Thickness(0, 0, 0, 8)
                };

                TextBlock countText = new TextBlock
                {
                    Text = $"× {count}",
                    FontSize = 20,
                    FontWeight = FontWeights.Bold,
                    Foreground = Brushes.White
                };

                countBadge.Child = countText;
                coinContent.Children.Add(countBadge);

                // Total value
                TextBlock totalText = new TextBlock
                {
                    Text = $"Total: {(coinValue * count):N2} DZD",
                    FontSize = 12,
                    Foreground = new SolidColorBrush(Color.FromRgb(100, 116, 139)),
                    FontWeight = FontWeights.SemiBold,
                    HorizontalAlignment = HorizontalAlignment.Center
                };
                coinContent.Children.Add(totalText);

                coinCard.Child = coinContent;
                CoinsPanel.Children.Add(coinCard);
            }
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            TotalPurchaseTextBox.Text = "0";
            PaidAmountTextBox.Text = "0";
            CoinsPanel.Children.Clear();
        }
    }
}