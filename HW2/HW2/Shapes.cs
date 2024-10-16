using System.Collections.Generic;
using System.Linq;

namespace HW2
{
    public class ShapeWrapper
    {
        public int Id { get; set; }
        public string ShapeType { get; set; }
        public Shape Shape { get; set; }
    }

    public class Shapes
    {
        private int uid = 0;
        private List<ShapeWrapper> shapeList;

        public Shapes()
        {
            shapeList = new List<ShapeWrapper>();
        }

        public void AddShape(Shape shape, string shapeType)
        {
            var shapeWrapper = new ShapeWrapper
            {
                Id = NewId(),
                ShapeType = shapeType,
                Shape = shape
            };
            shapeList.Add(shapeWrapper);
        }

        public List<ShapeWrapper> GetShapes()
        {
            return shapeList;
        }

        public void DeleteShape(int id)
        {
            var shapeToRemove = shapeList.FirstOrDefault(s => s.Id == id);
            if (shapeToRemove != null)
            {
                shapeList.Remove(shapeToRemove);
            }
        }

        public ShapeWrapper GetShapeById(int id)
        {
            return shapeList.FirstOrDefault(s => s.Id == id);
        }

        public int NewId()
        {
            return uid++;
        }
    }
}