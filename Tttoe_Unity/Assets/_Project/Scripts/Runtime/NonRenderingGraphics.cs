using UnityEngine.UI;

namespace com.tttoe.runtime
{
    public class NonRenderingGraphics : Graphic
    {
        protected override void OnPopulateMesh(VertexHelper vh)
        {
            vh.Clear();
        }
    }
}