using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Need to use BankingProject so that Account can be inherited by Savings
using BankingProject;

namespace BankingLibrary {
	//We are going to inherit Account, so Savings can use its properties
	public class Savings : Account {

		public double IntRate {
			get; set;
		}

		//Adds the interest to the current balance of the Savings account by multipling the current
		//balance of the account by the interest rate, and then adding the product to the current
		//balance.
		public void PayMonthlyInterest() {
			var InterestAmount = CheckBalance() * IntRate;
			Deposit(InterestAmount);
		}

		//As with the Inheritance exercise, we are able to use "override" here to call this method,
		//instead of the "virtual" ToPrint in the Account class.
		public override string ToPrint() {
			return (base.ToPrint() + $" with an interest rate of {IntRate}");
		}

		//Constructors for the Savings class, base allows the constructors to call the respective
		//constructor in the Account class.
		public Savings() : base() {

		}

		public Savings(string name) : base(name) {

		}
		//If we want the user to be able to set the IntRate, we need a constructor for that.
		//We still only need to use base(name), because that is calling the proper constructor
		//in the Account class, the one that takes a string as the Name.
		//Because the IntRate is not in the Account class, we do not need to include that as
		//part of base().
		public Savings(string name, double intRate) : base(name) {
			IntRate = intRate;
		}
	}
}
