using System;
using Telegram.Bot;
namespace bot
{
    class Program
    {
        static ITelegramBotClient _botclient;
        static void Main(string[] args)
        {
            _botclient = new TelegramBotClient("1313194206:AAFDswP8uMxgiCCEGVeFKBxc708BQieZtGE");
            var me = _botclient.GetMeAsync().Result;

            

            Console.WriteLine($"Wepa, soy {me.FirstName}, mi cedula de botsito es: {me.Id}");

            _botclient.OnMessage += _botclient_OnMessage;
            _botclient.StartReceiving();

            Console.WriteLine("Please enter any key to exit");
            Console.ReadKey();

            _botclient.StopReceiving();
        }

        private async static void _botclient_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            
            if (e.Message.Text.ToLower().Contains("message"))
            {
                Console.WriteLine("opcion message");
                await _botclient.SendTextMessageAsync
                (
                    chatId: e.Message.Chat.Id,
                    text: $"jevi, le llegamos a tu cotorra: {e.Message.Text}"
                );
            }
            else if (e.Message.Text.ToLower().Contains("sticker"))
            {
                Console.WriteLine("opcion sticker");
                await _botclient.SendStickerAsync(
                    chatId: e.Message.Chat.Id,
                    sticker: "https://github.com/TelegramBots/book/raw/master/src/docs/sticker-dali.webp"
                );
            }

            else if (e.Message.Text.ToLower().Contains("contact"))
            {
                Console.WriteLine("opcion contacto");
                await _botclient.SendContactAsync(
                    chatId: e.Message.Chat.Id,
                    phoneNumber: "123456789",
                    firstName: "Test",
                    lastName: "bot"

                );
            }

            else if(e.Message.Text.ToLower().Contains("/repeat"))
            {
               
                
               await _botclient.SendTextMessageAsync
                (
                    chatId: e.Message.Chat.Id,
                    text: $"jevi, le llegamos a tu cotorra: {e.Message.Text}"
                );
            }
            

        }
    }
}
