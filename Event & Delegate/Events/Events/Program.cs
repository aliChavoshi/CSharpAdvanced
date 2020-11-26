using System;
using System.Threading;
using System.Threading.Tasks;

namespace Events
{
    public class Video
    {
        public string Title { get; set; }
    }

    public class VideoEventArgs : EventArgs
    {
        public Video Video { get; set; }

    }

    public class VideoEncoder
    {

        //public delegate void VideoEncodedEventHandler(object source, VideoEventArgs args);

        public event EventHandler<VideoEventArgs> VideoEncoded;

        public void Encode(Video video)
        {
            Console.WriteLine("Video Encoding ...");
            Thread.Sleep(3000);

            OnVideoEncoded(video);
        }

        protected virtual void OnVideoEncoded(Video video)
        {
            if (VideoEncoded != null)
                VideoEncoded(this, new VideoEventArgs() { Video = video });
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            var videoEncode = new VideoEncoder();//publisher

            var mailService = new MailService();//subscriber
            var messageService = new MessageService();//subscriber

            videoEncode.VideoEncoded += mailService.OnVideoEncoded;
            videoEncode.VideoEncoded += messageService.OnVideoEncoded;


            videoEncode.Encode(new Video() { Title = "Video 1" });
        }
    }


    public class MessageService
    {
        public void OnVideoEncoded(object source, VideoEventArgs args)
        {
            Console.WriteLine("Message Service Send Message ..." + args.Video.Title);
        }
    }

    public class MailService
    {
        public void OnVideoEncoded(object source, VideoEventArgs args)
        {
            Console.WriteLine("Mail Service Send an Email ...." + args.Video.Title);
        }
    }


}
