using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Domain.Models;
using Newtonsoft.Json;

namespace BotClient
{
	public class BotClient
	{
		static async Task Main(string[] args)
		{
			HttpClient client = new HttpClient();
			//var result = await client.GetAsync("https://localhost:7217/api/Good");
			//string data = await result.Content.ReadAsStringAsync();
			//Good[] goods = JsonConvert.DeserializeObject<Good[]>(data);
			var botClient = new TelegramBotClient("6016486340:AAH6mGf5Bh_G_rIUwcEHLS1CTdB1IXtqT7E");
			using CancellationTokenSource cts = new CancellationTokenSource();

			//foreach(Good good in goods)
			//{
			//	Console.WriteLine(GoodToString(good));
			//}

			Console.WriteLine("\n\n\n");

			ReceiverOptions receiverOptions = new ReceiverOptions()
			{
				AllowedUpdates = Array.Empty<UpdateType>()
			};

			botClient.StartReceiving(updateHandler: HandleUpdateAsync, pollingErrorHandler: HandlePollingErrorAsync, receiverOptions: receiverOptions, cancellationToken: cts.Token);

			var me = await botClient.GetMeAsync();

			Console.WriteLine($"Start listening for @{me.Username}");
			Console.ReadKey();

			cts.Cancel();
		}

		static string GoodToString(Good good)
		{
			return $"\nИмя: {good.Name}\nОписание: {good.Description}\nКоличество: {good.Amount}\nЦена: {good.Price}";
		}

		static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
		{
			if (update.Message is not { } message) return;

			if (message.Text is not { } messageText) return;

			long chatId = message.Chat.Id;

			Console.WriteLine($"Received a '{messageText}' message in chat {chatId}.");

			Message sentMessage = await botClient.SendTextMessageAsync(chatId: chatId, text: "You said:\n" + messageText, cancellationToken: cancellationToken);

			if (message.Text == "Проверка")
			{
				await botClient.SendTextMessageAsync(chatId: chatId, text: "Проверка: ОК", cancellationToken: cancellationToken);
			}

			if (message.Text == "Привет!") await botClient.SendTextMessageAsync(chatId: chatId, text: "Здарова!", cancellationToken: cancellationToken);

			if (message.Text == "Картинка") await botClient.SendPhotoAsync(chatId: chatId,
															photo: "https://raw.githubusercontent.com/FilinEgorq/InternetShopBot/main/BotClient/pedro.jpg",
															parseMode: ParseMode.Html,
															caption: "<b>Мем)</b>",
															cancellationToken: cancellationToken);

			if (message.Text == "Стикер") await botClient.SendStickerAsync(chatId: chatId,
															sticker: "https://github.com/TelegramBots/book/raw/master/src/docs/sticker-fred.webp",
															cancellationToken: cancellationToken);

			if (message.Text == "Видео") await botClient.SendVideoAsync(chatId: chatId, video: "");
		}

		static Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
		{
			var errorMessage = exception switch
			{
				ApiRequestException apiRequestException => $"Telegram API Error:[\n{apiRequestException.ErrorCode}]\n{apiRequestException.Message}", _ => exception.ToString()
			};

			Console.WriteLine(errorMessage);

			return Task.CompletedTask;
		}
	}
}