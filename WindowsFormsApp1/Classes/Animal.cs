using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class Animal : Entity
    {
        private string _name;
        private int hungerPoints;
        private bool isHungry;
        private int hungerLimit;
        private string voise;
        private bool isVisible;
        private List<Food> food;

        public string name { get => _name; set => _name = value; }
        public int HungerPoints { get => hungerPoints; set => hungerPoints = value; }
        public int HungerLimit { get => hungerLimit; set => hungerLimit = value; }
        public string Voise { get => voise; set => voise = value; }
        public bool IsVisible { get => isVisible; set => isVisible = value; }
        public List<Food> Food { get => food; set => food = value; }

        public Animal(int hungerPoints = 0, bool isHungry = false, List<Food> food = null)
        {
            this.HungerPoints = hungerPoints;
            this.isHungry = isHungry;
            this.isVisible = true;
            this.Food = food;
        }

        public bool IsHungry()
        {
            return this.isHungry;
        }

        public void PlusHungry()
        {
            HungerPoints++;
            isHungry = HungerPoints >= HungerLimit;
        }

        public void VoiseFunc()
        {
            MessageBox.Show(Voise);
        }

        public override void ShowStatus()
        {
            MessageBox.Show($"Type: {this.name}\n" +
                            $"Hunger points: {this.HungerPoints} / {this.HungerLimit}\n" +
                            (isHungry ? "I'm hungry!" : "I'm full") + "\n" +
                            (isVisible ? "Visible" : "Hiding"));
        }

        public void Feeding()
        {
            this.isHungry = false;
            this.HungerPoints = 0;
        }
    }
}
