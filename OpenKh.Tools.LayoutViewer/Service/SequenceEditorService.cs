using OpenKh.Engine.Extensions;
using OpenKh.Engine.Renders;
using OpenKh.Imaging;
using OpenKh.Kh2;
using OpenKh.Tools.Common.Controls;
using OpenKh.Tools.Common.Interfaces;
using System.Windows;
using System.Windows.Input;

namespace OpenKh.Tools.LayoutViewer.Service
{
    public class SequenceEditorService : IEditorHelper<SequenceRendererPanel>, IDebugSequenceRenderer
    {
        private class FakeSpriteDrawing : ISpriteDrawing
        {
            public ISpriteTexture DestinationTexture { get => null;  set { } }
            public ISpriteTexture CreateSpriteTexture(IImageRead image) => null;
            public ISpriteTexture CreateSpriteTexture(int width, int height) => null;
            public void SetViewport(float left, float right, float top, float bottom) { }
            public void Clear(ColorF color) { }

            public void AppendSprite(SpriteDrawingContext context)
            {
                throw new System.NotImplementedException();
            }

            public void Flush() { }
            public void Dispose() { }
        }

        private Point _pointer;

        public void OnMouseMove(SequenceRendererPanel source, MouseEventArgs e)
        {
            _pointer = e.GetPosition(e.Source as IInputElement);
        }

        public void OnMouseDown(SequenceRendererPanel source, MouseEventArgs e)
        {
        }

        public void OnMouseUp(SequenceRendererPanel source, MouseEventArgs e)
        {
        }

        public void OnDraw(SequenceRendererPanel source, ISpriteDrawing drawing)
        {
            drawing.FillRectangle(
                (float)(_pointer.X - 2),
                (float)(_pointer.Y - 2),
                4, 4, new ColorF(0, 1, 0, 1));
        }

        private static Sequence.FrameEx GetSpriteExtended(int x, int y)
        {

            return null;
        }

        public int CheckSpritePartCollision(Sequence.FrameEx spritePart, float left, float top, float right, float bottom)
        {

        }
    }
}
