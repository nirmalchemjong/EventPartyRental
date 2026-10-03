using System;

namespace EventPartyRental
{
    // 1. ABSTRACTION & ENCAPSULATION
    // We use an abstract base class so we can't instantiate a generic "item".
    // We use private fields with public properties (get/set) to protect the data.
    public abstract class RentalItem
    {
        private int _itemId;
        private string _name;
        private decimal _dailyRate;

        public int ItemID
        {
            get { return _itemId; }
            set { _itemId = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public decimal DailyRate
        {
            get { return _dailyRate; }
            set { _dailyRate = value; }
        }

        // Constructor
        public RentalItem(int id, string name, decimal dailyRate)
        {
            ItemID = id;
            Name = name;
            DailyRate = dailyRate;
        }

        // Abstract method to enforce polymorphism in child classes
        public abstract decimal CalculateRentalFee(int days);
    }

    // 2. INHERITANCE
    // FurnitureItem inherits from the base RentalItem class
    public class FurnitureItem : RentalItem
    {
        public FurnitureItem(int id, string name, decimal dailyRate)
            : base(id, name, dailyRate)
        {
        }

        // 3. POLYMORPHISM
        // Standard calculation for furniture: just Rate * Days
        public override decimal CalculateRentalFee(int days)
        {
            return DailyRate * days;
        }
    }

    // 2. INHERITANCE
    // ElectronicItem inherits from the base RentalItem class

    // Applies a standard $15 insurance fee to all electronic rentals
    public class ElectronicItem : RentalItem
    {
        public ElectronicItem(int id, string name, decimal dailyRate)
            : base(id, name, dailyRate)
        {
        }

        // 3. POLYMORPHISM
        // Custom calculation for electronics: adds a flat $15 handling/insurance fee
        public override decimal CalculateRentalFee(int days)
        {
            decimal insuranceFee = 15.00m;
            return (DailyRate * days) + insuranceFee;
        }
    }
}