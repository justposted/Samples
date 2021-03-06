#region Using Statements
using WaveEngine.Components.Graphics2D;
using WaveEngine.Components.UI;
using WaveEngine.Framework;
using WaveEngine.Framework.Graphics;
using WaveEngine.Framework.Services;
using WaveEngine.Framework.UI;
using WaveEngine.Kinect;
#endregion

namespace KinectSample
{
    public class MyScene : Scene
    {
        protected override void CreateScene()
        {
            WaveServices.ScreenContextManager.SetDiagnosticsActive(true);

            this.Load(WaveContent.Scenes.MyScene);

            var kinectService = WaveServices.GetService<KinectService>();

            Texture2D texture = kinectService.ColorTexture;

            Entity sprite = new Entity()
                                .AddComponent(new Transform2D()
                                {
                                    XScale = (float)this.VirtualScreenManager.VirtualWidth / (float)texture.Width,
                                    YScale = (float)this.VirtualScreenManager.VirtualHeight / (float)texture.Height,
                                })
                                .AddComponent(new Sprite(texture))
                                .AddComponent(new SpriteRenderer(DefaultLayers.Opaque));
            EntityManager.Add(sprite);

            TextBlock label = new TextBlock()
            {
                Text = string.Format("Kinect sensor is available: {0} ", kinectService.IsAvailable.ToString()),
                Margin = new Thickness(20, 20, 20, 20),
                VerticalAlignment = VerticalAlignment.Bottom,
            };
            EntityManager.Add(label);
        }
    }
}
