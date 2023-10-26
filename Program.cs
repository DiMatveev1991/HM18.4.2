using YoutubeExplode;
using YoutubeExplode.Converter;
using System.Linq;
using System;

namespace MyYoutubeClient
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            //ссылка на видео
             Console.WriteLine ("Введите ссылку на ютуб видео для скачивания:");
            string url = Console.ReadLine();
            string outPathFile = @"C:\YoutubeClient\";
            //создание объектов: отправитель, получатель, команда - получение информации о видео
            var sender = new SenderCommand();
            var receiver = new Receiver();
            var getInfoVideo = new GetInfoVideoCommand(receiver);

            /*1. отправка команды
             *2. получение информации о видео
            */
            sender.SetCommand(getInfoVideo);
            await sender.GetInfo(url);

            /*1. создание команды на скачивание видео
             *2. отправка команды на скачивание
             *3. Запуск скачивания
            */
            var downloadVideo = new DownloadCommand(receiver);
            sender.SetCommand(downloadVideo);
            await sender.DownLoad(url, outPathFile);

           
        }
    }
}