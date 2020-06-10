using OpenKh.Engine.Renders;
using System.Windows.Input;

namespace OpenKh.Tools.Common.Interfaces
{
    public interface IEditorHelper<T> where T : class
    {
        void OnMouseMove(T source, MouseEventArgs e);
        void OnMouseDown(T source, MouseEventArgs e);
        void OnMouseUp(T source, MouseEventArgs e);

        void OnDraw(T source, ISpriteDrawing drawing);
    }
}
