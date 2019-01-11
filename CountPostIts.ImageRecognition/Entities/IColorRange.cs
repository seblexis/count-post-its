namespace CountPostIts.ImageRecognition.Entities
{
    public interface IColorRange
    {   
       int[] RangeRed { get; set; }
       int[] RangeGreen { get; set; }
       int[] RangeBlue { get; set; }
    }
}