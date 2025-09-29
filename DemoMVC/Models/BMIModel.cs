namespace DemoMVC.Models
{
    public class BmiModel
    {
        public double Weight { get; set; }  // Cân nặng (kg)
        public double Height { get; set; }  // Chiều cao (m)
        public double BMI { get; set; }
        public string Category { get; set; } = string.Empty;
    }
}
