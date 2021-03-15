namespace P02._DrawingShape_Before
{
    using Contracts;
    using Drawers;
    using System.Collections.Generic;

    class DrawingManager
    {
        private List<IDrawingManager> drawers = new List<IDrawingManager>()
        {
            new CircleDrawer(),
            new RectangleDrawer()
        };
        public void Draw(IShape shape)
        {
            foreach (var drawer in drawers)
            {
                if (drawer.IsMatch(shape))
                {
                    drawer.Draw(shape);
                }
            }
        }
    }
}
